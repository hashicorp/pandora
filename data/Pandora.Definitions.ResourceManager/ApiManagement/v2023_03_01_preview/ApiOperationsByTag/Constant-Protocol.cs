// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiOperationsByTag;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtocolConstant
{
    [Description("http")]
    HTTP,

    [Description("https")]
    HTTPS,

    [Description("ws")]
    Ws,

    [Description("wss")]
    Wss,
}
