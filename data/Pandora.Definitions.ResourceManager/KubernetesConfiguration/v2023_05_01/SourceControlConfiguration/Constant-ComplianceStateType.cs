// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2023_05_01.SourceControlConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ComplianceStateTypeConstant
{
    [Description("Compliant")]
    Compliant,

    [Description("Failed")]
    Failed,

    [Description("Installed")]
    Installed,

    [Description("Noncompliant")]
    Noncompliant,

    [Description("Pending")]
    Pending,
}
