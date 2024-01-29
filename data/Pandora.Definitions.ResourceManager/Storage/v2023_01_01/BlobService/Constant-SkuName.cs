// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.BlobService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("Premium_ZRS")]
    PremiumZRS,

    [Description("Standard_GRS")]
    StandardGRS,

    [Description("Standard_GZRS")]
    StandardGZRS,

    [Description("Standard_LRS")]
    StandardLRS,

    [Description("Standard_RAGRS")]
    StandardRAGRS,

    [Description("Standard_RAGZRS")]
    StandardRAGZRS,

    [Description("Standard_ZRS")]
    StandardZRS,
}
