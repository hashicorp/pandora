// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusteringPolicyConstant
{
    [Description("EnterpriseCluster")]
    EnterpriseCluster,

    [Description("OSSCluster")]
    OSSCluster,
}
