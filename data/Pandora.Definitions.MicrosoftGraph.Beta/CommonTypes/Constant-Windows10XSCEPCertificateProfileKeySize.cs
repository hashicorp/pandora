// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10XSCEPCertificateProfileKeySizeConstant
{
    [Description("Size1024")]
    @size1024,

    [Description("Size2048")]
    @size2048,

    [Description("Size4096")]
    @size4096,
}
