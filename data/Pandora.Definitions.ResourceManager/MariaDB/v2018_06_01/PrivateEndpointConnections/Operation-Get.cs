using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.PrivateEndpointConnections;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new PrivateEndpointConnectionId();

\t\tpublic override Type? ResponseObject() => typeof(PrivateEndpointConnectionModel);


}
