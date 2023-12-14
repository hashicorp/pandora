// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActivityStatisticsActivityConstant
{
    [Description("Email")]
    @Email,

    [Description("Meeting")]
    @Meeting,

    [Description("Focus")]
    @Focus,

    [Description("Chat")]
    @Chat,

    [Description("Call")]
    @Call,
}
