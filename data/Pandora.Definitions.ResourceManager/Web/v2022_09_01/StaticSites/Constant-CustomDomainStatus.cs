// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.StaticSites;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomDomainStatusConstant
{
    [Description("Adding")]
    Adding,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Ready")]
    Ready,

    [Description("RetrievingValidationToken")]
    RetrievingValidationToken,

    [Description("Unhealthy")]
    Unhealthy,

    [Description("Validating")]
    Validating,
}
