// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01.PolicyAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SelectorKindConstant
{
    [Description("policyDefinitionReferenceId")]
    PolicyDefinitionReferenceId,

    [Description("resourceLocation")]
    ResourceLocation,

    [Description("resourceType")]
    ResourceType,

    [Description("resourceWithoutLocation")]
    ResourceWithoutLocation,
}
