using System;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    internal class Get : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new B2CDirectoryId();
        }

        public override Type? ResponseObject()
        {
            return typeof(TenantModel);
        }
    }
}