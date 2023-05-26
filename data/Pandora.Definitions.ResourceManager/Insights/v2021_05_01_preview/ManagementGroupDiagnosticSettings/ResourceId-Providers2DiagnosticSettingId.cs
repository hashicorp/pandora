using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.ManagementGroupDiagnosticSettings;

internal class Providers2DiagnosticSettingId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Insights/diagnosticSettings/{diagnosticSettingName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftManagement", "Microsoft.Management"),
        ResourceIDSegment.Static("staticManagementGroups", "managementGroups"),
        ResourceIDSegment.UserSpecified("managementGroupId"),
        ResourceIDSegment.Static("staticProviders2", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftInsights", "Microsoft.Insights"),
        ResourceIDSegment.Static("staticDiagnosticSettings", "diagnosticSettings"),
        ResourceIDSegment.UserSpecified("diagnosticSettingName"),
    };
}
