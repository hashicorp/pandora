using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ContainerAppsRevisions;

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
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContainerModel),
        typeof(ContainerResourcesModel),
        typeof(CustomScaleRuleModel),
        typeof(DaprModel),
        typeof(DaprComponentModel),
        typeof(DaprMetadataModel),
        typeof(EnvironmentVarModel),
        typeof(HTTPScaleRuleModel),
        typeof(QueueScaleRuleModel),
        typeof(RevisionModel),
        typeof(RevisionPropertiesModel),
        typeof(ScaleModel),
        typeof(ScaleRuleModel),
        typeof(ScaleRuleAuthModel),
        typeof(TemplateModel),
    };
}
