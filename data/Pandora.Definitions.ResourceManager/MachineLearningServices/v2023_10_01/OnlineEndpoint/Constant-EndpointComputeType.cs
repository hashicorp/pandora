// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.OnlineEndpoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointComputeTypeConstant
{
    [Description("AzureMLCompute")]
    AzureMLCompute,

    [Description("Kubernetes")]
    Kubernetes,

    [Description("Managed")]
    Managed,
}
