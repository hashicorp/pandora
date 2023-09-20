// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnumeratedDomainsRootDomainsConstant
{
    [Description("None")]
    @none,

    [Description("All")]
    @all,

    [Description("AllFederated")]
    @allFederated,

    [Description("AllManaged")]
    @allManaged,

    [Description("Enumerated")]
    @enumerated,

    [Description("AllManagedAndEnumeratedFederated")]
    @allManagedAndEnumeratedFederated,
}
