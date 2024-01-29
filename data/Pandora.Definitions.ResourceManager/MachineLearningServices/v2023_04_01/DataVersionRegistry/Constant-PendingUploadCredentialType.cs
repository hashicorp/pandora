// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.DataVersionRegistry;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PendingUploadCredentialTypeConstant
{
    [Description("SAS")]
    SAS,
}
