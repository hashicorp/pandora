using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_04_15.Mongorbacs;

internal class MongodbUserDefinitionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{databaseAccountName}/mongodbUserDefinitions/{mongoUserDefinitionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDocumentDB", "Microsoft.DocumentDB"),
        ResourceIDSegment.Static("staticDatabaseAccounts", "databaseAccounts"),
        ResourceIDSegment.UserSpecified("databaseAccountName"),
        ResourceIDSegment.Static("staticMongodbUserDefinitions", "mongodbUserDefinitions"),
        ResourceIDSegment.UserSpecified("mongoUserDefinitionId"),
    };
}
