using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.EdgeModules;

internal class Definition : ResourceDefinition
{
    public string Name => "EdgeModules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new EdgeModulesCreateOrUpdateOperation(),
        new EdgeModulesDeleteOperation(),
        new EdgeModulesGetOperation(),
        new EdgeModulesListOperation(),
        new EdgeModulesListProvisioningTokenOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EdgeModuleEntityModel),
        typeof(EdgeModulePropertiesModel),
        typeof(EdgeModuleProvisioningTokenModel),
        typeof(ListProvisioningTokenInputModel),
    };
}
