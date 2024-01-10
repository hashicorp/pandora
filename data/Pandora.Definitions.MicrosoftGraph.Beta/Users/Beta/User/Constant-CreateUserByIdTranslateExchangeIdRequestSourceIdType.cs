// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.User;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateUserByIdTranslateExchangeIdRequestSourceIdTypeConstant
{
    [Description("EntryId")]
    @entryId,

    [Description("EwsId")]
    @ewsId,

    [Description("ImmutableEntryId")]
    @immutableEntryId,

    [Description("RestId")]
    @restId,

    [Description("RestImmutableEntryId")]
    @restImmutableEntryId,
}
