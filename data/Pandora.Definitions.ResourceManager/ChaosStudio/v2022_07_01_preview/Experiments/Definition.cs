using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview.Experiments;

internal class Definition : ResourceDefinition
{
    public string Name => "Experiments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetExecutionDetailsOperation(),
        new GetStatusOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListAllStatusesOperation(),
        new ListExecutionDetailsOperation(),
        new StartOperation(),
    };
}
