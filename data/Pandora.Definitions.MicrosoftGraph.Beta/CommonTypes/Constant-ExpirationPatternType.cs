// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpirationPatternTypeConstant
{
    [Description("NotSpecified")]
    @notSpecified,

    [Description("NoExpiration")]
    @noExpiration,

    [Description("AfterDateTime")]
    @afterDateTime,

    [Description("AfterDuration")]
    @afterDuration,
}
