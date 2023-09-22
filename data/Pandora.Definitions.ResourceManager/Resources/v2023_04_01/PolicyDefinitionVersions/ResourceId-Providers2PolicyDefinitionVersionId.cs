using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01.PolicyDefinitionVersions;

internal class Providers2PolicyDefinitionVersionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Management/managementGroups/{managementGroupName}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/versions/{versionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftManagement", "Microsoft.Management"),
        ResourceIDSegment.Static("staticManagementGroups", "managementGroups"),
        ResourceIDSegment.UserSpecified("managementGroupName"),
        ResourceIDSegment.Static("staticProviders2", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAuthorization", "Microsoft.Authorization"),
        ResourceIDSegment.Static("staticPolicyDefinitions", "policyDefinitions"),
        ResourceIDSegment.UserSpecified("policyDefinitionName"),
        ResourceIDSegment.Static("staticVersions", "versions"),
        ResourceIDSegment.UserSpecified("versionName"),
    };
}
