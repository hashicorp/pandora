using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.Metadata;

internal class MetadataId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Advisor/metadata/{metadataName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAdvisor", "Microsoft.Advisor"),
        ResourceIDSegment.Static("staticMetadata", "metadata"),
        ResourceIDSegment.UserSpecified("metadataName"),
    };
}
