using Util.Logs;
using Util.Security;

namespace Util.Domains {
    /// <summary>
    /// 领域服务
    /// </summary>
    public abstract class DomainServiceBase : IDomainService {
        /// <summary>
        /// 初始化领域服务
        /// </summary>
        protected DomainServiceBase() {
            Log = Logs.Log4.Log.GetContextLog( this );
        }

        /// <summary>
        /// 日志操作
        /// </summary>
        protected ILog Log { get; set; }

        /// <summary>
        /// 获取当前用户编号
        /// </summary>
        protected string SelfId {
            get { return SecurityContext.Identity.UserId; }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <typeparam name="TKey">标识类型</typeparam>
        /// <param name="caption">标题</param>
        /// <param name="entity">实体</param>
        protected void WriteLog<TKey>( string caption, IEntity<TKey> entity ) {
            Log.BusinessId = entity.Id.ToString();
            Log.Caption.Add( caption );
            Log.Content.Add( entity.ToString() );
            Log.Info();
        }
    }
}
