// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiTypeConstant
{
    [Description("NotSpecified")]
    NotSpecified,

    [Description("Rest")]
    Rest,

    [Description("Soap")]
    Soap,
}
