using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LoadTestService.v2022_12_01.Quotas;

internal class Definition : ResourceDefinition
{
    public string Name => "Quotas";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckAvailabilityOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ResourceStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckQuotaAvailabilityResponseModel),
        typeof(CheckQuotaAvailabilityResponsePropertiesModel),
        typeof(QuotaBucketRequestModel),
        typeof(QuotaBucketRequestPropertiesModel),
        typeof(QuotaBucketRequestPropertiesDimensionsModel),
        typeof(QuotaResourceModel),
        typeof(QuotaResourcePropertiesModel),
    };
}
