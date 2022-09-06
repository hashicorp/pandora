using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2020_11_20.WorkbookTemplatesAPIS;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkbookTemplatesAPIS";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new WorkbookTemplatesCreateOrUpdateOperation(),
        new WorkbookTemplatesDeleteOperation(),
        new WorkbookTemplatesGetOperation(),
        new WorkbookTemplatesListByResourceGroupOperation(),
        new WorkbookTemplatesUpdateOperation(),
    };
}
