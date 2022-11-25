using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ExtendedLocation.v2021_08_15.CustomLocations;

internal class ListEnabledResourceTypesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new CustomLocationId();

    public override Type NestedItemType() => typeof(EnabledResourceTypeModel);

    public override string? UriSuffix() => "/enabledResourceTypes";


}
