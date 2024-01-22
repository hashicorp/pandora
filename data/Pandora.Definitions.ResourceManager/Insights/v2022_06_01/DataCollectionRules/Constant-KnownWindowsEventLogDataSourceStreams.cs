// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownWindowsEventLogDataSourceStreamsConstant
{
    [Description("Microsoft-Event")]
    MicrosoftNegativeEvent,

    [Description("Microsoft-WindowsEvent")]
    MicrosoftNegativeWindowsEvent,
}
