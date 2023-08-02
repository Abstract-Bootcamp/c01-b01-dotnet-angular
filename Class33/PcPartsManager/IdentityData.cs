using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsManager
{
    public class IdentityData
    {
        // policies
        public const string AdminPolicyName = "admin";
        public const string UserPolicyName = "user";

        // claims
        public const string AdminClaimName = "admin";
        public const string UserClaimName = "user";
    }
}