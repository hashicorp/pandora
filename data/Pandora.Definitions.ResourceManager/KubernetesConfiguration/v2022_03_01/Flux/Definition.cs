using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.Flux;

internal class Definition : ResourceDefinition
{
    public string Name => "Flux";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConfigurationsCreateOrUpdateOperation(),
        new ConfigurationsDeleteOperation(),
        new ConfigurationsGetOperation(),
        new ConfigurationsListOperation(),
        new ConfigurationsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FluxComplianceStateConstant),
        typeof(ProvisioningStateConstant),
        typeof(ScopeTypeConstant),
        typeof(SourceKindTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BucketDefinitionModel),
        typeof(BucketPatchDefinitionModel),
        typeof(FluxConfigurationModel),
        typeof(FluxConfigurationPatchModel),
        typeof(FluxConfigurationPatchPropertiesModel),
        typeof(FluxConfigurationPropertiesModel),
        typeof(GitRepositoryDefinitionModel),
        typeof(GitRepositoryPatchDefinitionModel),
        typeof(HelmReleasePropertiesDefinitionModel),
        typeof(KustomizationDefinitionModel),
        typeof(KustomizationPatchDefinitionModel),
        typeof(ObjectReferenceDefinitionModel),
        typeof(ObjectStatusConditionDefinitionModel),
        typeof(ObjectStatusDefinitionModel),
        typeof(RepositoryRefDefinitionModel),
    };
}
