// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Relay.v2021_11_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessRightsConstant
{
    [Description("Listen")]
    Listen,

    [Description("Manage")]
    Manage,

    [Description("Send")]
    Send,
}
