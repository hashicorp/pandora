// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PayloadSourceConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Global")]
    @global,

    [Description("Tenant")]
    @tenant,
}
