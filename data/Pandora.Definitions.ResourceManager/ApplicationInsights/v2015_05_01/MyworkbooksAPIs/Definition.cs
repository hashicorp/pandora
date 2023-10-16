using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.MyworkbooksAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "MyworkbooksAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MyWorkbooksCreateOrUpdateOperation(),
        new MyWorkbooksDeleteOperation(),
        new MyWorkbooksGetOperation(),
        new MyWorkbooksListByResourceGroupOperation(),
        new MyWorkbooksListBySubscriptionOperation(),
        new MyWorkbooksUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CategoryTypeConstant),
        typeof(SharedTypeKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MyWorkbookModel),
        typeof(MyWorkbookPropertiesModel),
        typeof(MyWorkbooksListResultModel),
    };
}
