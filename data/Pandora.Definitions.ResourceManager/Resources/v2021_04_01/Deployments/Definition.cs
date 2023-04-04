using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_04_01.Deployments;

internal class Definition : ResourceDefinition
{
    public string Name => "Deployments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CalculateTemplateHashOperation(),
        new CancelOperation(),
        new CancelAtManagementGroupScopeOperation(),
        new CancelAtScopeOperation(),
        new CancelAtSubscriptionScopeOperation(),
        new CancelAtTenantScopeOperation(),
        new CheckExistenceOperation(),
        new CheckExistenceAtManagementGroupScopeOperation(),
        new CheckExistenceAtScopeOperation(),
        new CheckExistenceAtSubscriptionScopeOperation(),
        new CheckExistenceAtTenantScopeOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAtManagementGroupScopeOperation(),
        new CreateOrUpdateAtScopeOperation(),
        new CreateOrUpdateAtSubscriptionScopeOperation(),
        new CreateOrUpdateAtTenantScopeOperation(),
        new DeleteOperation(),
        new DeleteAtManagementGroupScopeOperation(),
        new DeleteAtScopeOperation(),
        new DeleteAtSubscriptionScopeOperation(),
        new DeleteAtTenantScopeOperation(),
        new ExportTemplateOperation(),
        new ExportTemplateAtManagementGroupScopeOperation(),
        new ExportTemplateAtScopeOperation(),
        new ExportTemplateAtSubscriptionScopeOperation(),
        new ExportTemplateAtTenantScopeOperation(),
        new GetOperation(),
        new GetAtManagementGroupScopeOperation(),
        new GetAtScopeOperation(),
        new GetAtSubscriptionScopeOperation(),
        new GetAtTenantScopeOperation(),
        new ListAtManagementGroupScopeOperation(),
        new ListAtScopeOperation(),
        new ListAtSubscriptionScopeOperation(),
        new ListAtTenantScopeOperation(),
        new ListByResourceGroupOperation(),
        new ValidateOperation(),
        new ValidateAtManagementGroupScopeOperation(),
        new ValidateAtScopeOperation(),
        new ValidateAtSubscriptionScopeOperation(),
        new ValidateAtTenantScopeOperation(),
        new WhatIfOperation(),
        new WhatIfAtManagementGroupScopeOperation(),
        new WhatIfAtSubscriptionScopeOperation(),
        new WhatIfAtTenantScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AliasPathAttributesConstant),
        typeof(AliasPathTokenTypeConstant),
        typeof(AliasPatternTypeConstant),
        typeof(AliasTypeConstant),
        typeof(ChangeTypeConstant),
        typeof(DeploymentModeConstant),
        typeof(ExpressionEvaluationOptionsScopeTypeConstant),
        typeof(OnErrorDeploymentTypeConstant),
        typeof(PropertyChangeTypeConstant),
        typeof(ProviderAuthorizationConsentStateConstant),
        typeof(ProvisioningStateConstant),
        typeof(WhatIfResultFormatConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AliasModel),
        typeof(AliasPathModel),
        typeof(AliasPathMetadataModel),
        typeof(AliasPatternModel),
        typeof(ApiProfileModel),
        typeof(BasicDependencyModel),
        typeof(DebugSettingModel),
        typeof(DependencyModel),
        typeof(DeploymentModel),
        typeof(DeploymentExportResultModel),
        typeof(DeploymentExtendedModel),
        typeof(DeploymentPropertiesModel),
        typeof(DeploymentPropertiesExtendedModel),
        typeof(DeploymentValidateResultModel),
        typeof(DeploymentWhatIfModel),
        typeof(DeploymentWhatIfPropertiesModel),
        typeof(DeploymentWhatIfSettingsModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorResponseModel),
        typeof(ExpressionEvaluationOptionsModel),
        typeof(OnErrorDeploymentModel),
        typeof(OnErrorDeploymentExtendedModel),
        typeof(ParametersLinkModel),
        typeof(ProviderModel),
        typeof(ProviderExtendedLocationModel),
        typeof(ProviderResourceTypeModel),
        typeof(ResourceReferenceModel),
        typeof(ScopedDeploymentModel),
        typeof(ScopedDeploymentWhatIfModel),
        typeof(TemplateHashResultModel),
        typeof(TemplateLinkModel),
        typeof(WhatIfChangeModel),
        typeof(WhatIfOperationPropertiesModel),
        typeof(WhatIfOperationResultModel),
        typeof(WhatIfPropertyChangeModel),
        typeof(ZoneMappingModel),
    };
}
