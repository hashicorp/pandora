using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.WebHooks;

internal class Definition : ResourceDefinition
{
    public string Name => "WebHooks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetCallbackConfigOperation(),
        new ListOperation(),
        new ListEventsOperation(),
        new PingOperation(),
        new UpdateOperation(),
    };
}
