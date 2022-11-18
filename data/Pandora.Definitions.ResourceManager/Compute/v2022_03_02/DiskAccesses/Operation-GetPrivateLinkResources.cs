using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.DiskAccesses;

internal class GetPrivateLinkResourcesOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new DiskAccessId();

\t\tpublic override Type? ResponseObject() => typeof(PrivateLinkResourceListResultModel);

\t\tpublic override string? UriSuffix() => "/privateLinkResources";


}
