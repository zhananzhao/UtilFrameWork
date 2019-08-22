using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Util.Webs.EasyUi.Tests.Samples {
    public class Test2 {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required( ErrorMessage = "姓名不能为空" )]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Display( Name = "描述" )]
        public string Description { get; set; }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        public static List<Test2> CreateList() {
            return new List<Test2>() {
                new Test2(){Id = 1,Name = "a",Description = "a"},
                new Test2(){Id = 2,Name = "b",Description = "b"}
            };
        }
    }
}
