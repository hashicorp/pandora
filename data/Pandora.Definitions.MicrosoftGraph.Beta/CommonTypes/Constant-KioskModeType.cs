// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KioskModeTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("SingleAppMode")]
    @singleAppMode,

    [Description("MultiAppMode")]
    @multiAppMode,
}
