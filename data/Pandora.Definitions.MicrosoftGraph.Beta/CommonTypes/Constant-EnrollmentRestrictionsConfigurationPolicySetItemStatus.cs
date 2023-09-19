// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnrollmentRestrictionsConfigurationPolicySetItemStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Validating")]
    @validating,

    [Description("PartialSuccess")]
    @partialSuccess,

    [Description("Success")]
    @success,

    [Description("Error")]
    @error,

    [Description("NotAssigned")]
    @notAssigned,
}
