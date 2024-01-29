// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2023_03_01.CheckPolicyRestrictions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FieldRestrictionResultConstant
{
    [Description("Audit")]
    Audit,

    [Description("Deny")]
    Deny,

    [Description("Removed")]
    Removed,

    [Description("Required")]
    Required,
}
