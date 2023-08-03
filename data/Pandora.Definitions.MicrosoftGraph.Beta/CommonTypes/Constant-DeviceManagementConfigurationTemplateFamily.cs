// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementConfigurationTemplateFamilyConstant
{
    [Description("None")]
    @none,

    [Description("EndpointSecurityAntivirus")]
    @endpointSecurityAntivirus,

    [Description("EndpointSecurityDiskEncryption")]
    @endpointSecurityDiskEncryption,

    [Description("EndpointSecurityFirewall")]
    @endpointSecurityFirewall,

    [Description("EndpointSecurityEndpointDetectionAndResponse")]
    @endpointSecurityEndpointDetectionAndResponse,

    [Description("EndpointSecurityAttackSurfaceReduction")]
    @endpointSecurityAttackSurfaceReduction,

    [Description("EndpointSecurityAccountProtection")]
    @endpointSecurityAccountProtection,

    [Description("EndpointSecurityApplicationControl")]
    @endpointSecurityApplicationControl,

    [Description("EndpointSecurityEndpointPrivilegeManagement")]
    @endpointSecurityEndpointPrivilegeManagement,

    [Description("EnrollmentConfiguration")]
    @enrollmentConfiguration,

    [Description("AppQuietTime")]
    @appQuietTime,

    [Description("Baseline")]
    @baseline,

    [Description("DeviceConfigurationScripts")]
    @deviceConfigurationScripts,
}
