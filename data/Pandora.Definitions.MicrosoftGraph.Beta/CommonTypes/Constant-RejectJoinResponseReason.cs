// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RejectJoinResponseReasonConstant
{
    [Description("None")]
    @none,

    [Description("Busy")]
    @busy,

    [Description("Forbidden")]
    @forbidden,
}
