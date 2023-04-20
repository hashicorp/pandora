using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.AssessmentsMetadata;

internal class Definition : ResourceDefinition
{
    public string Name => "AssessmentsMetadata";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssessmentsMetadataCreateInSubscriptionOperation(),
        new AssessmentsMetadataDeleteInSubscriptionOperation(),
        new AssessmentsMetadataGetOperation(),
        new AssessmentsMetadataGetInSubscriptionOperation(),
        new AssessmentsMetadataListOperation(),
        new AssessmentsMetadataListBySubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssessmentTypeConstant),
        typeof(CategoriesConstant),
        typeof(ImplementationEffortConstant),
        typeof(SeverityConstant),
        typeof(TacticsConstant),
        typeof(TechniquesConstant),
        typeof(ThreatsConstant),
        typeof(UserImpactConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SecurityAssessmentMetadataPartnerDataModel),
        typeof(SecurityAssessmentMetadataPropertiesResponseModel),
        typeof(SecurityAssessmentMetadataPropertiesResponsePublishDatesModel),
        typeof(SecurityAssessmentMetadataResponseModel),
    };
}
