using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Addons;

internal class Definition : ResourceDefinition
{
    public string Name => "Addons";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByRoleOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AddonStateConstant),
        typeof(AddonTypeConstant),
        typeof(EncryptionAlgorithmConstant),
        typeof(HostPlatformTypeConstant),
        typeof(PlatformTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddonModel),
        typeof(ArcAddonModel),
        typeof(ArcAddonPropertiesModel),
        typeof(AsymmetricEncryptedSecretModel),
        typeof(AuthenticationModel),
        typeof(IoTAddonModel),
        typeof(IoTAddonPropertiesModel),
        typeof(IoTDeviceInfoModel),
        typeof(SymmetricKeyModel),
    };
}
