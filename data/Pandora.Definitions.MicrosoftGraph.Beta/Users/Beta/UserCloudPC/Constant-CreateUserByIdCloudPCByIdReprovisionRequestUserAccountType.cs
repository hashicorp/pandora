// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCloudPC;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateUserByIdCloudPCByIdReprovisionRequestUserAccountTypeConstant
{
    [Description("StandardUser")]
    @standardUser,

    [Description("Administrator")]
    @administrator,
}
