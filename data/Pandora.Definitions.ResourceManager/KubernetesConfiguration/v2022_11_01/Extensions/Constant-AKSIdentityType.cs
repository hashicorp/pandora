// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.Extensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AKSIdentityTypeConstant
{
    [Description("SystemAssigned")]
    SystemAssigned,

    [Description("UserAssigned")]
    UserAssigned,
}
