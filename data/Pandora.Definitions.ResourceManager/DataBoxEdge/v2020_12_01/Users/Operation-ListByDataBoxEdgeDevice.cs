using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Users;

internal class ListByDataBoxEdgeDeviceOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new DataBoxEdgeDeviceId();

    public override Type NestedItemType() => typeof(UserModel);

    public override Type? OptionsObject() => typeof(ListByDataBoxEdgeDeviceOperation.ListByDataBoxEdgeDeviceOptions);

    public override string? UriSuffix() => "/users";

    internal class ListByDataBoxEdgeDeviceOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
