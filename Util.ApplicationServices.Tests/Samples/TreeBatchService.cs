using System.Collections.Generic;
using System.Linq;
using Util.Datas;
using Util.Domains.Repositories;

namespace Util.ApplicationServices.Tests.Samples {
    /// <summary>
    /// 树型实体批操作服务
    /// </summary>
    public class TreeBatchService : TreeBatchService<TreeEntity,TreeDto,TreeQuery,int,int?> {
        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        public TreeBatchService( IUnitOfWork unitOfWork, ITreeEntityRepository repository )
            : base( unitOfWork, repository ) {
        }

        protected override TreeDto ToDto( TreeEntity entity ) {
            entity.CheckNull( "entity" );
            return entity.ToDto();
        }

        protected override TreeEntity ToEntity( TreeDto dto ) {
            return dto.ToEntity();
        }

        protected override List<TreeEntity> GetChilds( TreeEntity parent ) {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        protected override List<TreeDto> GetResult() {
            return _addList.Select( ToDto ).ToList().Union( _updateList.Select( ToDto ).ToList() ).ToList();
        }

        public override IQueryBase<TreeEntity> GetQuery( TreeQuery param ) {
            throw new System.NotImplementedException();
        }
    }
}
