// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserAnalyticActivityStatistic;

internal class Definition : ResourceDefinition
{
    public string Name => "UserAnalyticActivityStatistic";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdAnalyticActivityStatisticOperation(),
        new DeleteUserByIdAnalyticActivityStatisticByIdOperation(),
        new GetUserByIdAnalyticActivityStatisticByIdOperation(),
        new GetUserByIdAnalyticActivityStatisticCountOperation(),
        new ListUserByIdAnalyticActivityStatisticsOperation(),
        new UpdateUserByIdAnalyticActivityStatisticByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
