using System;
using System.Linq.Expressions;
using Util.Datas.Queries.Criterias;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Tests.Samples {
    /// <summary>
    /// 贵宾查询条件
    /// </summary>
    public class VipCriteria : CriteriaBase<Customer> {
        /// <summary>
        /// 初始化贵宾查询条件,假定英文名为B或C，且年龄大于10为贵宾
        /// </summary>
        public VipCriteria() {
            Predicate = t => ( t.EnglishName == "B" || t.EnglishName == "C" ) && t.Age > 10;
        }

        /// <summary>
        /// 获取谓词
        /// </summary>
        public override Expression<Func<Customer, bool>> GetPredicate() {
            return Predicate;
        }
    }
}
