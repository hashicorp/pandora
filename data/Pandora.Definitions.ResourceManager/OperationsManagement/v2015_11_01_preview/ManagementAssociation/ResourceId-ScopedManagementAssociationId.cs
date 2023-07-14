using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationsManagement.v2015_11_01_preview.ManagementAssociation;

internal class ScopedManagementAssociationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.OperationsManagement/managementAssociations/{managementAssociationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftOperationsManagement", "Microsoft.OperationsManagement"),
        ResourceIDSegment.Static("staticManagementAssociations", "managementAssociations"),
        ResourceIDSegment.UserSpecified("managementAssociationName"),
    };
}
