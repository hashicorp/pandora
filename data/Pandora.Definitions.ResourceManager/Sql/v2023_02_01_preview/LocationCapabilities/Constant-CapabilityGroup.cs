// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.LocationCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CapabilityGroupConstant
{
    [Description("supportedEditions")]
    SupportedEditions,

    [Description("supportedElasticPoolEditions")]
    SupportedElasticPoolEditions,

    [Description("supportedInstancePoolEditions")]
    SupportedInstancePoolEditions,

    [Description("supportedManagedInstanceEditions")]
    SupportedManagedInstanceEditions,

    [Description("supportedManagedInstanceVersions")]
    SupportedManagedInstanceVersions,
}
