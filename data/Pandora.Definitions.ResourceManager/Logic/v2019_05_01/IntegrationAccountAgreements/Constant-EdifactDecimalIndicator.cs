// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EdifactDecimalIndicatorConstant
{
    [Description("Comma")]
    Comma,

    [Description("Decimal")]
    Decimal,

    [Description("NotSpecified")]
    NotSpecified,
}
