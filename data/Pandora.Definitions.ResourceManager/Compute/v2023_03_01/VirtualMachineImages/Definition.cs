using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineImages;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineImages";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new EdgeZoneGetOperation(),
        new EdgeZoneListOperation(),
        new EdgeZoneListOffersOperation(),
        new EdgeZoneListPublishersOperation(),
        new EdgeZoneListSkusOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByEdgeZoneOperation(),
        new ListOffersOperation(),
        new ListPublishersOperation(),
        new ListSkusOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlternativeTypeConstant),
        typeof(ArchitectureTypesConstant),
        typeof(HyperVGenerationTypesConstant),
        typeof(ImageStateConstant),
        typeof(OperatingSystemTypesConstant),
        typeof(VMDiskTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AlternativeOptionModel),
        typeof(AutomaticOSUpgradePropertiesModel),
        typeof(DataDiskImageModel),
        typeof(DisallowedConfigurationModel),
        typeof(ImageDeprecationStatusModel),
        typeof(OSDiskImageModel),
        typeof(PurchasePlanModel),
        typeof(VMImagesInEdgeZoneListResultModel),
        typeof(VirtualMachineImageModel),
        typeof(VirtualMachineImageFeatureModel),
        typeof(VirtualMachineImagePropertiesModel),
        typeof(VirtualMachineImageResourceModel),
    };
}
