// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LinuxUpdateClassesConstant
{
    [Description("Critical")]
    Critical,

    [Description("Other")]
    Other,

    [Description("Security")]
    Security,

    [Description("Unclassified")]
    Unclassified,
}
