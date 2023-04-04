using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.Module;

internal class Definition : ResourceDefinition
{
    public string Name => "Module";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAutomationAccountOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ModuleProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContentHashModel),
        typeof(ContentLinkModel),
        typeof(ModuleModel),
        typeof(ModuleCreateOrUpdateParametersModel),
        typeof(ModuleCreateOrUpdatePropertiesModel),
        typeof(ModuleErrorInfoModel),
        typeof(ModulePropertiesModel),
        typeof(ModuleUpdateParametersModel),
        typeof(ModuleUpdatePropertiesModel),
    };
}
