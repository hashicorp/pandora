// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertsSortByFieldsConstant
{
    [Description("alertState")]
    AlertState,

    [Description("lastModifiedDateTime")]
    LastModifiedDateTime,

    [Description("monitorCondition")]
    MonitorCondition,

    [Description("name")]
    Name,

    [Description("severity")]
    Severity,

    [Description("startDateTime")]
    StartDateTime,

    [Description("targetResource")]
    TargetResource,

    [Description("targetResourceGroup")]
    TargetResourceGroup,

    [Description("targetResourceName")]
    TargetResourceName,

    [Description("targetResourceType")]
    TargetResourceType,
}
