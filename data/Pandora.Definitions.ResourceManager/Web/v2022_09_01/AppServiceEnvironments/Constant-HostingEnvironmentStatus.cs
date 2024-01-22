// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostingEnvironmentStatusConstant
{
    [Description("Deleting")]
    Deleting,

    [Description("Preparing")]
    Preparing,

    [Description("Ready")]
    Ready,

    [Description("Scaling")]
    Scaling,
}
