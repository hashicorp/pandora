// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceEnrollmentConfigurationDeviceEnrollmentConfigurationTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Limit")]
    @limit,

    [Description("PlatformRestrictions")]
    @platformRestrictions,

    [Description("WindowsHelloForBusiness")]
    @windowsHelloForBusiness,

    [Description("DefaultLimit")]
    @defaultLimit,

    [Description("DefaultPlatformRestrictions")]
    @defaultPlatformRestrictions,

    [Description("DefaultWindowsHelloForBusiness")]
    @defaultWindowsHelloForBusiness,

    [Description("DefaultWindows10EnrollmentCompletionPageConfiguration")]
    @defaultWindows10EnrollmentCompletionPageConfiguration,

    [Description("Windows10EnrollmentCompletionPageConfiguration")]
    @windows10EnrollmentCompletionPageConfiguration,

    [Description("DeviceComanagementAuthorityConfiguration")]
    @deviceComanagementAuthorityConfiguration,

    [Description("SinglePlatformRestriction")]
    @singlePlatformRestriction,

    [Description("EnrollmentNotificationsConfiguration")]
    @enrollmentNotificationsConfiguration,
}
