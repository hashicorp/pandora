using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.CheckDataConnectorRequirements;

internal class Definition : ResourceDefinition
{
    public string Name => "CheckDataConnectorRequirements";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DataConnectorsCheckRequirementsPostOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataConnectorAuthorizationStateConstant),
        typeof(DataConnectorKindConstant),
        typeof(DataConnectorLicenseStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AADCheckRequirementsModel),
        typeof(AATPCheckRequirementsModel),
        typeof(ASCCheckRequirementsModel),
        typeof(ASCCheckRequirementsPropertiesModel),
        typeof(AwsCloudTrailCheckRequirementsModel),
        typeof(AwsS3CheckRequirementsModel),
        typeof(DataConnectorRequirementsStateModel),
        typeof(DataConnectorTenantIdModel),
        typeof(DataConnectorsCheckRequirementsModel),
        typeof(Dynamics365CheckRequirementsModel),
        typeof(MCASCheckRequirementsModel),
        typeof(MDATPCheckRequirementsModel),
        typeof(MSTICheckRequirementsModel),
        typeof(MtpCheckRequirementsModel),
        typeof(OfficeATPCheckRequirementsModel),
        typeof(OfficeIRMCheckRequirementsModel),
        typeof(TICheckRequirementsModel),
        typeof(TiTaxiiCheckRequirementsModel),
    };
}
