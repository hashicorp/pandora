// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPackageResourceRequestRequestTypeConstant
{
    [Description("NotSpecified")]
    @notSpecified,

    [Description("UserAdd")]
    @userAdd,

    [Description("UserUpdate")]
    @userUpdate,

    [Description("UserRemove")]
    @userRemove,

    [Description("AdminAdd")]
    @adminAdd,

    [Description("AdminUpdate")]
    @adminUpdate,

    [Description("AdminRemove")]
    @adminRemove,

    [Description("SystemAdd")]
    @systemAdd,

    [Description("SystemUpdate")]
    @systemUpdate,

    [Description("SystemRemove")]
    @systemRemove,

    [Description("OnBehalfAdd")]
    @onBehalfAdd,
}
