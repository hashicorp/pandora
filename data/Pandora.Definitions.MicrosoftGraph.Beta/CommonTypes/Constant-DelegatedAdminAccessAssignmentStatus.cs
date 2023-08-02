// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DelegatedAdminAccessAssignmentStatusConstant
{
    [Description("Pending")]
    @pending,

    [Description("Active")]
    @active,

    [Description("Deleting")]
    @deleting,

    [Description("Deleted")]
    @deleted,

    [Description("Error")]
    @error,
}
