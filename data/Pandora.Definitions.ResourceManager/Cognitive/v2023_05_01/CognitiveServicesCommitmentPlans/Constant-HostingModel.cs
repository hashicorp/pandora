// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2023_05_01.CognitiveServicesCommitmentPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostingModelConstant
{
    [Description("ConnectedContainer")]
    ConnectedContainer,

    [Description("DisconnectedContainer")]
    DisconnectedContainer,

    [Description("ProvisionedWeb")]
    ProvisionedWeb,

    [Description("Web")]
    Web,
}
