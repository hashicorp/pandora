using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.OpenidConnectProvider;

internal class OpenIdConnectProviderUpdateOperation : Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(OpenidConnectProviderUpdateContractModel);

    public override ResourceID? ResourceId() => new OpenidConnectProviderId();

    public override Type? ResponseObject() => typeof(OpenidConnectProviderContractModel);

    public override Type? OptionsObject() => typeof(OpenIdConnectProviderUpdateOperation.OpenIdConnectProviderUpdateOptions);

    internal class OpenIdConnectProviderUpdateOptions
    {
        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
