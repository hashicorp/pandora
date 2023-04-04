using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_12_01.Extensions;

internal class Definition : ResourceDefinition
{
    public string Name => "Extensions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExtensionsCreateOperation(),
        new ExtensionsDeleteOperation(),
        new ExtensionsGetOperation(),
        new ExtensionsListByArcSettingOperation(),
        new ExtensionsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExtensionAggregateStateConstant),
        typeof(NodeExtensionStateConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExtensionModel),
        typeof(ExtensionParametersModel),
        typeof(ExtensionPropertiesModel),
        typeof(PerNodeExtensionStateModel),
    };
}
