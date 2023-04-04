using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.Extensions;

internal class Definition : ResourceDefinition
{
    public string Name => "Extensions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
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
