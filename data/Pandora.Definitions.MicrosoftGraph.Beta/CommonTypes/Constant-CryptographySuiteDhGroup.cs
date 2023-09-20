// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CryptographySuiteDhGroupConstant
{
    [Description("Group1")]
    @group1,

    [Description("Group2")]
    @group2,

    [Description("Group14")]
    @group14,

    [Description("Ecp256")]
    @ecp256,

    [Description("Ecp384")]
    @ecp384,

    [Description("Group24")]
    @group24,
}
