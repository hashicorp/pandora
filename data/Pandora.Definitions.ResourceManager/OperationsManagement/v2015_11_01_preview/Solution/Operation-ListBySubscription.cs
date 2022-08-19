using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationsManagement.v2015_11_01_preview.Solution;

internal class ListBySubscriptionOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(SolutionPropertiesListModel);

    public override string? UriSuffix() => "/providers/Microsoft.OperationsManagement/solutions";


}
