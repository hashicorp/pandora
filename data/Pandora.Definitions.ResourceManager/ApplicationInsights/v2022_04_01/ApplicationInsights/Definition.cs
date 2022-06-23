using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.ApplicationInsights;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationInsights";
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
}
