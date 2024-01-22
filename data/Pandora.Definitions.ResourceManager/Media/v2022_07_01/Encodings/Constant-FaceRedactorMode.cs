// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_07_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FaceRedactorModeConstant
{
    [Description("Analyze")]
    Analyze,

    [Description("Combined")]
    Combined,

    [Description("Redact")]
    Redact,
}
