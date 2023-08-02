// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationStrengthResultConstant
{
    [Description("NotSet")]
    @notSet,

    [Description("SkippedForProofUp")]
    @skippedForProofUp,

    [Description("Satisfied")]
    @satisfied,

    [Description("SingleChallengeRequired")]
    @singleChallengeRequired,

    [Description("MultipleChallengesRequired")]
    @multipleChallengesRequired,

    [Description("SingleRegistrationRequired")]
    @singleRegistrationRequired,

    [Description("MultipleRegistrationsRequired")]
    @multipleRegistrationsRequired,

    [Description("CannotSatisfyDueToCombinationConfiguration")]
    @cannotSatisfyDueToCombinationConfiguration,

    [Description("CannotSatisfy")]
    @cannotSatisfy,
}
