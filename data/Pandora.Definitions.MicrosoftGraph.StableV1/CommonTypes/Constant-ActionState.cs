// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionStateConstant
{
    [Description("None")]
    @none,

    [Description("Pending")]
    @pending,

    [Description("Canceled")]
    @canceled,

    [Description("Active")]
    @active,

    [Description("Done")]
    @done,

    [Description("Failed")]
    @failed,

    [Description("NotSupported")]
    @notSupported,
}
