// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidForWorkSyncStatusConstant
{
    [Description("Success")]
    @success,

    [Description("CredentialsNotValid")]
    @credentialsNotValid,

    [Description("AndroidForWorkApiError")]
    @androidForWorkApiError,

    [Description("ManagementServiceError")]
    @managementServiceError,

    [Description("UnknownError")]
    @unknownError,

    [Description("None")]
    @none,
}
