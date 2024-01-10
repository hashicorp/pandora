// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MacOSWiredNetworkConfigurationNetworkInterfaceConstant
{
    [Description("AnyEthernet")]
    @anyEthernet,

    [Description("FirstActiveEthernet")]
    @firstActiveEthernet,

    [Description("SecondActiveEthernet")]
    @secondActiveEthernet,

    [Description("ThirdActiveEthernet")]
    @thirdActiveEthernet,

    [Description("FirstEthernet")]
    @firstEthernet,

    [Description("SecondEthernet")]
    @secondEthernet,

    [Description("ThirdEthernet")]
    @thirdEthernet,
}
