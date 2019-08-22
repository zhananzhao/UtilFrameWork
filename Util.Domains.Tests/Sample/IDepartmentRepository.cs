using Util.Domains.Repositories;

namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 部门仓储
    /// </summary>
    public interface IDepartmentRepository : IRepository<Department,string> {
    }
}
