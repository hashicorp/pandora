// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.GlobalRulestack;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdvSecurityObjectTypeEnumConstant
{
    [Description("feeds")]
    Feeds,

    [Description("urlCustom")]
    UrlCustom,
}
