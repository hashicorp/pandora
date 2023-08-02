// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VppTokenStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Valid")]
    @valid,

    [Description("Expired")]
    @expired,

    [Description("Invalid")]
    @invalid,

    [Description("AssignedToExternalMDM")]
    @assignedToExternalMDM,

    [Description("DuplicateLocationId")]
    @duplicateLocationId,
}
