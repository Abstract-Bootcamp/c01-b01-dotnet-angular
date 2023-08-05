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
        public const string ViewCategoryPolicy = "viewCategory";

        // claims
        public const string AdminClaimName = "admin";
        public const string UserClaimName = "user";
        public const string CategoryClaim = "category";
        public const string ViewCategoryClaim = "category.view";
    }
}