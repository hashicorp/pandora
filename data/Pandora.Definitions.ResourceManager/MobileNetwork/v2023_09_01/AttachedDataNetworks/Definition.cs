using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.AttachedDataNetworks;

internal class Definition : ResourceDefinition
{
    public string Name => "AttachedDataNetworks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByPacketCoreDataPlaneOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(NaptEnabledConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AttachedDataNetworkModel),
        typeof(AttachedDataNetworkPropertiesFormatModel),
        typeof(InterfacePropertiesModel),
        typeof(NaptConfigurationModel),
        typeof(PinholeTimeoutsModel),
        typeof(PortRangeModel),
        typeof(PortReuseHoldTimesModel),
    };
}
