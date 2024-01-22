// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BooleanEnumConstant
{
    [Description("FALSE")]
    FALSE,

    [Description("TRUE")]
    TRUE,
}
