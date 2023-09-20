// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebsiteTypeConstant
{
    [Description("Other")]
    @other,

    [Description("Home")]
    @home,

    [Description("Work")]
    @work,

    [Description("Blog")]
    @blog,

    [Description("Profile")]
    @profile,
}
