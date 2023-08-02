// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectorNameConstant
{
    [Description("ApplePushNotificationServiceExpirationDateTime")]
    @applePushNotificationServiceExpirationDateTime,

    [Description("VppTokenExpirationDateTime")]
    @vppTokenExpirationDateTime,

    [Description("VppTokenLastSyncDateTime")]
    @vppTokenLastSyncDateTime,

    [Description("WindowsAutopilotLastSyncDateTime")]
    @windowsAutopilotLastSyncDateTime,

    [Description("WindowsStoreForBusinessLastSyncDateTime")]
    @windowsStoreForBusinessLastSyncDateTime,

    [Description("JamfLastSyncDateTime")]
    @jamfLastSyncDateTime,

    [Description("NdesConnectorLastConnectionDateTime")]
    @ndesConnectorLastConnectionDateTime,

    [Description("AppleDepExpirationDateTime")]
    @appleDepExpirationDateTime,

    [Description("AppleDepLastSyncDateTime")]
    @appleDepLastSyncDateTime,

    [Description("OnPremConnectorLastSyncDateTime")]
    @onPremConnectorLastSyncDateTime,

    [Description("GooglePlayAppLastSyncDateTime")]
    @googlePlayAppLastSyncDateTime,

    [Description("GooglePlayConnectorLastModifiedDateTime")]
    @googlePlayConnectorLastModifiedDateTime,

    [Description("WindowsDefenderATPConnectorLastHeartbeatDateTime")]
    @windowsDefenderATPConnectorLastHeartbeatDateTime,

    [Description("MobileThreatDefenceConnectorLastHeartbeatDateTime")]
    @mobileThreatDefenceConnectorLastHeartbeatDateTime,

    [Description("ChromebookLastDirectorySyncDateTime")]
    @chromebookLastDirectorySyncDateTime,

    [Description("FutureValue")]
    @futureValue,
}
