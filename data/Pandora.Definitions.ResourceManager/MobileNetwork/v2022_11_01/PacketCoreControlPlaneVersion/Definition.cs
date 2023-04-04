using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlaneVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "PacketCoreControlPlaneVersion";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ObsoleteVersionConstant),
        typeof(PlatformTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(RecommendedVersionConstant),
        typeof(VersionStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PacketCoreControlPlaneVersionModel),
        typeof(PacketCoreControlPlaneVersionPropertiesFormatModel),
        typeof(PlatformModel),
    };
}
