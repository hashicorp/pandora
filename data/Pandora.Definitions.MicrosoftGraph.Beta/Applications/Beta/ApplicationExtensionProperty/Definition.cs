// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationExtensionProperty;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationExtensionProperty";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateApplicationByIdExtensionPropertyOperation(),
        new DeleteApplicationByIdExtensionPropertyByIdOperation(),
        new GetApplicationByIdExtensionPropertyByIdOperation(),
        new GetApplicationByIdExtensionPropertyCountOperation(),
        new ListApplicationByIdExtensionPropertiesOperation(),
        new UpdateApplicationByIdExtensionPropertyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
