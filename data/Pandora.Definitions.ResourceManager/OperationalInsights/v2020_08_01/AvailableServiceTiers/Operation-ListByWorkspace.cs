using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.AvailableServiceTiers;

internal class ListByWorkspaceOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type? ResponseObject() => typeof(List<AvailableServiceTierModel>);

\t\tpublic override string? UriSuffix() => "/availableServiceTiers";


}
