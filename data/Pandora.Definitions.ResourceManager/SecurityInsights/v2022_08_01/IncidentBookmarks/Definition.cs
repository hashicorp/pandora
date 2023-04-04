using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.IncidentBookmarks;

internal class Definition : ResourceDefinition
{
    public string Name => "IncidentBookmarks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new IncidentsListBookmarksOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertSeverityConstant),
        typeof(AlertStatusConstant),
        typeof(AttackTacticConstant),
        typeof(ConfidenceLevelConstant),
        typeof(ConfidenceScoreStatusConstant),
        typeof(EntityKindEnumConstant),
        typeof(IncidentSeverityConstant),
        typeof(KillChainIntentConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EntityModel),
        typeof(HuntingBookmarkModel),
        typeof(HuntingBookmarkPropertiesModel),
        typeof(IncidentBookmarkListModel),
        typeof(IncidentInfoModel),
        typeof(SecurityAlertModel),
        typeof(SecurityAlertPropertiesModel),
        typeof(SecurityAlertPropertiesConfidenceReasonsInlinedModel),
        typeof(UserInfoModel),
    };
}
