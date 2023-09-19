// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserAccountStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Staged")]
    @staged,

    [Description("Active")]
    @active,

    [Description("Suspended")]
    @suspended,

    [Description("Deleted")]
    @deleted,
}
