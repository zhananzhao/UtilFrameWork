using System.Collections.Generic;
using System.Linq;
using Util.Datas;
using Util.Domains;
using Util.Domains.Repositories;
using Util.Exceptions;
using Util.Logs;
using Util.Security;

namespace Util.ApplicationServices {
    /// <summary>
    /// 应用服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class ServiceBase<TEntity, TDto, TQuery, TKey> : IServiceBase<TDto, TQuery>
        where TEntity : class, IAggregateRoot<TKey>
        where TDto : IDto, new()
        where TQuery : IPager {

        #region 构造方法

        /// <summary>
        /// 初始化应用服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected ServiceBase( IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository ) {
            Log = Logs.Log4.Log.GetContextLog( this );
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        #endregion

        #region 字段属性

        /// <summary>
        /// 仓储
        /// </summary>
        protected readonly IRepository<TEntity, TKey> Repository;

        /// <summary>
        /// 日志操作
        /// </summary>
        protected ILog Log { get; set; }

        /// <summary>
        /// 工作单元
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// 获取当前用户编号
        /// </summary>
        protected string SelfId {
            get { return SecurityContext.Identity.UserId; }
        }

        #endregion

        #region 实体转换

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected abstract TDto ToDto( TEntity entity );

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected abstract TEntity ToEntity( TDto dto );

        #endregion

        #region 日志

        /// <summary>
        /// 记录更新前实体状态
        /// </summary>
        /// <param name="entity">实体</param>
        private void LogBefore( TEntity entity ) {
            Log.Content.AddLine( "修改前：" );
            Log.Content.AddLine( entity.ToString() );
            Log.Content.AddLine( "修改后：" );
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="entity">实体</param>
        protected void AddLog( TEntity entity ) {
            if ( !Log.BusinessId.IsEmpty() )
                Log.BusinessId += ",";
            Log.BusinessId += entity.Id.ToString();
            Log.Content.AddLine( entity.ToString() );
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="entity">实体</param>
        protected void WriteLog( string caption, TEntity entity ) {
            Log.Caption.Add( caption );
            AddLog( entity );
            Log.Info();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="caption">标题</param>
        protected void WriteLog( string caption ) {
            Log.Caption.Add( caption );
            Log.Info();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="entities">实体集合</param>
        protected void WriteLog( string caption, IList<TEntity> entities ) {
            Log.Caption.Add( caption );
            Log.BusinessId = entities.Select( t => t.Id ).Splice();
            foreach ( var entity in entities )
                Log.Content.AddLine( entity.ToString() );
            Log.Info();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="query">查询参数</param>
        /// <param name="sql">Sql语句</param>
        protected void WriteLog( IPager query, string sql = "" ) {
            Log.SqlParams.AddLine( query.ToString() );
            Log.Sql.Add( sql );
            Log.Debug();
        }

        #endregion

        #region Create(创建实体)

        /// <summary>
        /// 创建实体
        /// </summary>
        public virtual TDto Create() {
            return new TDto();
        }

        #endregion

        #region Get(通过编号获取实体)

        /// <summary>
        /// 通过编号获取实体
        /// </summary>
        /// <param name="id">实体编号</param>
        public virtual TDto Get( object id ) {
            var key = Conv.To<TKey>( id );
            if ( key.Equals( default( TKey ) ) )
                return Create();
            return ToDto( Repository.Find( key ) );
        }

        #endregion

        #region GetByIds(通过编号集合获取列表)

        /// <summary>
        /// 通过编号集合获取列表
        /// </summary>
        /// <param name="ids">Id集合字符串，多个Id用逗号分隔</param>
        public List<TDto> GetByIds( string ids ) {
            return GetEntitiesByIds( ids ).Select( ToDto ).ToList();
        }

        /// <summary>
        /// 通过编号集合获取实体集合
        /// </summary>
        protected List<TEntity> GetEntitiesByIds( string ids ) {
            var idList = Conv.ToList<TKey>( ids );
            idList.RemoveAll( t => t.Equals( default( TKey ) ) );
            return Repository.Find( idList );
        }

        #endregion

        #region GetAll(获取全部列表)

        /// <summary>
        /// 获取全部列表
        /// </summary>
        public virtual List<TDto> GetAll() {
            return Repository.FindAll().Select( ToDto ).ToList();
        }

        #endregion

        #region Query(查询)

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="param">查询参数</param>
        public virtual PagerList<TDto> Query( TQuery param ) {
            var query = GetQuery( param );
            var queryable = Repository.Query( query ).OrderBy( query.GetOrderBy() ).Pager( query );
            WriteLog( param, queryable.ToString() );
            return queryable.ToPageList( query ).Convert( ToDto );
        }

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        public abstract IQueryBase<TEntity> GetQuery( TQuery param );

        #endregion

        #region Save(保存)

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        public virtual void Save( TDto dto ) {
            UnitOfWork.Start();
            var entity = ToEntity( dto );
            if ( IsNew( dto, entity ) )
                Add( entity );
            else
                Update( entity );
            UnitOfWork.Commit();
            WriteLog( "保存成功" );
        }

        /// <summary>
        /// 是否新增
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        /// <param name="entity">领域实体</param>
        protected virtual bool IsNew( TDto dto, TEntity entity ) {
            if ( dto.Id.IsEmpty() )
                return true;
            if ( entity.Id.Equals( default( TKey ) ) )
                return true;
            return false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        protected virtual void Add( TEntity entity ) {
            entity.CheckNull( "entity" );
            AddBefore( entity );
            entity.Init();
            entity.Validate();
            Repository.Add( entity );
            AddAfter( entity );
        }

        /// <summary>
        /// 添加前操作
        /// </summary>
        protected virtual void AddBefore( TEntity entity ) {
        }

        /// <summary>
        /// 添加后操作
        /// </summary>
        protected virtual void AddAfter( TEntity entity ) {
            AddLog( entity );
        }

        /// <summary>
        /// 修改
        /// </summary>
        protected virtual void Update( TEntity entity ) {
            entity.CheckNull( "entity" );
            var oldEntity = Repository.Find( entity.Id );
            oldEntity.CheckNull( "oldEntity" );
            UpdateBefore( entity, oldEntity );
            entity.Validate();
            Update( entity, oldEntity );
            UpdateAfter( entity );
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="newEntity">新实体</param>
        /// <param name="oldEntity">数据库中的旧实体</param>
        protected virtual void UpdateBefore( TEntity newEntity, TEntity oldEntity ) {
            //ValidateVersion( newEntity, oldEntity );
            LogBefore( oldEntity );
        }

        //验证版本号
        //private void ValidateVersion( TEntity newEntity, TEntity oldEntity ) {
        //    if ( newEntity.Version == null )
        //        throw new ConcurrencyException();
        //    for ( int i = 0; i < oldEntity.Version.Length; i++ )
        //        if ( newEntity.Version[i] != oldEntity.Version[i] )
        //            throw new ConcurrencyException();
        //}

        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="newEntity">新实体</param>
        /// <param name="oldEntity">数据库中的旧实体</param>
        protected virtual void Update( TEntity newEntity, TEntity oldEntity ) {
            Repository.Update( newEntity, oldEntity );
        }

        /// <summary>
        /// 修改后操作
        /// </summary>
        protected virtual void UpdateAfter( TEntity entity ) {
            AddLog( entity );
        }

        #endregion

        #region Delete(删除)

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">Id集合字符串，多个Id用逗号分隔</param>
        public virtual void Delete( string ids ) {
            var entities = GetEntitiesByIds( ids );
            DeleteBefore( entities );
            Repository.Remove( entities );
            WriteLog( "删除成功", entities );
        }

        /// <summary>
        /// 删除前操作
        /// </summary>
        /// <param name="entities">实体集合</param>
        protected virtual void DeleteBefore( List<TEntity> entities ) {
        }

        #endregion
    }
}