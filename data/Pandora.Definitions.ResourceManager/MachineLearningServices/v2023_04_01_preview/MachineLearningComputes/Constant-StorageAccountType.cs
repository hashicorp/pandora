// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.MachineLearningComputes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageAccountTypeConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("Standard_LRS")]
    StandardLRS,
}
