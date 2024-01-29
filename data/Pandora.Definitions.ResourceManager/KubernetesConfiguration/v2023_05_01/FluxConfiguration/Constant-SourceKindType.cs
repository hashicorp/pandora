// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2023_05_01.FluxConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceKindTypeConstant
{
    [Description("AzureBlob")]
    AzureBlob,

    [Description("Bucket")]
    Bucket,

    [Description("GitRepository")]
    GitRepository,
}
