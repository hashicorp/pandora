// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidKeyguardFeatureConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Camera")]
    @camera,

    [Description("Notifications")]
    @notifications,

    [Description("UnredactedNotifications")]
    @unredactedNotifications,

    [Description("TrustAgents")]
    @trustAgents,

    [Description("Fingerprint")]
    @fingerprint,

    [Description("RemoteInput")]
    @remoteInput,

    [Description("AllFeatures")]
    @allFeatures,

    [Description("Face")]
    @face,

    [Description("Iris")]
    @iris,

    [Description("Biometrics")]
    @biometrics,
}
