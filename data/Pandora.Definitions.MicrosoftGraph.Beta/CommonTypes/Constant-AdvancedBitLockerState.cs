// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdvancedBitLockerStateConstant
{
    [Description("Success")]
    @success,

    [Description("NoUserConsent")]
    @noUserConsent,

    [Description("OsVolumeUnprotected")]
    @osVolumeUnprotected,

    [Description("OsVolumeTpmRequired")]
    @osVolumeTpmRequired,

    [Description("OsVolumeTpmOnlyRequired")]
    @osVolumeTpmOnlyRequired,

    [Description("OsVolumeTpmPinRequired")]
    @osVolumeTpmPinRequired,

    [Description("OsVolumeTpmStartupKeyRequired")]
    @osVolumeTpmStartupKeyRequired,

    [Description("OsVolumeTpmPinStartupKeyRequired")]
    @osVolumeTpmPinStartupKeyRequired,

    [Description("OsVolumeEncryptionMethodMismatch")]
    @osVolumeEncryptionMethodMismatch,

    [Description("RecoveryKeyBackupFailed")]
    @recoveryKeyBackupFailed,

    [Description("FixedDriveNotEncrypted")]
    @fixedDriveNotEncrypted,

    [Description("FixedDriveEncryptionMethodMismatch")]
    @fixedDriveEncryptionMethodMismatch,

    [Description("LoggedOnUserNonAdmin")]
    @loggedOnUserNonAdmin,

    [Description("WindowsRecoveryEnvironmentNotConfigured")]
    @windowsRecoveryEnvironmentNotConfigured,

    [Description("TpmNotAvailable")]
    @tpmNotAvailable,

    [Description("TpmNotReady")]
    @tpmNotReady,

    [Description("NetworkError")]
    @networkError,
}
