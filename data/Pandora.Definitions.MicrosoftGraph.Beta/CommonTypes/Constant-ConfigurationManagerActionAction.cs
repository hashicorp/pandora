// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationManagerActionActionConstant
{
    [Description("RefreshMachinePolicy")]
    @refreshMachinePolicy,

    [Description("RefreshUserPolicy")]
    @refreshUserPolicy,

    [Description("WakeUpClient")]
    @wakeUpClient,

    [Description("AppEvaluation")]
    @appEvaluation,

    [Description("QuickScan")]
    @quickScan,

    [Description("FullScan")]
    @fullScan,

    [Description("WindowsDefenderUpdateSignatures")]
    @windowsDefenderUpdateSignatures,
}
