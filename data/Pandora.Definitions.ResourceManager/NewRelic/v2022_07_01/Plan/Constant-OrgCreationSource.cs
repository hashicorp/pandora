// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01.Plan;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OrgCreationSourceConstant
{
    [Description("LIFTR")]
    LIFTR,

    [Description("NEWRELIC")]
    NEWRELIC,
}
