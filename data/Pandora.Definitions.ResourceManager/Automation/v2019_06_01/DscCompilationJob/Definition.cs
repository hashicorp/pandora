using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.DscCompilationJob;

internal class Definition : ResourceDefinition
{
    public string Name => "DscCompilationJob";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new GetOperation(),
        new GetStreamOperation(),
        new ListByAutomationAccountOperation(),
        new StreamListByJobOperation(),
    };
}
