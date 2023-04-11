using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.RegulatoryCompliance;

internal class Definition : ResourceDefinition
{
    public string Name => "RegulatoryCompliance";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssessmentsGetOperation(),
        new AssessmentsListOperation(),
        new ControlsGetOperation(),
        new ControlsListOperation(),
        new StandardsGetOperation(),
        new StandardsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(StateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RegulatoryComplianceAssessmentModel),
        typeof(RegulatoryComplianceAssessmentPropertiesModel),
        typeof(RegulatoryComplianceControlModel),
        typeof(RegulatoryComplianceControlPropertiesModel),
        typeof(RegulatoryComplianceStandardModel),
        typeof(RegulatoryComplianceStandardPropertiesModel),
    };
}
