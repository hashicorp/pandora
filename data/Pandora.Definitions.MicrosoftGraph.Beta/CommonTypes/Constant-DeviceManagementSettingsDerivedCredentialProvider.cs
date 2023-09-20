// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementSettingsDerivedCredentialProviderConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("EntrustDataCard")]
    @entrustDataCard,

    [Description("Purebred")]
    @purebred,

    [Description("XTec")]
    @xTec,

    [Description("Intercede")]
    @intercede,
}
