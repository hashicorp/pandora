using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2023_06_01.WorkbooksAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkbooksAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new WorkbooksCreateOrUpdateOperation(),
        new WorkbooksDeleteOperation(),
        new WorkbooksGetOperation(),
        new WorkbooksListByResourceGroupOperation(),
        new WorkbooksListBySubscriptionOperation(),
        new WorkbooksRevisionGetOperation(),
        new WorkbooksRevisionsListOperation(),
        new WorkbooksUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CategoryTypeConstant),
        typeof(WorkbookSharedTypeKindConstant),
        typeof(WorkbookUpdateSharedTypeKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(WorkbookModel),
        typeof(WorkbookPropertiesModel),
        typeof(WorkbookPropertiesUpdateParametersModel),
        typeof(WorkbookUpdateParametersModel),
    };
}
