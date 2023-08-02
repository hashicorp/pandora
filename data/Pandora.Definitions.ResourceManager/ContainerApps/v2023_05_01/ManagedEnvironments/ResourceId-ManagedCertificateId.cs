using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ManagedEnvironments;

internal class ManagedCertificateId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/managedEnvironments/{managedEnvironmentName}/managedCertificates/{managedCertificateName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftApp", "Microsoft.App"),
        ResourceIDSegment.Static("staticManagedEnvironments", "managedEnvironments"),
        ResourceIDSegment.UserSpecified("managedEnvironmentName"),
        ResourceIDSegment.Static("staticManagedCertificates", "managedCertificates"),
        ResourceIDSegment.UserSpecified("managedCertificateName"),
    };
}
