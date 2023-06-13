using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.JobStepExecutions;

internal class ExecutionStepId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps/{stepName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSql", "Microsoft.Sql"),
        ResourceIDSegment.Static("staticServers", "servers"),
        ResourceIDSegment.UserSpecified("serverName"),
        ResourceIDSegment.Static("staticJobAgents", "jobAgents"),
        ResourceIDSegment.UserSpecified("jobAgentName"),
        ResourceIDSegment.Static("staticJobs", "jobs"),
        ResourceIDSegment.UserSpecified("jobName"),
        ResourceIDSegment.Static("staticExecutions", "executions"),
        ResourceIDSegment.UserSpecified("jobExecutionId"),
        ResourceIDSegment.Static("staticSteps", "steps"),
        ResourceIDSegment.UserSpecified("stepName"),
    };
}
