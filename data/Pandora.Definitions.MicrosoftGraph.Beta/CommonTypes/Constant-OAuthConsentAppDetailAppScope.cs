// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OAuthConsentAppDetailAppScopeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("ReadCalendar")]
    @readCalendar,

    [Description("ReadContact")]
    @readContact,

    [Description("ReadMail")]
    @readMail,

    [Description("ReadAllChat")]
    @readAllChat,

    [Description("ReadAllFile")]
    @readAllFile,

    [Description("ReadAndWriteMail")]
    @readAndWriteMail,

    [Description("SendMail")]
    @sendMail,
}
