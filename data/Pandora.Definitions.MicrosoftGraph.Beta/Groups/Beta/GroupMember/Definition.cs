// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupMember;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupMember";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddGroupByIdMemberRefOperation(),
        new GetGroupByIdMemberCountOperation(),
        new ListGroupByIdMemberRefsOperation(),
        new ListGroupByIdMembersOperation(),
        new RemoveGroupByIdMemberByIdRefOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
