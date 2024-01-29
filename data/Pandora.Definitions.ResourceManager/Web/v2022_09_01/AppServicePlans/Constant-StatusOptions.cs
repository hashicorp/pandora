// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServicePlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusOptionsConstant
{
    [Description("Creating")]
    Creating,

    [Description("Pending")]
    Pending,

    [Description("Ready")]
    Ready,
}
