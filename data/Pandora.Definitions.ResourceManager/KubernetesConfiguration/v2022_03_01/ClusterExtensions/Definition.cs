using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.ClusterExtensions;

internal class Definition : ResourceDefinition
{
    public string Name => "ClusterExtensions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExtensionsCreateOperation(),
        new ExtensionsDeleteOperation(),
        new ExtensionsGetOperation(),
        new ExtensionsListOperation(),
        new ExtensionsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AKSIdentityTypeConstant),
        typeof(LevelTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(ExtensionModel),
        typeof(ExtensionPropertiesModel),
        typeof(ExtensionPropertiesAksAssignedIdentityModel),
        typeof(ExtensionStatusModel),
        typeof(PatchExtensionModel),
        typeof(PatchExtensionPropertiesModel),
        typeof(ScopeModel),
        typeof(ScopeClusterModel),
        typeof(ScopeNamespaceModel),
    };
}
