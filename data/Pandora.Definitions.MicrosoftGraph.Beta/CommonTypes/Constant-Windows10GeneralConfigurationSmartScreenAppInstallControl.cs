// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10GeneralConfigurationSmartScreenAppInstallControlConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Anywhere")]
    @anywhere,

    [Description("StoreOnly")]
    @storeOnly,

    [Description("Recommendations")]
    @recommendations,

    [Description("PreferStore")]
    @preferStore,
}
