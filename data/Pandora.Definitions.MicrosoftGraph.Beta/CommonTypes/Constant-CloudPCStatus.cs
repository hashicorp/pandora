// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCStatusConstant
{
    [Description("NotProvisioned")]
    @notProvisioned,

    [Description("Provisioning")]
    @provisioning,

    [Description("Provisioned")]
    @provisioned,

    [Description("InGracePeriod")]
    @inGracePeriod,

    [Description("Deprovisioning")]
    @deprovisioning,

    [Description("Failed")]
    @failed,

    [Description("ProvisionedWithWarnings")]
    @provisionedWithWarnings,

    [Description("Resizing")]
    @resizing,

    [Description("Restoring")]
    @restoring,

    [Description("PendingProvision")]
    @pendingProvision,

    [Description("MovingRegion")]
    @movingRegion,

    [Description("ResizePendingLicense")]
    @resizePendingLicense,

    [Description("UpdatingSingleSignOn")]
    @updatingSingleSignOn,
}
