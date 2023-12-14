// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AttributeMappingFlowTypeConstant
{
    [Description("Always")]
    @Always,

    [Description("ObjectAddOnly")]
    @ObjectAddOnly,

    [Description("MultiValueAddOnly")]
    @MultiValueAddOnly,

    [Description("ValueAddOnly")]
    @ValueAddOnly,

    [Description("AttributeAddOnly")]
    @AttributeAddOnly,
}
