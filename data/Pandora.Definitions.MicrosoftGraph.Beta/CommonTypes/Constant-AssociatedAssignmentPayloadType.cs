// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssociatedAssignmentPayloadTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("DeviceConfigurationAndCompliance")]
    @deviceConfigurationAndCompliance,

    [Description("Application")]
    @application,

    [Description("AndroidEnterpriseApp")]
    @androidEnterpriseApp,

    [Description("EnrollmentConfiguration")]
    @enrollmentConfiguration,

    [Description("GroupPolicyConfiguration")]
    @groupPolicyConfiguration,

    [Description("ZeroTouchDeploymentDeviceConfigProfile")]
    @zeroTouchDeploymentDeviceConfigProfile,

    [Description("AndroidEnterpriseConfiguration")]
    @androidEnterpriseConfiguration,

    [Description("DeviceFirmwareConfigurationInterfacePolicy")]
    @deviceFirmwareConfigurationInterfacePolicy,

    [Description("ResourceAccessPolicy")]
    @resourceAccessPolicy,

    [Description("Win32app")]
    @win32app,

    [Description("DeviceManagmentConfigurationAndCompliancePolicy")]
    @deviceManagmentConfigurationAndCompliancePolicy,
}
