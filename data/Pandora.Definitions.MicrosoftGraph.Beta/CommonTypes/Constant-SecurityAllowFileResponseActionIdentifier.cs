// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityAllowFileResponseActionIdentifierConstant
{
    [Description("Sha1")]
    @sha1,

    [Description("InitiatingProcessSHA1")]
    @initiatingProcessSHA1,

    [Description("Sha256")]
    @sha256,

    [Description("InitiatingProcessSHA256")]
    @initiatingProcessSHA256,
}
