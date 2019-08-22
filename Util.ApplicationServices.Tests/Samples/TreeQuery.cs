using System;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.ApplicationServices.Tests.Samples {
    public class TreeQuery : TreeEntityQuery{
        public Guid? ParentId { get; set; }
        public int? Level { get; set; }
        public string Path { get; set; }
        protected override void CheckEmpty() {
            throw new NotImplementedException();
        }
    }
}
