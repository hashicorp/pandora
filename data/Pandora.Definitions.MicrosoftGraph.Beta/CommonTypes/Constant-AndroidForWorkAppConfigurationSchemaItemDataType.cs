// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidForWorkAppConfigurationSchemaItemDataTypeConstant
{
    [Description("Bool")]
    @bool,

    [Description("Integer")]
    @integer,

    [Description("String")]
    @string,

    [Description("Choice")]
    @choice,

    [Description("Multiselect")]
    @multiselect,

    [Description("Bundle")]
    @bundle,

    [Description("BundleArray")]
    @bundleArray,

    [Description("Hidden")]
    @hidden,
}
