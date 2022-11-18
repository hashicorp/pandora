using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationMigrationItems;

internal class ListByReplicationProtectionContainersOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new ReplicationProtectionContainerId();

\t\tpublic override Type NestedItemType() => typeof(MigrationItemModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByReplicationProtectionContainersOperation.ListByReplicationProtectionContainersOptions);

\t\tpublic override string? UriSuffix() => "/replicationMigrationItems";

    internal class ListByReplicationProtectionContainersOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("skipToken")]
        [Optional]
        public string SkipToken { get; set; }

        [QueryStringName("takeToken")]
        [Optional]
        public string TakeToken { get; set; }
    }
}
