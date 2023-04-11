using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.IoTSecuritySolutionsAnalytics;

internal class IoTSecuritySolutionsAnalyticsGetAllOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new IotSecuritySolutionId();

    public override Type? ResponseObject() => typeof(IoTSecuritySolutionAnalyticsModelListModel);

    public override string? UriSuffix() => "/analyticsModels";


}
