// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Links;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidationResultStatusConstant
{
    [Description("failure")]
    Failure,

    [Description("success")]
    Success,

    [Description("warning")]
    Warning,
}
