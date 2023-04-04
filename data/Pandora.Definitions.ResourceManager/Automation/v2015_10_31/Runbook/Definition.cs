using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Runbook;

internal class Definition : ResourceDefinition
{
    public string Name => "Runbook";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetContentOperation(),
        new ListByAutomationAccountOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RunbookProvisioningStateConstant),
        typeof(RunbookStateConstant),
        typeof(RunbookTypeEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContentHashModel),
        typeof(ContentLinkModel),
        typeof(RunbookModel),
        typeof(RunbookCreateOrUpdateParametersModel),
        typeof(RunbookCreateOrUpdatePropertiesModel),
        typeof(RunbookDraftModel),
        typeof(RunbookParameterModel),
        typeof(RunbookPropertiesModel),
        typeof(RunbookUpdateParametersModel),
        typeof(RunbookUpdatePropertiesModel),
    };
}
