using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_06_01.PolicyDefinitions;

internal class Providers2PolicyDefinitionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftManagement", "Microsoft.Management"),
        ResourceIDSegment.Static("staticManagementGroups", "managementGroups"),
        ResourceIDSegment.UserSpecified("managementGroupId"),
        ResourceIDSegment.Static("staticProviders2", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAuthorization", "Microsoft.Authorization"),
        ResourceIDSegment.Static("staticPolicyDefinitions", "policyDefinitions"),
        ResourceIDSegment.UserSpecified("policyDefinitionName"),
    };
}
