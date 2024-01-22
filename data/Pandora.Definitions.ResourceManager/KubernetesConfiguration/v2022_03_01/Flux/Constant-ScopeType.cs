// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.Flux;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScopeTypeConstant
{
    [Description("cluster")]
    Cluster,

    [Description("namespace")]
    Namespace,
}
