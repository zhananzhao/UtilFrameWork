using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Webs.EasyUi.Tests.Samples {
    public class Test1 {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }


        public static List<Test1> Create() {
            return new List<Test1> {
                new Test1() {
                    Id = "1",
                    Name = "a"
                }
                ,new Test1() {
                    Id = "2",
                    Name = "b",
                    ParentId = "1"
                }
            };
        }
    }
}
