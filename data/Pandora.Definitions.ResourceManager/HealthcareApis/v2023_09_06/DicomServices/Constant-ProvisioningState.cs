// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_09_06.DicomServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Deprovisioned")]
    Deprovisioned,

    [Description("Failed")]
    Failed,

    [Description("Moving")]
    Moving,

    [Description("Succeeded")]
    Succeeded,

    [Description("Suspended")]
    Suspended,

    [Description("SystemMaintenance")]
    SystemMaintenance,

    [Description("Updating")]
    Updating,

    [Description("Verifying")]
    Verifying,

    [Description("Warned")]
    Warned,
}
