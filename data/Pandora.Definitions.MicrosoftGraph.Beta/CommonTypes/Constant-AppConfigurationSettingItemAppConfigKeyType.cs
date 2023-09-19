// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppConfigurationSettingItemAppConfigKeyTypeConstant
{
    [Description("StringType")]
    @stringType,

    [Description("IntegerType")]
    @integerType,

    [Description("RealType")]
    @realType,

    [Description("BooleanType")]
    @booleanType,

    [Description("TokenType")]
    @tokenType,
}
