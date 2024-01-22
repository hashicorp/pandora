// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.DevBoxDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImageValidationStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,

    [Description("TimedOut")]
    TimedOut,

    [Description("Unknown")]
    Unknown,
}
