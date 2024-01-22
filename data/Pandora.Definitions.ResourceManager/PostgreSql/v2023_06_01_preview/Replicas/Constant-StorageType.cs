// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTypeConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("PremiumV2_LRS")]
    PremiumVTwoLRS,
}
