// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementComplianceActionTypeConstant
{
    [Description("NoAction")]
    @noAction,

    [Description("Notification")]
    @notification,

    [Description("Block")]
    @block,

    [Description("Retire")]
    @retire,

    [Description("Wipe")]
    @wipe,

    [Description("RemoveResourceAccessProfiles")]
    @removeResourceAccessProfiles,

    [Description("PushNotification")]
    @pushNotification,

    [Description("RemoteLock")]
    @remoteLock,
}
