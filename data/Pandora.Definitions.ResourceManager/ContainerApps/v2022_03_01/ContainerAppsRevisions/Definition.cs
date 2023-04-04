using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsRevisions;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerAppsRevisions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ActivateRevisionOperation(),
        new DeactivateRevisionOperation(),
        new GetRevisionOperation(),
        new ListRevisionsOperation(),
        new RestartRevisionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RevisionHealthStateConstant),
        typeof(RevisionProvisioningStateConstant),
        typeof(SchemeConstant),
        typeof(StorageTypeConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContainerModel),
        typeof(ContainerAppProbeModel),
        typeof(ContainerAppProbeHTTPGetModel),
        typeof(ContainerAppProbeHTTPGetHTTPHeadersInlinedModel),
        typeof(ContainerAppProbeTcpSocketModel),
        typeof(ContainerResourcesModel),
        typeof(CustomScaleRuleModel),
        typeof(EnvironmentVarModel),
        typeof(HTTPScaleRuleModel),
        typeof(QueueScaleRuleModel),
        typeof(RevisionModel),
        typeof(RevisionPropertiesModel),
        typeof(ScaleModel),
        typeof(ScaleRuleModel),
        typeof(ScaleRuleAuthModel),
        typeof(TemplateModel),
        typeof(VolumeModel),
        typeof(VolumeMountModel),
    };
}
