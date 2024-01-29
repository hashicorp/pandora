// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.ClusterVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterVersionsEnvironmentConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
