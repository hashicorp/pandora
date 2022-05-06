using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Dimensions;

internal class ExternalCloudProviderTypeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.CostManagement/{externalCloudProviderType}/{externalCloudProviderId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
                new()
                {
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftCostManagement",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.CostManagement"
                },

                new()
                {
                    Name = "externalCloudProviderType",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(ExternalCloudProviderTypeConstant)
                },

                new()
                {
                    Name = "externalCloudProviderId",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
