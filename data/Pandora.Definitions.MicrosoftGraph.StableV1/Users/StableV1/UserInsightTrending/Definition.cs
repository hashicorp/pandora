// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserInsightTrending;

internal class Definition : ResourceDefinition
{
    public string Name => "UserInsightTrending";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdInsightTrendingOperation(),
        new DeleteUserByIdInsightTrendingByIdOperation(),
        new GetUserByIdInsightTrendingByIdOperation(),
        new GetUserByIdInsightTrendingCountOperation(),
        new ListUserByIdInsightTrendingsOperation(),
        new UpdateUserByIdInsightTrendingByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
