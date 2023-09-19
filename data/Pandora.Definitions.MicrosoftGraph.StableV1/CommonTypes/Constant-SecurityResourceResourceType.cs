// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityResourceResourceTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Attacked")]
    @attacked,

    [Description("Related")]
    @related,
}
