// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserDefaultAuthenticationMethodTypeConstant
{
    [Description("Push")]
    @push,

    [Description("Oath")]
    @oath,

    [Description("VoiceMobile")]
    @voiceMobile,

    [Description("VoiceAlternateMobile")]
    @voiceAlternateMobile,

    [Description("VoiceOffice")]
    @voiceOffice,

    [Description("Sms")]
    @sms,
}
