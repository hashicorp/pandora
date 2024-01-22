// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2022_04_01.Endpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointTypeConstant
{
    [Description("AzureEndpoints")]
    AzureEndpoints,

    [Description("ExternalEndpoints")]
    ExternalEndpoints,

    [Description("NestedEndpoints")]
    NestedEndpoints,
}
