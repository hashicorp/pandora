using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_04_01.RecoveryServices;

internal class Definition : ResourceDefinition
{
    public string Name => "RecoveryServices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CapabilitiesOperation(),
        new CheckNameAvailabilityOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(VaultSubResourceTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CapabilitiesPropertiesModel),
        typeof(CapabilitiesResponseModel),
        typeof(CapabilitiesResponsePropertiesModel),
        typeof(CheckNameAvailabilityParametersModel),
        typeof(CheckNameAvailabilityResultModel),
        typeof(DNSZoneModel),
        typeof(DNSZoneResponseModel),
        typeof(ResourceCapabilitiesModel),
    };
}
