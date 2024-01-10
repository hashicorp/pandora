// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserActivityHistoryItem;

internal class Definition : ResourceDefinition
{
    public string Name => "UserActivityHistoryItem";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdActivityByIdHistoryItemOperation(),
        new DeleteUserByIdActivityByIdHistoryItemByIdOperation(),
        new GetUserByIdActivityByIdHistoryItemByIdOperation(),
        new GetUserByIdActivityByIdHistoryItemCountOperation(),
        new ListUserByIdActivityByIdHistoryItemsOperation(),
        new UpdateUserByIdActivityByIdHistoryItemByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
