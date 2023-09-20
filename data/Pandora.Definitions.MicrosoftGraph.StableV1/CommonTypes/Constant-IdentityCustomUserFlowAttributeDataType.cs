// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IdentityCustomUserFlowAttributeDataTypeConstant
{
    [Description("String")]
    @string,

    [Description("Boolean")]
    @boolean,

    [Description("Int64")]
    @int64,

    [Description("StringCollection")]
    @stringCollection,

    [Description("DateTime")]
    @dateTime,
}
