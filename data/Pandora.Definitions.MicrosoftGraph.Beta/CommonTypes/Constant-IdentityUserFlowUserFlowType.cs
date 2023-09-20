// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IdentityUserFlowUserFlowTypeConstant
{
    [Description("SignUp")]
    @signUp,

    [Description("SignIn")]
    @signIn,

    [Description("SignUpOrSignIn")]
    @signUpOrSignIn,

    [Description("PasswordReset")]
    @passwordReset,

    [Description("ProfileUpdate")]
    @profileUpdate,

    [Description("ResourceOwner")]
    @resourceOwner,
}
