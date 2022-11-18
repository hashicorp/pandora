using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.Clusters;

internal class ListByResourceGroupOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type? ResponseObject() => typeof(ClusterListResultModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Kusto/clusters";


}
