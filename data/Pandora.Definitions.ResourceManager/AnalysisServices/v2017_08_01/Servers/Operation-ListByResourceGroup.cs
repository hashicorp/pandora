using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers;

internal class ListByResourceGroupOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type? ResponseObject() => typeof(AnalysisServicesServersModel);

    public override string? UriSuffix() => "/providers/Microsoft.AnalysisServices/servers";


}
