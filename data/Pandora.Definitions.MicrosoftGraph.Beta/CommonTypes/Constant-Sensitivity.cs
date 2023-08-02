// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SensitivityConstant
{
    [Description("Normal")]
    @normal,

    [Description("Personal")]
    @personal,

    [Description("Private")]
    @private,

    [Description("Confidential")]
    @confidential,
}
