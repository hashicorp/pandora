// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerKioskCustomizationSystemNavigationConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("NavigationEnabled")]
    @navigationEnabled,

    [Description("HomeButtonOnly")]
    @homeButtonOnly,
}
