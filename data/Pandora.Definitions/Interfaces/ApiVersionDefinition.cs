using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces;

public interface ApiVersionDefinition
{
    // TODO: we should make "Preview" (and potentially Generate) smarter here
    // e.g. is this API available in this region, or in Preview in that region

    /// <summary>
    /// ApiVersion returns the version for this API.
    /// </summary>
    string ApiVersion { get; }

    /// <summary>
    /// Generate specifies whether this API Version should be generated. 
    /// </summary>
    bool Generate { get; }

    /// <summary>
    /// Preview specifies whether or not this is API Version is a Preview (Public, Private or otherwise).
    /// </summary>
    bool Preview { get; }

    /// <summary>
    /// Resources returns a list of ResourceDefinitions for this API Version.
    /// </summary>
    IEnumerable<ResourceDefinition> Resources { get; }

    /// <summary>
    /// Source specifies where the API Definitions were sourced from.
    /// </summary>
    Source Source { get; }
}