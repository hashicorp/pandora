using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.Assessments;

internal class Definition : ResourceDefinition
{
    public string Name => "Assessments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssessmentStatusCodeConstant),
        typeof(ExpandEnumConstant),
        typeof(SourceConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssessmentLinksModel),
        typeof(AssessmentStatusModel),
        typeof(ResourceDetailsModel),
        typeof(SecurityAssessmentModel),
        typeof(SecurityAssessmentPropertiesModel),
    };
}
