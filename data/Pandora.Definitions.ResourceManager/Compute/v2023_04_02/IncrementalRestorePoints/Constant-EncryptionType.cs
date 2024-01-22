// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_04_02.IncrementalRestorePoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionTypeConstant
{
    [Description("EncryptionAtRestWithCustomerKey")]
    EncryptionAtRestWithCustomerKey,

    [Description("EncryptionAtRestWithPlatformAndCustomerKeys")]
    EncryptionAtRestWithPlatformAndCustomerKeys,

    [Description("EncryptionAtRestWithPlatformKey")]
    EncryptionAtRestWithPlatformKey,
}
