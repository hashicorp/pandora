// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDeviceDeviceEnrollmentTypeConstant
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

    [Description("AzureAdJoinUsingAzureVmExtension")]
    @azureAdJoinUsingAzureVmExtension,

    [Description("AndroidEnterpriseDedicatedDevice")]
    @androidEnterpriseDedicatedDevice,

    [Description("AndroidEnterpriseFullyManaged")]
    @androidEnterpriseFullyManaged,

    [Description("AndroidEnterpriseCorporateWorkProfile")]
    @androidEnterpriseCorporateWorkProfile,
}
