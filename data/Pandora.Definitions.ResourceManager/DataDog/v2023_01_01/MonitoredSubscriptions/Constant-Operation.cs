// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2023_01_01.MonitoredSubscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationConstant
{
    [Description("Active")]
    Active,

    [Description("AddBegin")]
    AddBegin,

    [Description("AddComplete")]
    AddComplete,

    [Description("DeleteBegin")]
    DeleteBegin,

    [Description("DeleteComplete")]
    DeleteComplete,
}
