using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.IncrementalRestorePoints;

internal class Definition : ResourceDefinition
{
    public string Name => "IncrementalRestorePoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DiskRestorePointGetOperation(),
        new DiskRestorePointGrantAccessOperation(),
        new DiskRestorePointListByRestorePointOperation(),
        new DiskRestorePointRevokeAccessOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessLevelConstant),
        typeof(ArchitectureConstant),
        typeof(DiskSecurityTypesConstant),
        typeof(EncryptionTypeConstant),
        typeof(HyperVGenerationConstant),
        typeof(NetworkAccessPolicyConstant),
        typeof(OperatingSystemTypesConstant),
        typeof(PublicNetworkAccessConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessUriModel),
        typeof(DiskRestorePointModel),
        typeof(DiskRestorePointPropertiesModel),
        typeof(DiskSecurityProfileModel),
        typeof(EncryptionModel),
        typeof(GrantAccessDataModel),
        typeof(PurchasePlanModel),
        typeof(SupportedCapabilitiesModel),
    };
}
