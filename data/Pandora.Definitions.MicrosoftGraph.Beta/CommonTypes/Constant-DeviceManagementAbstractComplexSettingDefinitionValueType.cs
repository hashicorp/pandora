// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementAbstractComplexSettingDefinitionValueTypeConstant
{
    [Description("Integer")]
    @integer,

    [Description("Boolean")]
    @boolean,

    [Description("String")]
    @string,

    [Description("Complex")]
    @complex,

    [Description("Collection")]
    @collection,

    [Description("AbstractComplex")]
    @abstractComplex,
}
