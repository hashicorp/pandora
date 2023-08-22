using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.CostAllocationRules;

internal class CheckNameAvailabilityOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CostAllocationRuleCheckNameAvailabilityRequestModel);

    public override ResourceID? ResourceId() => new BillingAccountId();

    public override Type? ResponseObject() => typeof(CostAllocationRuleCheckNameAvailabilityResponseModel);

    public override string? UriSuffix() => "/providers/Microsoft.CostManagement/costAllocationRules/checkNameAvailability";


}
