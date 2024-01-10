// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryCustomSecurityAttributeDefinitionAllowedValue;

internal class DirectoryCustomSecurityAttributeDefinitionIdAllowedValueId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/customSecurityAttributeDefinitions/{customSecurityAttributeDefinitionId}/allowedValues/{allowedValueId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticCustomSecurityAttributeDefinitions", "customSecurityAttributeDefinitions"),
        ResourceIDSegment.UserSpecified("customSecurityAttributeDefinitionId"),
        ResourceIDSegment.Static("staticAllowedValues", "allowedValues"),
        ResourceIDSegment.UserSpecified("allowedValueId")
    };
}
