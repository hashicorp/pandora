using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.LocalRuleStacks;

internal class GetSupportInfoOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new LocalRuleStackId();

    public override Type? ResponseObject() => typeof(SupportInfoModel);

    public override Type? OptionsObject() => typeof(GetSupportInfoOperation.GetSupportInfoOptions);

    public override string? UriSuffix() => "/getSupportInfo";

    internal class GetSupportInfoOptions
    {
        [QueryStringName("email")]
        [Optional]
        public string Email { get; set; }
    }
}
