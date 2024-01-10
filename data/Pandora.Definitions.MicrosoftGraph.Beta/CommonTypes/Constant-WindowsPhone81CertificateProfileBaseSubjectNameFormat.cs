// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsPhone81CertificateProfileBaseSubjectNameFormatConstant
{
    [Description("CommonName")]
    @commonName,

    [Description("CommonNameIncludingEmail")]
    @commonNameIncludingEmail,

    [Description("CommonNameAsEmail")]
    @commonNameAsEmail,

    [Description("Custom")]
    @custom,

    [Description("CommonNameAsIMEI")]
    @commonNameAsIMEI,

    [Description("CommonNameAsSerialNumber")]
    @commonNameAsSerialNumber,

    [Description("CommonNameAsAadDeviceId")]
    @commonNameAsAadDeviceId,

    [Description("CommonNameAsIntuneDeviceId")]
    @commonNameAsIntuneDeviceId,

    [Description("CommonNameAsDurableDeviceId")]
    @commonNameAsDurableDeviceId,
}
