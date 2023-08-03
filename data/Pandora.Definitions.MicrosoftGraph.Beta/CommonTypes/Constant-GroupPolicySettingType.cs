// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupPolicySettingTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Policy")]
    @policy,

    [Description("Account")]
    @account,

    [Description("SecurityOptions")]
    @securityOptions,

    [Description("UserRightsAssignment")]
    @userRightsAssignment,

    [Description("AuditSetting")]
    @auditSetting,

    [Description("WindowsFirewallSettings")]
    @windowsFirewallSettings,

    [Description("AppLockerRuleCollection")]
    @appLockerRuleCollection,

    [Description("DataSourcesSettings")]
    @dataSourcesSettings,

    [Description("DevicesSettings")]
    @devicesSettings,

    [Description("DriveMapSettings")]
    @driveMapSettings,

    [Description("EnvironmentVariables")]
    @environmentVariables,

    [Description("FilesSettings")]
    @filesSettings,

    [Description("FolderOptions")]
    @folderOptions,

    [Description("Folders")]
    @folders,

    [Description("IniFiles")]
    @iniFiles,

    [Description("InternetOptions")]
    @internetOptions,

    [Description("LocalUsersAndGroups")]
    @localUsersAndGroups,

    [Description("NetworkOptions")]
    @networkOptions,

    [Description("NetworkShares")]
    @networkShares,

    [Description("NtServices")]
    @ntServices,

    [Description("PowerOptions")]
    @powerOptions,

    [Description("Printers")]
    @printers,

    [Description("RegionalOptionsSettings")]
    @regionalOptionsSettings,

    [Description("RegistrySettings")]
    @registrySettings,

    [Description("ScheduledTasks")]
    @scheduledTasks,

    [Description("ShortcutSettings")]
    @shortcutSettings,

    [Description("StartMenuSettings")]
    @startMenuSettings,
}
