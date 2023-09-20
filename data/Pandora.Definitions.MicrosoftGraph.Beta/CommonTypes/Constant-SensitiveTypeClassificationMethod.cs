// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SensitiveTypeClassificationMethodConstant
{
    [Description("PatternMatch")]
    @patternMatch,

    [Description("ExactDataMatch")]
    @exactDataMatch,

    [Description("Fingerprint")]
    @fingerprint,

    [Description("MachineLearning")]
    @machineLearning,
}
