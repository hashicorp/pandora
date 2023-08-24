using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.Settings;

internal class Definition : ResourceDefinition
{
    public string Name => "Settings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateByScopeOperation(),
        new DeleteByScopeOperation(),
        new GetByScopeOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SettingsKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SettingModel),
        typeof(SettingsListResultModel),
        typeof(TagInheritancePropertiesModel),
        typeof(TagInheritanceSettingModel),
    };
}
