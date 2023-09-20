// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EducationSynchronizationProfileStateConstant
{
    [Description("Deleting")]
    @deleting,

    [Description("DeletionFailed")]
    @deletionFailed,

    [Description("ProvisioningFailed")]
    @provisioningFailed,

    [Description("Provisioned")]
    @provisioned,

    [Description("Provisioning")]
    @provisioning,
}
