using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.Restorables;

internal class RestorableSqlResourcesListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RestorableDatabaseAccountId();

    public override Type? ResponseObject() => typeof(RestorableSqlResourcesListResultModel);

    public override Type? OptionsObject() => typeof(RestorableSqlResourcesListOperation.RestorableSqlResourcesListOptions);

    public override string? UriSuffix() => "/restorableSqlResources";

    internal class RestorableSqlResourcesListOptions
    {
        [QueryStringName("restoreLocation")]
        [Optional]
        public string RestoreLocation { get; set; }

        [QueryStringName("restoreTimestampInUtc")]
        [Optional]
        public string RestoreTimestampInUtc { get; set; }
    }
}
