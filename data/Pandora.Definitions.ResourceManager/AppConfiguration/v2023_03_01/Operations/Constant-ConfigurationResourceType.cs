// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2023_03_01.Operations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationResourceTypeConstant
{
    [Description("Microsoft.AppConfiguration/configurationStores")]
    MicrosoftPointAppConfigurationConfigurationStores,
}
