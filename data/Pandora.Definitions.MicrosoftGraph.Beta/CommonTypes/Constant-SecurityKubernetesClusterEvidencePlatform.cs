// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityKubernetesClusterEvidencePlatformConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Aks")]
    @aks,

    [Description("Eks")]
    @eks,

    [Description("Gke")]
    @gke,

    [Description("Arc")]
    @arc,
}
