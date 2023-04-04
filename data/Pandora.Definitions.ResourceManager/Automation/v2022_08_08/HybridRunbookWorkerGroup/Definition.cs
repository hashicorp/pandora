using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.HybridRunbookWorkerGroup;

internal class Definition : ResourceDefinition
{
    public string Name => "HybridRunbookWorkerGroup";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
        new ListByAutomationAccountOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(GroupTypeEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(HybridRunbookWorkerGroupModel),
        typeof(HybridRunbookWorkerGroupCreateOrUpdateParametersModel),
        typeof(HybridRunbookWorkerGroupCreateOrUpdatePropertiesModel),
        typeof(HybridRunbookWorkerGroupPropertiesModel),
        typeof(RunAsCredentialAssociationPropertyModel),
    };
}
