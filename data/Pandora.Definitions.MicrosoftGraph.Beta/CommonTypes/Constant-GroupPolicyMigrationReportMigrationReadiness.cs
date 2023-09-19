// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupPolicyMigrationReportMigrationReadinessConstant
{
    [Description("None")]
    @none,

    [Description("Partial")]
    @partial,

    [Description("Complete")]
    @complete,

    [Description("Error")]
    @error,

    [Description("NotApplicable")]
    @notApplicable,
}
