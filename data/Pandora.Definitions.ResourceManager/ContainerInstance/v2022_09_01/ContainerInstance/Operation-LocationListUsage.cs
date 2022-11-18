using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2022_09_01.ContainerInstance;

internal class LocationListUsageOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new LocationId();

\t\tpublic override Type? ResponseObject() => typeof(UsageListResultModel);

\t\tpublic override string? UriSuffix() => "/usages";


}
