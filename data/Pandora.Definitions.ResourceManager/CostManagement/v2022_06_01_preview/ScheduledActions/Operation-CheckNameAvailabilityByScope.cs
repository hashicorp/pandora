using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_06_01_preview.ScheduledActions;

internal class CheckNameAvailabilityByScopeOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CheckNameAvailabilityRequestModel);

    public override ResourceID? ResourceId() => new ScopeId();

    public override Type? ResponseObject() => typeof(CheckNameAvailabilityResponseModel);

    public override string? UriSuffix() => "/providers/Microsoft.CostManagement/checkNameAvailability";


}
