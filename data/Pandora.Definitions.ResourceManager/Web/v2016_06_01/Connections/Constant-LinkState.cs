// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LinkStateConstant
{
    [Description("Authenticated")]
    Authenticated,

    [Description("Error")]
    Error,

    [Description("Unauthenticated")]
    Unauthenticated,
}
