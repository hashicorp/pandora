using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.GeographicHierarchies;

internal class GetDefaultOperation : Operations.GetOperation
{
\t\tpublic override Type? ResponseObject() => typeof(TrafficManagerGeographicHierarchyModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Network/trafficManagerGeographicHierarchies/default";


}
