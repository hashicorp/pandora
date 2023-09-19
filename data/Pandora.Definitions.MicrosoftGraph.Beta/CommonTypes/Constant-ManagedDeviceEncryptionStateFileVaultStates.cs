// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDeviceEncryptionStateFileVaultStatesConstant
{
    [Description("Success")]
    @success,

    [Description("DriveEncryptedByUser")]
    @driveEncryptedByUser,

    [Description("UserDeferredEncryption")]
    @userDeferredEncryption,

    [Description("EscrowNotEnabled")]
    @escrowNotEnabled,
}
