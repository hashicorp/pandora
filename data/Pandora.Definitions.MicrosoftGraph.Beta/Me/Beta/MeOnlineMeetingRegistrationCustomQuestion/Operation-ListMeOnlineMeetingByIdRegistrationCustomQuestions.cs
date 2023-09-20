// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOnlineMeetingRegistrationCustomQuestion;

internal class ListMeOnlineMeetingByIdRegistrationCustomQuestionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new MeOnlineMeetingId();
    public override Type NestedItemType() => typeof(MeetingRegistrationQuestionCollectionResponseModel);
    public override string? UriSuffix() => "/registration/customQuestions";
}
