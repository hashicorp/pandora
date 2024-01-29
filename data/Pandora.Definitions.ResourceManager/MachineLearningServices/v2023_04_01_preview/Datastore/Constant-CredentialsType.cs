// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Datastore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CredentialsTypeConstant
{
    [Description("AccountKey")]
    AccountKey,

    [Description("Certificate")]
    Certificate,

    [Description("KerberosKeytab")]
    KerberosKeytab,

    [Description("KerberosPassword")]
    KerberosPassword,

    [Description("None")]
    None,

    [Description("Sas")]
    Sas,

    [Description("ServicePrincipal")]
    ServicePrincipal,
}
