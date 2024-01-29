// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.Assignment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssignmentProvisioningStateConstant
{
    [Description("canceled")]
    Canceled,

    [Description("cancelling")]
    Cancelling,

    [Description("creating")]
    Creating,

    [Description("deleting")]
    Deleting,

    [Description("deploying")]
    Deploying,

    [Description("failed")]
    Failed,

    [Description("locking")]
    Locking,

    [Description("succeeded")]
    Succeeded,

    [Description("validating")]
    Validating,

    [Description("waiting")]
    Waiting,
}
