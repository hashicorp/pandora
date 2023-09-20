// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10GeneralConfigurationEdgeKioskModeRestrictionConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("DigitalSignage")]
    @digitalSignage,

    [Description("NormalMode")]
    @normalMode,

    [Description("PublicBrowsingSingleApp")]
    @publicBrowsingSingleApp,

    [Description("PublicBrowsingMultiApp")]
    @publicBrowsingMultiApp,
}
