// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementConfigurationWindowsSettingApplicabilityWindowsSkusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("WindowsHome")]
    @windowsHome,

    [Description("WindowsProfessional")]
    @windowsProfessional,

    [Description("WindowsEnterprise")]
    @windowsEnterprise,

    [Description("WindowsEducation")]
    @windowsEducation,

    [Description("WindowsMobile")]
    @windowsMobile,

    [Description("WindowsMobileEnterprise")]
    @windowsMobileEnterprise,

    [Description("WindowsTeamSurface")]
    @windowsTeamSurface,

    [Description("Iot")]
    @iot,

    [Description("IotEnterprise")]
    @iotEnterprise,

    [Description("HoloLens")]
    @holoLens,

    [Description("HoloLensEnterprise")]
    @holoLensEnterprise,

    [Description("HolographicForBusiness")]
    @holographicForBusiness,

    [Description("WindowsMultiSession")]
    @windowsMultiSession,

    [Description("SurfaceHub")]
    @surfaceHub,
}
