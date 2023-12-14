using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.LongTermRetentionManagedInstanceBackups;

internal class ListByResourceGroupInstanceOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new LocationLongTermRetentionManagedInstanceId();

    public override Type NestedItemType() => typeof(ManagedInstanceLongTermRetentionBackupModel);

    public override Type? OptionsObject() => typeof(ListByResourceGroupInstanceOperation.ListByResourceGroupInstanceOptions);

    public override string? UriSuffix() => "/longTermRetentionManagedInstanceBackups";

    internal class ListByResourceGroupInstanceOptions
    {
        [QueryStringName("databaseState")]
        [Optional]
        public DatabaseStateConstant DatabaseState { get; set; }

        [QueryStringName("onlyLatestPerDatabase")]
        [Optional]
        public bool OnlyLatestPerDatabase { get; set; }
    }
}
