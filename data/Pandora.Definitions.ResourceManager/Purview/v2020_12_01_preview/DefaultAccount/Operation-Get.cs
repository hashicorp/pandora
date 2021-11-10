using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.DefaultAccount
{
    internal class GetOperation : Operations.GetOperation
    {
        public override Type? ResponseObject() => typeof(DefaultAccountPayloadModel);

        public override Type? OptionsObject() => typeof(GetOperation.GetOptions);

        public override string? UriSuffix() => "/providers/Microsoft.Purview/getDefaultAccount";

        internal class GetOptions
        {
            [QueryStringName("scope")]
            [Optional]
            public string Scope { get; set; }

            [QueryStringName("scopeTenantId")]
            public string ScopeTenantId { get; set; }

            [QueryStringName("scopeType")]
            public ScopeTypeConstant ScopeType { get; set; }
        }
    }
}
