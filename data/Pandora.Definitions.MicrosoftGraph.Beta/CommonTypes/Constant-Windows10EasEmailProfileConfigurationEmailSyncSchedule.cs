// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EasEmailProfileConfigurationEmailSyncScheduleConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("AsMessagesArrive")]
    @asMessagesArrive,

    [Description("Manual")]
    @manual,

    [Description("FifteenMinutes")]
    @fifteenMinutes,

    [Description("ThirtyMinutes")]
    @thirtyMinutes,

    [Description("SixtyMinutes")]
    @sixtyMinutes,

    [Description("BasedOnMyUsage")]
    @basedOnMyUsage,
}
