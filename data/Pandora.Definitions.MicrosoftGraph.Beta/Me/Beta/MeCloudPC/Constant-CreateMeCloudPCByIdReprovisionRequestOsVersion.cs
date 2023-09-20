// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCloudPC;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateMeCloudPCByIdReprovisionRequestOsVersionConstant
{
    [Description("Windows10")]
    @windows10,

    [Description("Windows11")]
    @windows11,
}
