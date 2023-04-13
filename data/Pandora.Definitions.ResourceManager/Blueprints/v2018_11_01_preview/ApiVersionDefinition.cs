using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-11-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Artifact.Definition(),
        new Assignment.Definition(),
        new AssignmentOperations.Definition(),
        new Blueprint.Definition(),
        new BlueprintAssignments.Definition(),
        new PublishedArtifact.Definition(),
        new PublishedBlueprint.Definition(),
    };
}
