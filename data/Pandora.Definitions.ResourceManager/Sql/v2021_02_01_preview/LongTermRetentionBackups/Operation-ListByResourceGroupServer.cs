using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.LongTermRetentionBackups;

internal class ListByResourceGroupServerOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new LocationLongTermRetentionServerId();

    public override Type NestedItemType() => typeof(LongTermRetentionBackupModel);

    public override Type? OptionsObject() => typeof(ListByResourceGroupServerOperation.ListByResourceGroupServerOptions);

    public override string? UriSuffix() => "/longTermRetentionBackups";

    internal class ListByResourceGroupServerOptions
    {
        [QueryStringName("databaseState")]
        [Optional]
        public DatabaseStateConstant DatabaseState { get; set; }

        [QueryStringName("onlyLatestPerDatabase")]
        [Optional]
        public bool OnlyLatestPerDatabase { get; set; }
    }
}
