// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityEdiscoverySearchExportOperationAdditionalOptionsConstant
{
    [Description("None")]
    @none,

    [Description("TeamsAndYammerConversations")]
    @teamsAndYammerConversations,

    [Description("CloudAttachments")]
    @cloudAttachments,

    [Description("AllDocumentVersions")]
    @allDocumentVersions,

    [Description("SubfolderContents")]
    @subfolderContents,

    [Description("ListAttachments")]
    @listAttachments,
}
