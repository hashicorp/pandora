// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityTypeConstant
{
    [Description("Event")]
    @event,

    [Description("Message")]
    @message,

    [Description("DriveItem")]
    @driveItem,

    [Description("ExternalItem")]
    @externalItem,

    [Description("Site")]
    @site,

    [Description("List")]
    @list,

    [Description("ListItem")]
    @listItem,

    [Description("Drive")]
    @drive,

    [Description("Acronym")]
    @acronym,

    [Description("Bookmark")]
    @bookmark,

    [Description("ChatMessage")]
    @chatMessage,

    [Description("Person")]
    @person,

    [Description("Qna")]
    @qna,
}
