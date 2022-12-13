using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2020_05_01.ManagementGroups;

internal class UbscriptionsDeleteOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? OptionsObject() => typeof(UbscriptionsDeleteOperation.UbscriptionsDeleteOptions);

    internal class UbscriptionsDeleteOptions
    {
        [HeaderName("Cache-Control")]
        [Optional]
        public string CacheControl { get; set; }
    }
}
