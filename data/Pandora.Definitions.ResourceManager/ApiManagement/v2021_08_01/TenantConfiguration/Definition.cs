using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.TenantConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "TenantConfiguration";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeployOperation(),
        new SaveOperation(),
        new ValidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessIdNameConstant),
        typeof(AsyncOperationStatusConstant),
        typeof(IdentityProviderTypeConstant),
        typeof(NotificationNameConstant),
        typeof(TemplateNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DeployConfigurationParameterPropertiesModel),
        typeof(DeployConfigurationParametersModel),
        typeof(ErrorFieldContractModel),
        typeof(ErrorResponseBodyModel),
        typeof(OperationResultContractModel),
        typeof(OperationResultContractPropertiesModel),
        typeof(OperationResultLogItemContractModel),
        typeof(SaveConfigurationParameterModel),
        typeof(SaveConfigurationParameterPropertiesModel),
    };
}
