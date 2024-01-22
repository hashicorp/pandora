// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2021_06_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BillingTypeConstant
{
    [Description("Cluster")]
    Cluster,

    [Description("Workspaces")]
    Workspaces,
}
