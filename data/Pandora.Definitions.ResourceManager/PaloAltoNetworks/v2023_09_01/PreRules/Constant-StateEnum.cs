// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.PreRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StateEnumConstant
{
    [Description("DISABLED")]
    DISABLED,

    [Description("ENABLED")]
    ENABLED,
}
