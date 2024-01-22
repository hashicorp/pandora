// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.DataVersionRegistry;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PendingUploadTypeConstant
{
    [Description("None")]
    None,

    [Description("TemporaryBlobReference")]
    TemporaryBlobReference,
}
