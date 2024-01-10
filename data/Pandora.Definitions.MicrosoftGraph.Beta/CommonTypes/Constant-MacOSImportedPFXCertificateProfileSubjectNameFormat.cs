// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MacOSImportedPFXCertificateProfileSubjectNameFormatConstant
{
    [Description("CommonName")]
    @commonName,

    [Description("CommonNameAsEmail")]
    @commonNameAsEmail,

    [Description("Custom")]
    @custom,

    [Description("CommonNameIncludingEmail")]
    @commonNameIncludingEmail,

    [Description("CommonNameAsIMEI")]
    @commonNameAsIMEI,

    [Description("CommonNameAsSerialNumber")]
    @commonNameAsSerialNumber,
}
