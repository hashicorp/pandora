// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.Addons;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostPlatformTypeConstant
{
    [Description("KubernetesCluster")]
    KubernetesCluster,

    [Description("LinuxVM")]
    LinuxVM,
}
