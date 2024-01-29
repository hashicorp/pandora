// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrackEventsOperationOptionsConstant
{
    [Description("DisableSourceInfoEnrich")]
    DisableSourceInfoEnrich,

    [Description("None")]
    None,
}
