// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceRoleConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("CustomBot")]
    @customBot,

    [Description("SkypeForBusinessMicrosoftTeamsGateway")]
    @skypeForBusinessMicrosoftTeamsGateway,

    [Description("SkypeForBusinessAudioVideoMcu")]
    @skypeForBusinessAudioVideoMcu,

    [Description("SkypeForBusinessApplicationSharingMcu")]
    @skypeForBusinessApplicationSharingMcu,

    [Description("SkypeForBusinessCallQueues")]
    @skypeForBusinessCallQueues,

    [Description("SkypeForBusinessAutoAttendant")]
    @skypeForBusinessAutoAttendant,

    [Description("MediationServer")]
    @mediationServer,

    [Description("MediationServerCloudConnectorEdition")]
    @mediationServerCloudConnectorEdition,

    [Description("ExchangeUnifiedMessagingService")]
    @exchangeUnifiedMessagingService,

    [Description("MediaController")]
    @mediaController,

    [Description("ConferencingAnnouncementService")]
    @conferencingAnnouncementService,

    [Description("ConferencingAttendant")]
    @conferencingAttendant,

    [Description("AudioTeleconferencerController")]
    @audioTeleconferencerController,

    [Description("SkypeForBusinessUnifiedCommunicationApplicationPlatform")]
    @skypeForBusinessUnifiedCommunicationApplicationPlatform,

    [Description("ResponseGroupServiceAnnouncementService")]
    @responseGroupServiceAnnouncementService,

    [Description("Gateway")]
    @gateway,

    [Description("SkypeTranslator")]
    @skypeTranslator,

    [Description("SkypeForBusinessAttendant")]
    @skypeForBusinessAttendant,

    [Description("ResponseGroupService")]
    @responseGroupService,

    [Description("Voicemail")]
    @voicemail,
}
