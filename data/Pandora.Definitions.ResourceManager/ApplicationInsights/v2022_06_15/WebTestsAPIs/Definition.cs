using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_06_15.WebTestsAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "WebTestsAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new WebTestsCreateOrUpdateOperation(),
        new WebTestsDeleteOperation(),
        new WebTestsGetOperation(),
        new WebTestsListOperation(),
        new WebTestsListByComponentOperation(),
        new WebTestsListByResourceGroupOperation(),
        new WebTestsUpdateTagsOperation(),
    };
}
