using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectableItems;

internal class ListByReplicationProtectionContainersOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ReplicationProtectionContainerId();

    public override Type NestedItemType() => typeof(ProtectableItemModel);

    public override Type? OptionsObject() => typeof(ListByReplicationProtectionContainersOperation.ListByReplicationProtectionContainersOptions);

    public override string? UriSuffix() => "/replicationProtectableItems";

    internal class ListByReplicationProtectionContainersOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$take")]
        [Optional]
        public string Take { get; set; }
    }
}
