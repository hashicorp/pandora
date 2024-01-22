// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.DeletedBackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidationTypeConstant
{
    [Description("DeepValidation")]
    DeepValidation,

    [Description("ShallowValidation")]
    ShallowValidation,
}
