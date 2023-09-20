// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementAutopilotPolicyStatusDetailComplianceStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Compliant")]
    @compliant,

    [Description("Installed")]
    @installed,

    [Description("NotCompliant")]
    @notCompliant,

    [Description("NotInstalled")]
    @notInstalled,

    [Description("Error")]
    @error,
}
