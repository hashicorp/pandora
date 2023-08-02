// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EducationSynchronizationStatusConstant
{
    [Description("Paused")]
    @paused,

    [Description("InProgress")]
    @inProgress,

    [Description("Success")]
    @success,

    [Description("Error")]
    @error,

    [Description("ValidationError")]
    @validationError,

    [Description("Quarantined")]
    @quarantined,

    [Description("Extracting")]
    @extracting,

    [Description("Validating")]
    @validating,
}
