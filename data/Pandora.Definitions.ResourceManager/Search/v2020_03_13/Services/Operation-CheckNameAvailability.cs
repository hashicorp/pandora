using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Search.v2020_03_13.Services;

internal class CheckNameAvailabilityOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CheckNameAvailabilityInputModel);

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(CheckNameAvailabilityOutputModel);

    public override Type? OptionsObject() => typeof(CheckNameAvailabilityOperation.CheckNameAvailabilityOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Search/checkNameAvailability";

    internal class CheckNameAvailabilityOptions
    {
        [HeaderName("x-ms-client-request-id")]
        [Optional]
        public string XNegativemsNegativeclientNegativerequestNegativeid { get; set; }
    }
}
