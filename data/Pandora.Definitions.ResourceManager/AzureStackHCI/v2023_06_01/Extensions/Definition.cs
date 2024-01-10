using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_06_01.Extensions;

internal class Definition : ResourceDefinition
{
    public string Name => "Extensions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByArcSettingOperation(),
        new UpdateOperation(),
        new UpgradeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExtensionAggregateStateConstant),
        typeof(ExtensionManagedByConstant),
        typeof(NodeExtensionStateConstant),
        typeof(ProvisioningStateConstant),
        typeof(StatusLevelTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExtensionModel),
        typeof(ExtensionInstanceViewModel),
        typeof(ExtensionInstanceViewStatusModel),
        typeof(ExtensionParametersModel),
        typeof(ExtensionPropertiesModel),
        typeof(ExtensionUpgradeParametersModel),
        typeof(PerNodeExtensionStateModel),
    };
}
