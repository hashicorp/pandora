using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkFunction.v2022_08_01.AzureTrafficCollectors;

internal class Definition : ResourceDefinition
{
    public string Name => "AzureTrafficCollectors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ByResourceGroupListOperation(),
        new BySubscriptionListOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreatedByTypeConstant),
        typeof(DestinationTypeConstant),
        typeof(EmissionTypeConstant),
        typeof(IngestionTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(SourceTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureTrafficCollectorModel),
        typeof(AzureTrafficCollectorPropertiesFormatModel),
        typeof(CollectorPolicyModel),
        typeof(CollectorPolicyPropertiesFormatModel),
        typeof(EmissionPoliciesPropertiesFormatModel),
        typeof(EmissionPolicyDestinationModel),
        typeof(IngestionPolicyPropertiesFormatModel),
        typeof(IngestionSourcesPropertiesFormatModel),
        typeof(ResourceReferenceModel),
        typeof(SystemDataModel),
        typeof(TagsObjectModel),
    };
}
