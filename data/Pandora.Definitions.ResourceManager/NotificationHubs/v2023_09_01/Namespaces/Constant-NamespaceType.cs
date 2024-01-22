// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NamespaceTypeConstant
{
    [Description("Messaging")]
    Messaging,

    [Description("NotificationHub")]
    NotificationHub,
}
