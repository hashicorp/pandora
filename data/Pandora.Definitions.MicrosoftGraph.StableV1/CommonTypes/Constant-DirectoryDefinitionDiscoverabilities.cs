// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DirectoryDefinitionDiscoverabilitiesConstant
{
    [Description("None")]
    @None,

    [Description("AttributeNames")]
    @AttributeNames,

    [Description("AttributeDataTypes")]
    @AttributeDataTypes,

    [Description("AttributeReadOnly")]
    @AttributeReadOnly,

    [Description("ReferenceAttributes")]
    @ReferenceAttributes,
}
