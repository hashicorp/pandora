using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.SubAssessments;

internal class Definition : ResourceDefinition
{
    public string Name => "SubAssessments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
        new ListAllOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssessedResourceTypeConstant),
        typeof(SeverityConstant),
        typeof(SourceConstant),
        typeof(SubAssessmentStatusCodeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdditionalDataModel),
        typeof(CVEModel),
        typeof(CVSSModel),
        typeof(ContainerRegistryVulnerabilityPropertiesModel),
        typeof(ResourceDetailsModel),
        typeof(SecuritySubAssessmentModel),
        typeof(SecuritySubAssessmentPropertiesModel),
        typeof(ServerVulnerabilityPropertiesModel),
        typeof(SqlServerVulnerabilityPropertiesModel),
        typeof(SubAssessmentStatusModel),
        typeof(VendorReferenceModel),
    };
}
