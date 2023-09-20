// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementConfigurationWindowsSettingApplicabilityTechnologiesConstant
{
    [Description("None")]
    @none,

    [Description("Mdm")]
    @mdm,

    [Description("Windows10XManagement")]
    @windows10XManagement,

    [Description("ConfigManager")]
    @configManager,

    [Description("AppleRemoteManagement")]
    @appleRemoteManagement,

    [Description("MicrosoftSense")]
    @microsoftSense,

    [Description("ExchangeOnline")]
    @exchangeOnline,

    [Description("LinuxMdm")]
    @linuxMdm,

    [Description("Enrollment")]
    @enrollment,

    [Description("EndpointPrivilegeManagement")]
    @endpointPrivilegeManagement,
}
