using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.ConfigurationAssignments;

internal class ScopedConfigurationAssignmentId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMaintenance", "Microsoft.Maintenance"),
        ResourceIDSegment.Static("staticConfigurationAssignments", "configurationAssignments"),
        ResourceIDSegment.UserSpecified("configurationAssignmentName"),
    };
}
