// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosUpdatesInstallStatusConstant
{
    [Description("UpdateScanFailed")]
    @updateScanFailed,

    [Description("DeviceOsHigherThanDesiredOsVersion")]
    @deviceOsHigherThanDesiredOsVersion,

    [Description("UpdateError")]
    @updateError,

    [Description("SharedDeviceUserLoggedInError")]
    @sharedDeviceUserLoggedInError,

    [Description("NotSupportedOperation")]
    @notSupportedOperation,

    [Description("InstallFailed")]
    @installFailed,

    [Description("InstallPhoneCallInProgress")]
    @installPhoneCallInProgress,

    [Description("InstallInsufficientPower")]
    @installInsufficientPower,

    [Description("InstallInsufficientSpace")]
    @installInsufficientSpace,

    [Description("Installing")]
    @installing,

    [Description("DownloadInsufficientNetwork")]
    @downloadInsufficientNetwork,

    [Description("DownloadInsufficientPower")]
    @downloadInsufficientPower,

    [Description("DownloadInsufficientSpace")]
    @downloadInsufficientSpace,

    [Description("DownloadRequiresComputer")]
    @downloadRequiresComputer,

    [Description("DownloadFailed")]
    @downloadFailed,

    [Description("Downloading")]
    @downloading,

    [Description("Timeout")]
    @timeout,

    [Description("MdmClientCrashed")]
    @mdmClientCrashed,

    [Description("Success")]
    @success,

    [Description("Available")]
    @available,

    [Description("Idle")]
    @idle,

    [Description("Unknown")]
    @unknown,
}
