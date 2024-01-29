// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryApplicationVersions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfidentialVMEncryptionTypeConstant
{
    [Description("EncryptedVMGuestStateOnlyWithPmk")]
    EncryptedVMGuestStateOnlyWithPmk,

    [Description("EncryptedWithCmk")]
    EncryptedWithCmk,

    [Description("EncryptedWithPmk")]
    EncryptedWithPmk,
}
