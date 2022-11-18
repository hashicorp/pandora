using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.DataConnections;

internal class ListByDatabaseOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new DatabaseId();

\t\tpublic override Type? ResponseObject() => typeof(DataConnectionListResultModel);

\t\tpublic override string? UriSuffix() => "/dataConnections";


}
