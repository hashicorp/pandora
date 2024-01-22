// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_12_01.KafkaConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CredentialsTypeConstant
{
    [Description("None")]
    None,

    [Description("SystemAssigned")]
    SystemAssigned,

    [Description("UserAssigned")]
    UserAssigned,
}
