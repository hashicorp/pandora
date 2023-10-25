using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedDatabaseSensitivityLabels;

internal class ListCurrentByDatabaseOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ManagedInstanceDatabaseId();

    public override Type NestedItemType() => typeof(SensitivityLabelModel);

    public override Type? OptionsObject() => typeof(ListCurrentByDatabaseOperation.ListCurrentByDatabaseOptions);

    public override string? UriSuffix() => "/currentSensitivityLabels";

    internal class ListCurrentByDatabaseOptions
    {
        [QueryStringName("$count")]
        [Optional]
        public bool Count { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
