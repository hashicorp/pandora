using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_03_15.Restorables;

internal class RestorableTableResourcesListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RestorableDatabaseAccountId();

    public override Type? ResponseObject() => typeof(RestorableTableResourcesListResultModel);

    public override Type? OptionsObject() => typeof(RestorableTableResourcesListOperation.RestorableTableResourcesListOptions);

    public override string? UriSuffix() => "/restorableTableResources";

    internal class RestorableTableResourcesListOptions
    {
        [QueryStringName("restoreLocation")]
        [Optional]
        public string RestoreLocation { get; set; }

        [QueryStringName("restoreTimestampInUtc")]
        [Optional]
        public string RestoreTimestampInUtc { get; set; }
    }
}
