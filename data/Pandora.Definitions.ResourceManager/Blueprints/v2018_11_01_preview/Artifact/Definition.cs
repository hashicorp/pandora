using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.Artifact;

internal class Definition : ResourceDefinition
{
    public string Name => "Artifact";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ArtifactKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ArtifactModel),
        typeof(KeyVaultReferenceModel),
        typeof(ParameterValueModel),
        typeof(PolicyAssignmentArtifactModel),
        typeof(PolicyAssignmentArtifactPropertiesModel),
        typeof(RoleAssignmentArtifactModel),
        typeof(RoleAssignmentArtifactPropertiesModel),
        typeof(SecretValueReferenceModel),
        typeof(TemplateArtifactModel),
        typeof(TemplateArtifactPropertiesModel),
    };
}
