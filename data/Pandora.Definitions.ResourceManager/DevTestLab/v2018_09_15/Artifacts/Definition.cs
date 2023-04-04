using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Artifacts;

internal class Definition : ResourceDefinition
{
    public string Name => "Artifacts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GenerateArmTemplateOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FileUploadOptionsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ArmTemplateInfoModel),
        typeof(ArtifactModel),
        typeof(ArtifactPropertiesModel),
        typeof(GenerateArmTemplateRequestModel),
        typeof(ParameterInfoModel),
    };
}
