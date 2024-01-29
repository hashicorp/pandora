// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ContainerAppsRevisions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RevisionHealthStateConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("None")]
    None,

    [Description("Unhealthy")]
    Unhealthy,
}
