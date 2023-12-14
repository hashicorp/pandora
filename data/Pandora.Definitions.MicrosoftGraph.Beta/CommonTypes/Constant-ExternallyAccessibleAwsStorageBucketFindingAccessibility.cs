// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExternallyAccessibleAwsStorageBucketFindingAccessibilityConstant
{
    [Description("Public")]
    @public,

    [Description("Restricted")]
    @restricted,

    [Description("CrossAccount")]
    @crossAccount,

    [Description("Private")]
    @private,
}
