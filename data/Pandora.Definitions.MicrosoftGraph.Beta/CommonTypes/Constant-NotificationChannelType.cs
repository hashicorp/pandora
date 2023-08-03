// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NotificationChannelTypeConstant
{
    [Description("Portal")]
    @portal,

    [Description("Email")]
    @email,

    [Description("PhoneCall")]
    @phoneCall,

    [Description("Sms")]
    @sms,
}
