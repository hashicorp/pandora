using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.UpdateSummaries;

internal class UpdateSummariesGetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ClusterId();

\t\tpublic override Type? ResponseObject() => typeof(UpdateSummariesModel);

\t\tpublic override string? UriSuffix() => "/updateSummaries/default";


}
