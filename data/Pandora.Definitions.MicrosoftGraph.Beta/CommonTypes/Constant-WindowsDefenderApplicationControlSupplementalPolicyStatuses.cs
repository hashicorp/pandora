// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsDefenderApplicationControlSupplementalPolicyStatusesConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Success")]
    @success,

    [Description("TokenError")]
    @tokenError,

    [Description("NotAuthorizedByToken")]
    @notAuthorizedByToken,

    [Description("PolicyNotFound")]
    @policyNotFound,
}
