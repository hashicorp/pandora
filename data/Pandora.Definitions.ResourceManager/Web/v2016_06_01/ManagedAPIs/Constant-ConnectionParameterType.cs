// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionParameterTypeConstant
{
    [Description("array")]
    Array,

    [Description("bool")]
    Bool,

    [Description("connection")]
    Connection,

    [Description("int")]
    Int,

    [Description("oauthSetting")]
    OauthSetting,

    [Description("object")]
    Object,

    [Description("secureobject")]
    Secureobject,

    [Description("securestring")]
    Securestring,

    [Description("string")]
    String,
}
