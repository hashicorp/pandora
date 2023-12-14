// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PermissionsRequestChangeActiveOccurrenceStatusConstant
{
    [Description("GrantingFailed")]
    @grantingFailed,

    [Description("Granted")]
    @granted,

    [Description("Granting")]
    @granting,

    [Description("Revoked")]
    @revoked,

    [Description("Revoking")]
    @revoking,

    [Description("RevokingFailed")]
    @revokingFailed,
}
