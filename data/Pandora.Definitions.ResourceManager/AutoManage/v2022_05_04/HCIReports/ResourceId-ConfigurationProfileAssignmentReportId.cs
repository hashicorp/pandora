using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AutoManage.v2022_05_04.HCIReports;

internal class ConfigurationProfileAssignmentReportId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.AutoManage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftHybridCompute", "Microsoft.HybridCompute"),
        ResourceIDSegment.Static("staticMachines", "machines"),
        ResourceIDSegment.UserSpecified("machineName"),
        ResourceIDSegment.Static("staticProviders2", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAutoManage", "Microsoft.AutoManage"),
        ResourceIDSegment.Static("staticConfigurationProfileAssignments", "configurationProfileAssignments"),
        ResourceIDSegment.UserSpecified("configurationProfileAssignmentName"),
        ResourceIDSegment.Static("staticReports", "reports"),
        ResourceIDSegment.UserSpecified("reportName"),
    };
}
