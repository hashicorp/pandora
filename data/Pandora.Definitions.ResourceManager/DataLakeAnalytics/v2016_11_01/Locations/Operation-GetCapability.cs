using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Locations;

internal class GetCapabilityOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new LocationId();

\t\tpublic override Type? ResponseObject() => typeof(CapabilityInformationModel);

\t\tpublic override string? UriSuffix() => "/capability";


}
