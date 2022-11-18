using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.StorageAccounts;

internal class FailoverOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new StorageAccountId();

    public override Type? OptionsObject() => typeof(FailoverOperation.FailoverOptions);

    public override string? UriSuffix() => "/failover";

    internal class FailoverOptions
    {
        [QueryStringName("failoverType")]
        [Optional]
        public FailoverTypeConstant FailoverType { get; set; }
    }
}
