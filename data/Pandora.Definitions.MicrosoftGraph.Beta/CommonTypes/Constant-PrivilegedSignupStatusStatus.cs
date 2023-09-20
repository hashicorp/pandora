// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivilegedSignupStatusStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("NotRegisteredYet")]
    @notRegisteredYet,

    [Description("RegisteredSetupNotStarted")]
    @registeredSetupNotStarted,

    [Description("RegisteredSetupInProgress")]
    @registeredSetupInProgress,

    [Description("RegistrationAndSetupCompleted")]
    @registrationAndSetupCompleted,

    [Description("RegistrationFailed")]
    @registrationFailed,

    [Description("RegistrationTimedOut")]
    @registrationTimedOut,

    [Description("Disabled")]
    @disabled,
}
