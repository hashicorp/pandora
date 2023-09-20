// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookTaskGroup;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOutlookTaskGroup";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOutlookTaskGroupOperation(),
        new DeleteMeOutlookTaskGroupByIdOperation(),
        new GetMeOutlookTaskGroupByIdOperation(),
        new GetMeOutlookTaskGroupCountOperation(),
        new ListMeOutlookTaskGroupsOperation(),
        new UpdateMeOutlookTaskGroupByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
