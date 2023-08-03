// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceEnrollmentTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("UserEnrollment")]
    @userEnrollment,

    [Description("DeviceEnrollmentManager")]
    @deviceEnrollmentManager,

    [Description("AppleBulkWithUser")]
    @appleBulkWithUser,

    [Description("AppleBulkWithoutUser")]
    @appleBulkWithoutUser,

    [Description("WindowsAzureADJoin")]
    @windowsAzureADJoin,

    [Description("WindowsBulkUserless")]
    @windowsBulkUserless,

    [Description("WindowsAutoEnrollment")]
    @windowsAutoEnrollment,

    [Description("WindowsBulkAzureDomainJoin")]
    @windowsBulkAzureDomainJoin,

    [Description("WindowsCoManagement")]
    @windowsCoManagement,

    [Description("WindowsAzureADJoinUsingDeviceAuth")]
    @windowsAzureADJoinUsingDeviceAuth,

    [Description("AppleUserEnrollment")]
    @appleUserEnrollment,

    [Description("AppleUserEnrollmentWithServiceAccount")]
    @appleUserEnrollmentWithServiceAccount,
}
