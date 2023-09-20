// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ObjectDefinitionMetadataEntryKeyConstant
{
    [Description("PropertyNameAccountEnabled")]
    @PropertyNameAccountEnabled,

    [Description("PropertyNameSoftDeleted")]
    @PropertyNameSoftDeleted,

    [Description("IsSoftDeletionSupported")]
    @IsSoftDeletionSupported,

    [Description("IsSynchronizeAllSupported")]
    @IsSynchronizeAllSupported,

    [Description("ConnectorDataStorageRequired")]
    @ConnectorDataStorageRequired,

    [Description("Extensions")]
    @Extensions,

    [Description("BaseObjectName")]
    @BaseObjectName,
}
