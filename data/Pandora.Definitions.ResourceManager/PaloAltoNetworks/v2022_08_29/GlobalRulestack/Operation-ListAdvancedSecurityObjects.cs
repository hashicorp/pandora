using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.GlobalRulestack;

internal class ListAdvancedSecurityObjectsOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new GlobalRuleStackId();

    public override Type? ResponseObject() => typeof(AdvSecurityObjectListResponseModel);

    public override Type? OptionsObject() => typeof(ListAdvancedSecurityObjectsOperation.ListAdvancedSecurityObjectsOptions);

    public override string? UriSuffix() => "/listAdvancedSecurityObjects";

    internal class ListAdvancedSecurityObjectsOptions
    {
        [QueryStringName("skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("top")]
        [Optional]
        public int Top { get; set; }

        [QueryStringName("type")]
        public AdvSecurityObjectTypeEnumConstant Type { get; set; }
    }
}
