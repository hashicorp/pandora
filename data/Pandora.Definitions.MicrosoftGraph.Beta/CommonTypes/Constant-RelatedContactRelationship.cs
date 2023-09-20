// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RelatedContactRelationshipConstant
{
    [Description("Parent")]
    @parent,

    [Description("Relative")]
    @relative,

    [Description("Aide")]
    @aide,

    [Description("Doctor")]
    @doctor,

    [Description("Guardian")]
    @guardian,

    [Description("Child")]
    @child,

    [Description("Other")]
    @other,
}
