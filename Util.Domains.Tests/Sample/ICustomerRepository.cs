using Util.Domains.Repositories;

namespace Util.Domains.Tests.Sample {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer,int> {
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="customer">客户</param>
        void AddCustomerByNotCommit( Customer customer );
    }
}
