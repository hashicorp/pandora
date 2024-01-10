// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingRegistrationCustomQuestion;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOnlineMeetingRegistrationCustomQuestion";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOnlineMeetingByIdRegistrationCustomQuestionOperation(),
        new DeleteMeOnlineMeetingByIdRegistrationCustomQuestionByIdOperation(),
        new GetMeOnlineMeetingByIdRegistrationCustomQuestionByIdOperation(),
        new GetMeOnlineMeetingByIdRegistrationCustomQuestionCountOperation(),
        new ListMeOnlineMeetingByIdRegistrationCustomQuestionsOperation(),
        new UpdateMeOnlineMeetingByIdRegistrationCustomQuestionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
