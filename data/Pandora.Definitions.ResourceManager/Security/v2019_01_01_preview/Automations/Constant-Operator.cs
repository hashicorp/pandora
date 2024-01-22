// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.Automations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorConstant
{
    [Description("Contains")]
    Contains,

    [Description("EndsWith")]
    EndsWith,

    [Description("Equals")]
    Equals,

    [Description("GreaterThan")]
    GreaterThan,

    [Description("GreaterThanOrEqualTo")]
    GreaterThanOrEqualTo,

    [Description("LesserThan")]
    LesserThan,

    [Description("LesserThanOrEqualTo")]
    LesserThanOrEqualTo,

    [Description("NotEquals")]
    NotEquals,

    [Description("StartsWith")]
    StartsWith,
}
