// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamsAsyncOperationOperationTypeConstant
{
    [Description("Invalid")]
    @invalid,

    [Description("CloneTeam")]
    @cloneTeam,

    [Description("ArchiveTeam")]
    @archiveTeam,

    [Description("UnarchiveTeam")]
    @unarchiveTeam,

    [Description("CreateTeam")]
    @createTeam,

    [Description("TeamifyGroup")]
    @teamifyGroup,

    [Description("CreateChannel")]
    @createChannel,

    [Description("CreateChat")]
    @createChat,
}
