using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Incidents;

internal class Definition : ResourceDefinition
{
    public string Name => "Incidents";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AttackTacticConstant),
        typeof(IncidentClassificationConstant),
        typeof(IncidentClassificationReasonConstant),
        typeof(IncidentLabelTypeConstant),
        typeof(IncidentSeverityConstant),
        typeof(IncidentStatusConstant),
        typeof(OwnerTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IncidentModel),
        typeof(IncidentAdditionalDataModel),
        typeof(IncidentLabelModel),
        typeof(IncidentOwnerInfoModel),
        typeof(IncidentPropertiesModel),
        typeof(TeamInformationModel),
    };
}
