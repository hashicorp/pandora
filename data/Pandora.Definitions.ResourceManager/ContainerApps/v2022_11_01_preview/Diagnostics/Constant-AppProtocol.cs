// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppProtocolConstant
{
    [Description("grpc")]
    Grpc,

    [Description("http")]
    HTTP,
}
