using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationWhitelistings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AdaptiveApplicationControlsDeleteOperation(),
        new AdaptiveApplicationControlsGetOperation(),
        new AdaptiveApplicationControlsListOperation(),
        new AdaptiveApplicationControlsPutOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionConstant),
        typeof(ConfigurationStatusConstant),
        typeof(ConnectionTypeConstant),
        typeof(EnforcementModeConstant),
        typeof(EnforcementSupportConstant),
        typeof(ExeConstant),
        typeof(ExecutableConstant),
        typeof(FileTypeConstant),
        typeof(IssueConstant),
        typeof(MsiConstant),
        typeof(RecommendationActionConstant),
        typeof(RecommendationStatusConstant),
        typeof(ScriptConstant),
        typeof(SourceSystemConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdaptiveApplicationControlGroupModel),
        typeof(AdaptiveApplicationControlGroupDataModel),
        typeof(AdaptiveApplicationControlGroupsModel),
        typeof(AdaptiveApplicationControlIssueSummaryModel),
        typeof(PathRecommendationModel),
        typeof(ProtectionModeModel),
        typeof(PublisherInfoModel),
        typeof(UserRecommendationModel),
        typeof(VMRecommendationModel),
    };
}
