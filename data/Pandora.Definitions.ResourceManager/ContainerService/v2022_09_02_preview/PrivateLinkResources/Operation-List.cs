using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.PrivateLinkResources;

internal class ListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ManagedClusterId();

\t\tpublic override Type? ResponseObject() => typeof(PrivateLinkResourcesListResultModel);

\t\tpublic override string? UriSuffix() => "/privateLinkResources";


}
