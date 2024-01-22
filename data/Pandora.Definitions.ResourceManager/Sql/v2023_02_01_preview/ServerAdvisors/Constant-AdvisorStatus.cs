// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ServerAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdvisorStatusConstant
{
    [Description("GA")]
    GA,

    [Description("LimitedPublicPreview")]
    LimitedPublicPreview,

    [Description("PrivatePreview")]
    PrivatePreview,

    [Description("PublicPreview")]
    PublicPreview,
}
