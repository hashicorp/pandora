// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementConfigurationStringFormatConstant
{
    [Description("None")]
    @none,

    [Description("Email")]
    @email,

    [Description("Guid")]
    @guid,

    [Description("Ip")]
    @ip,

    [Description("Base64")]
    @base64,

    [Description("Url")]
    @url,

    [Description("Version")]
    @version,

    [Description("Xml")]
    @xml,

    [Description("Date")]
    @date,

    [Description("Time")]
    @time,

    [Description("Binary")]
    @binary,

    [Description("RegEx")]
    @regEx,

    [Description("Json")]
    @json,

    [Description("DateTime")]
    @dateTime,

    [Description("SurfaceHub")]
    @surfaceHub,

    [Description("BashScript")]
    @bashScript,
}
