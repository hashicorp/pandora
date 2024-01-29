// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.BatchManagements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceTypeConstant
{
    [Description("Microsoft.Batch/batchAccounts")]
    MicrosoftPointBatchBatchAccounts,
}
