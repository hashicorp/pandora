using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.ReferenceDataSets;

internal class Definition : ResourceDefinition
{
    public string Name => "ReferenceDataSets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByEnvironmentOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataStringComparisonBehaviorConstant),
        typeof(ProvisioningStateConstant),
        typeof(ReferenceDataKeyPropertyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ReferenceDataSetCreateOrUpdateParametersModel),
        typeof(ReferenceDataSetCreationPropertiesModel),
        typeof(ReferenceDataSetKeyPropertyModel),
        typeof(ReferenceDataSetListResponseModel),
        typeof(ReferenceDataSetResourceModel),
        typeof(ReferenceDataSetResourcePropertiesModel),
        typeof(ReferenceDataSetUpdateParametersModel),
    };
}
