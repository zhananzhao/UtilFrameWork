using System;
using System.Security.Principal;

namespace Util.Security.Tests.Samples {
    public class PermissionManager : PermissionManagerBase{
        public PermissionManager( Identity identity, ISecurityManager securityManager, bool ignore = false )
            : base( securityManager,ignore ) {
            _identity = identity;
        }
        private Identity _identity;

        protected override Identity GetIdentity() {
            return _identity;
        }
    }
}
