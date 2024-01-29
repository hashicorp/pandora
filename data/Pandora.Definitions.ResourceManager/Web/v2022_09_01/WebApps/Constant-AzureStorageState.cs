// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureStorageStateConstant
{
    [Description("InvalidCredentials")]
    InvalidCredentials,

    [Description("InvalidShare")]
    InvalidShare,

    [Description("NotValidated")]
    NotValidated,

    [Description("Ok")]
    Ok,
}
