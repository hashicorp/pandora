using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01.Replicas;

internal class ListByServerOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ServerId();

\t\tpublic override Type? ResponseObject() => typeof(ServerListResultModel);

\t\tpublic override string? UriSuffix() => "/replicas";


}
