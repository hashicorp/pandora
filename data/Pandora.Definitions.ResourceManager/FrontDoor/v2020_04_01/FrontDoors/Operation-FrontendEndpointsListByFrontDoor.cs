using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;

internal class FrontendEndpointsListByFrontDoorOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new FrontDoorId();

\t\tpublic override Type NestedItemType() => typeof(FrontendEndpointModel);

\t\tpublic override string? UriSuffix() => "/frontendEndpoints";


}
