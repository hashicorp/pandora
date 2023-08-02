using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2023_06_07.Skus;

internal class Definition : ResourceDefinition
{
    public string Name => "Skus";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LabServicesSkuTierConstant),
        typeof(RestrictionReasonCodeConstant),
        typeof(RestrictionTypeConstant),
        typeof(ScaleTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LabServicesSkuModel),
        typeof(LabServicesSkuCapabilitiesModel),
        typeof(LabServicesSkuCapacityModel),
        typeof(LabServicesSkuCostModel),
        typeof(LabServicesSkuRestrictionsModel),
    };
}
