// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationConnectorGroup;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationConnectorGroup";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateApplicationConnectorGroupOperation(),
        new GetApplicationConnectorGroupOperation(),
        new GetConnectorGroupOperation(),
        new RemoveApplicationConnectorGroupOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUpdateApplicationConnectorGroupRequestModel)
    };
}
