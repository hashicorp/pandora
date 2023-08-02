// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OfficeProductIdConstant
{
    [Description("O365ProPlusRetail")]
    @o365ProPlusRetail,

    [Description("O365BusinessRetail")]
    @o365BusinessRetail,

    [Description("VisioProRetail")]
    @visioProRetail,

    [Description("ProjectProRetail")]
    @projectProRetail,
}
