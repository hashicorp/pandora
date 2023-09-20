// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ThreatAssessmentRequestRequestSourceConstant
{
    [Description("Undefined")]
    @undefined,

    [Description("User")]
    @user,

    [Description("Administrator")]
    @administrator,
}
