// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HardwareInformationDeviceLicensingStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("LicenseRefreshStarted")]
    @licenseRefreshStarted,

    [Description("LicenseRefreshPending")]
    @licenseRefreshPending,

    [Description("DeviceIsNotAzureActiveDirectoryJoined")]
    @deviceIsNotAzureActiveDirectoryJoined,

    [Description("VerifyingMicrosoftDeviceIdentity")]
    @verifyingMicrosoftDeviceIdentity,

    [Description("DeviceIdentityVerificationFailed")]
    @deviceIdentityVerificationFailed,

    [Description("VerifyingMicrosoftAccountIdentity")]
    @verifyingMicrosoftAccountIdentity,

    [Description("MicrosoftAccountVerificationFailed")]
    @microsoftAccountVerificationFailed,

    [Description("AcquiringDeviceLicense")]
    @acquiringDeviceLicense,

    [Description("RefreshingDeviceLicense")]
    @refreshingDeviceLicense,

    [Description("DeviceLicenseRefreshSucceed")]
    @deviceLicenseRefreshSucceed,

    [Description("DeviceLicenseRefreshFailed")]
    @deviceLicenseRefreshFailed,

    [Description("RemovingDeviceLicense")]
    @removingDeviceLicense,

    [Description("DeviceLicenseRemoveSucceed")]
    @deviceLicenseRemoveSucceed,

    [Description("DeviceLicenseRemoveFailed")]
    @deviceLicenseRemoveFailed,
}
