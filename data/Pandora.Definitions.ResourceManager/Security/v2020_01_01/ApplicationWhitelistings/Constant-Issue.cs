// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IssueConstant
{
    [Description("ExecutableViolationsAudited")]
    ExecutableViolationsAudited,

    [Description("MsiAndScriptViolationsAudited")]
    MsiAndScriptViolationsAudited,

    [Description("MsiAndScriptViolationsBlocked")]
    MsiAndScriptViolationsBlocked,

    [Description("RulesViolatedManually")]
    RulesViolatedManually,

    [Description("ViolationsAudited")]
    ViolationsAudited,

    [Description("ViolationsBlocked")]
    ViolationsBlocked,
}
