// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharedPCAccountManagerPolicyAccountDeletionPolicyConstant
{
    [Description("Immediate")]
    @immediate,

    [Description("DiskSpaceThreshold")]
    @diskSpaceThreshold,

    [Description("DiskSpaceThresholdOrInactiveThreshold")]
    @diskSpaceThresholdOrInactiveThreshold,
}
