using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRuleAssociations;

internal class ScopedDataCollectionRuleAssociationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{resourceUri}/providers/Microsoft.Insights/dataCollectionRuleAssociations/{associationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("resourceUri"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftInsights", "Microsoft.Insights"),
        ResourceIDSegment.Static("staticDataCollectionRuleAssociations", "dataCollectionRuleAssociations"),
        ResourceIDSegment.UserSpecified("associationName"),
    };
}
