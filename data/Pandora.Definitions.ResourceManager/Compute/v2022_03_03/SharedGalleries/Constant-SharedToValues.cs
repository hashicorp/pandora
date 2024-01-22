// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.SharedGalleries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharedToValuesConstant
{
    [Description("tenant")]
    Tenant,
}
