// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MessageImportanceConstant
{
    [Description("Low")]
    @low,

    [Description("Normal")]
    @normal,

    [Description("High")]
    @high,
}
