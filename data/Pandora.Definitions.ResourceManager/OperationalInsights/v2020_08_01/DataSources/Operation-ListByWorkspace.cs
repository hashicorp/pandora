using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.DataSources;

internal class ListByWorkspaceOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new WorkspaceId();

    public override Type NestedItemType() => typeof(DataSourceModel);

    public override Type? OptionsObject() => typeof(ListByWorkspaceOperation.ListByWorkspaceOptions);

    public override string? UriSuffix() => "/dataSources";

    internal class ListByWorkspaceOptions
    {
        [QueryStringName("$filter")]
        public string Filter { get; set; }
    }
}
