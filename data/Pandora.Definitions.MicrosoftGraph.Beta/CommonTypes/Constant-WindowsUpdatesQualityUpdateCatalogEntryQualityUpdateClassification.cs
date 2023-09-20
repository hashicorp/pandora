// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsUpdatesQualityUpdateCatalogEntryQualityUpdateClassificationConstant
{
    [Description("All")]
    @all,

    [Description("Security")]
    @security,

    [Description("NonSecurity")]
    @nonSecurity,
}
