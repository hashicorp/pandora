// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsKioskDesktopAppAppTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Store")]
    @store,

    [Description("Desktop")]
    @desktop,

    [Description("AumId")]
    @aumId,
}
