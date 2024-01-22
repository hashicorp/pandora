// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.BlobService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AllowedMethodsConstant
{
    [Description("CONNECT")]
    CONNECT,

    [Description("DELETE")]
    DELETE,

    [Description("GET")]
    GET,

    [Description("HEAD")]
    HEAD,

    [Description("MERGE")]
    MERGE,

    [Description("OPTIONS")]
    OPTIONS,

    [Description("PATCH")]
    PATCH,

    [Description("POST")]
    POST,

    [Description("PUT")]
    PUT,

    [Description("TRACE")]
    TRACE,
}
