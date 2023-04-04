using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts;

internal class Definition : ResourceDefinition
{
    public string Name => "Alerts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DismissOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListExternalOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertCategoryConstant),
        typeof(AlertCriteriaConstant),
        typeof(AlertOperatorConstant),
        typeof(AlertSourceConstant),
        typeof(AlertStatusConstant),
        typeof(AlertTimeGrainTypeConstant),
        typeof(AlertTypeConstant),
        typeof(ExternalCloudProviderTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AlertModel),
        typeof(AlertPropertiesModel),
        typeof(AlertPropertiesDefinitionModel),
        typeof(AlertPropertiesDetailsModel),
        typeof(AlertsResultModel),
        typeof(DismissAlertPayloadModel),
    };
}
