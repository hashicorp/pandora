// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkFunction.v2022_08_01.AzureTrafficCollectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngestionTypeConstant
{
    [Description("IPFIX")]
    IPFIX,
}
