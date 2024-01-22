// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiManagementService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostnameTypeConstant
{
    [Description("ConfigurationApi")]
    ConfigurationApi,

    [Description("DeveloperPortal")]
    DeveloperPortal,

    [Description("Management")]
    Management,

    [Description("Portal")]
    Portal,

    [Description("Proxy")]
    Proxy,

    [Description("Scm")]
    Scm,
}
