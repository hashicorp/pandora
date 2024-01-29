// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

﻿using System.ComponentModel;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuTier
{
    [Description("A0")]
    A0
}