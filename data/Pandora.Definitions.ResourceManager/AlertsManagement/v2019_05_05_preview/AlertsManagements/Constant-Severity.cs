// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SeverityConstant
{
    [Description("Sev4")]
    SevFour,

    [Description("Sev1")]
    SevOne,

    [Description("Sev3")]
    SevThree,

    [Description("Sev2")]
    SevTwo,

    [Description("Sev0")]
    SevZero,
}
