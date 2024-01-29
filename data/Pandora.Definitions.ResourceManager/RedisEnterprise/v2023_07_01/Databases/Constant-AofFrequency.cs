// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_07_01.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AofFrequencyConstant
{
    [Description("always")]
    Always,

    [Description("1s")]
    Ones,
}
