// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnenoteSectionGroup;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOnenoteSectionGroup";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOnenoteSectionGroupOperation(),
        new DeleteUserByIdOnenoteSectionGroupByIdOperation(),
        new GetUserByIdOnenoteSectionGroupByIdOperation(),
        new GetUserByIdOnenoteSectionGroupCountOperation(),
        new ListUserByIdOnenoteSectionGroupsOperation(),
        new UpdateUserByIdOnenoteSectionGroupByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
