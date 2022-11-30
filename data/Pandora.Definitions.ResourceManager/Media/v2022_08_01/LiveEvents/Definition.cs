using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.LiveEvents;

internal class Definition : ResourceDefinition
{
    public string Name => "LiveEvents";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AllocateOperation(),
        new AsyncOperationOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new OperationLocationOperation(),
        new ResetOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
}
