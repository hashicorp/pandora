// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncMembers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncDirectionConstant
{
    [Description("Bidirectional")]
    Bidirectional,

    [Description("OneWayHubToMember")]
    OneWayHubToMember,

    [Description("OneWayMemberToHub")]
    OneWayMemberToHub,
}
