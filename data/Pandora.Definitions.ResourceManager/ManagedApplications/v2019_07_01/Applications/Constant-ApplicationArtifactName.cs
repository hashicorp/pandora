// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.Applications;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationArtifactNameConstant
{
    [Description("Authorizations")]
    Authorizations,

    [Description("CustomRoleDefinition")]
    CustomRoleDefinition,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("ViewDefinition")]
    ViewDefinition,
}
