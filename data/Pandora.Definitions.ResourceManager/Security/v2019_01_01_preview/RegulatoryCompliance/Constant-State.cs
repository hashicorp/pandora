// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.RegulatoryCompliance;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Passed")]
    Passed,

    [Description("Skipped")]
    Skipped,

    [Description("Unsupported")]
    Unsupported,
}
