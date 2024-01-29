// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Api;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SoapApiTypeConstant
{
    [Description("graphql")]
    Graphql,

    [Description("http")]
    HTTP,

    [Description("odata")]
    Odata,

    [Description("soap")]
    Soap,

    [Description("websocket")]
    Websocket,
}
