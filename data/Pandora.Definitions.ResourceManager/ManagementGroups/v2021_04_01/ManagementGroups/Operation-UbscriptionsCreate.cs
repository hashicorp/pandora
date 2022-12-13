using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.ManagementGroups;

internal class UbscriptionsCreateOperation : Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(SubscriptionUnderManagementGroupModel);

    public override Type? OptionsObject() => typeof(UbscriptionsCreateOperation.UbscriptionsCreateOptions);

    internal class UbscriptionsCreateOptions
    {
        [HeaderName("Cache-Control")]
        [Optional]
        public string CacheControl { get; set; }
    }
}
