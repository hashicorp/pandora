// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCAuditEventActivityResultConstant
{
    [Description("Success")]
    @success,

    [Description("ClientError")]
    @clientError,

    [Description("Failure")]
    @failure,

    [Description("Timeout")]
    @timeout,

    [Description("Other")]
    @other,
}
