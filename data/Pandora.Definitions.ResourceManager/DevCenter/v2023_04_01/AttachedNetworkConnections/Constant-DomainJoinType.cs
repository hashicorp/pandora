// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.AttachedNetworkConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DomainJoinTypeConstant
{
    [Description("AzureADJoin")]
    AzureADJoin,

    [Description("HybridAzureADJoin")]
    HybridAzureADJoin,
}
