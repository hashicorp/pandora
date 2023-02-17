using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.DscCompilationJob;

internal class AutomationCompilationJobId : ResourceID
{
    public string? CommonAlias => "AutomationCompilationJob";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/compilationJobs/{compilationJobId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.Automation"),
        ResourceIDSegment.Static("automationAccounts", "automationAccounts"),
        ResourceIDSegment.UserSpecified("automationAccountName"),
        ResourceIDSegment.Static("compilationJobs", "compilationJobs"),
        ResourceIDSegment.UserSpecified("compilationJobId"),
    };
}
