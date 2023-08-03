// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DriverCategoryConstant
{
    [Description("Recommended")]
    @recommended,

    [Description("PreviouslyApproved")]
    @previouslyApproved,

    [Description("Other")]
    @other,
}
