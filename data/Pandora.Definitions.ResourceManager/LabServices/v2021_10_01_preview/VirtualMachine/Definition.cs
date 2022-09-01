using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.VirtualMachine;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachine";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new LabPlansSaveImageOperation(),
        new ListByLabOperation(),
        new RedeployOperation(),
        new ReimageOperation(),
        new ResetPasswordOperation(),
        new StartOperation(),
        new StopOperation(),
    };
}
