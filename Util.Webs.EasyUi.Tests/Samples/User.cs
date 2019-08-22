using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Util.Webs.EasyUi.Tests.Samples {
    /// <summary>
    /// 用户
    /// </summary>
    public class User {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Display( Name = "描述" )]
        public string Description { get; set; }
        /// <summary>
        /// 用来测试字符串长度
        /// </summary>
        [StringLength(5,MinimumLength = 2)]
        public string StringLength { get; set; }
        /// <summary>
        /// 用来测试最大字符串长度
        /// </summary>
        [StringLength( 5 )]
        public string StringMaxLength { get; set; }
        /// <summary>
        /// 布尔值
        /// </summary>
        public bool BoolValue { get; set; }
        /// <summary>
        /// 可空布尔值
        /// </summary>
        public bool? NullableBoolValue { get; set; }
        /// <summary>
        /// 枚举值
        /// </summary>
        public TestEnum EnumValue { get; set; }
        /// <summary>
        /// 可空枚举值
        /// </summary>
        public TestEnum? NullableEnumValue { get; set; }
        /// <summary>
        /// 日期值
        /// </summary>
        public DateTime DateTimeValue { get; set; }
    }
}
