using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.DefaultAccount;

internal class RemoveOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override Type? OptionsObject() => typeof(RemoveOperation.RemoveOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Purview/removeDefaultAccount";

    internal class RemoveOptions
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
