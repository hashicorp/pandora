// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationOwner;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationOwner";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddApplicationOwnerOperation(),
        new GetApplicationOwnersCountOperation(),
        new GetCountOperation(),
        new ListOwnersOperation(),
        new RemoveApplicationOwnerOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddApplicationOwnerRequestModel)
    };
}
