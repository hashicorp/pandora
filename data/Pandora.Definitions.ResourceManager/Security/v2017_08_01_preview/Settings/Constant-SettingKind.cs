// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.Settings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingKindConstant
{
    [Description("AlertSuppressionSetting")]
    AlertSuppressionSetting,

    [Description("DataExportSetting")]
    DataExportSetting,
}
