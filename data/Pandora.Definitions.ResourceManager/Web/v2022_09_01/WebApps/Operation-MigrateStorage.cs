using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

internal class MigrateStorageOperation : Pandora.Definitions.Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(StorageMigrationOptionsModel);

    public override ResourceID? ResourceId() => new AppServiceId();

    public override Type? OptionsObject() => typeof(MigrateStorageOperation.MigrateStorageOptions);

    public override string? UriSuffix() => "/migrate";

    internal class MigrateStorageOptions
    {
        [QueryStringName("subscriptionName")]
        public string SubscriptionName { get; set; }
    }
}
