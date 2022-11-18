using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.V2WorkspaceConnectionResource;

internal class WorkspaceConnectionsGetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ConnectionId();

\t\tpublic override Type? ResponseObject() => typeof(WorkspaceConnectionPropertiesV2BasicResourceModel);


}
