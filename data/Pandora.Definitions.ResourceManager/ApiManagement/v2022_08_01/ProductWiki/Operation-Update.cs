using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ProductWiki;

internal class UpdateOperation : Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(WikiUpdateContractModel);

    public override ResourceID? ResourceId() => new ProductId();

    public override Type? ResponseObject() => typeof(WikiContractModel);

    public override Type? OptionsObject() => typeof(UpdateOperation.UpdateOptions);

    public override string? UriSuffix() => "/wikis/default";

    internal class UpdateOptions
    {
        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
