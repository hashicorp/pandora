using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Backend;

internal class Definition : ResourceDefinition
{
    public string Name => "Backend";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListByServiceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackendProtocolConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackendAuthorizationHeaderCredentialsModel),
        typeof(BackendCircuitBreakerModel),
        typeof(BackendContractModel),
        typeof(BackendContractPropertiesModel),
        typeof(BackendCredentialsContractModel),
        typeof(BackendPropertiesModel),
        typeof(BackendProxyContractModel),
        typeof(BackendServiceFabricClusterPropertiesModel),
        typeof(BackendTlsPropertiesModel),
        typeof(BackendUpdateParameterPropertiesModel),
        typeof(BackendUpdateParametersModel),
        typeof(CircuitBreakerFailureConditionModel),
        typeof(CircuitBreakerRuleModel),
        typeof(FailureStatusCodeRangeModel),
        typeof(X509CertificateNameModel),
    };
}
