using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.ListKeys;

internal class Definition : ResourceDefinition
{
    public string Name => "ListKeys";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new KeysListByAutomationAccountOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AutomationKeyNameConstant),
        typeof(AutomationKeyPermissionsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(KeyModel),
        typeof(KeyListResultModel),
    };
}
