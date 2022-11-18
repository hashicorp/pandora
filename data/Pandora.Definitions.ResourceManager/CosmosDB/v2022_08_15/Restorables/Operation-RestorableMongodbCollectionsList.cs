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

internal class RestorableMongodbCollectionsListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new RestorableDatabaseAccountId();

\t\tpublic override Type? ResponseObject() => typeof(RestorableMongodbCollectionsListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(RestorableMongodbCollectionsListOperation.RestorableMongodbCollectionsListOptions);

\t\tpublic override string? UriSuffix() => "/restorableMongodbCollections";

    internal class RestorableMongodbCollectionsListOptions
    {
        [QueryStringName("restorableMongodbDatabaseRid")]
        [Optional]
        public string RestorableMongodbDatabaseRid { get; set; }
    }
}
