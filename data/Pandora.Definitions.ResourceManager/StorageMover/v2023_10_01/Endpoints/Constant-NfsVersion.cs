// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageMover.v2023_10_01.Endpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NfsVersionConstant
{
    [Description("NFSauto")]
    NFSauto,

    [Description("NFSv4")]
    NFSvFour,

    [Description("NFSv3")]
    NFSvThree,
}
