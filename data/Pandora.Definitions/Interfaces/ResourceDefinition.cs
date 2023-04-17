using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces;

/// <summary>
/// A ResourceDefinition is a grouping of Resources within a given API Version
/// which contains related operations. For example the API Resource `VirtualMachines`
/// exists within API Version `2020-01-01` within the Service `Compute` which may support
/// Create and Start/Stop as Operations.
/// </summary>
public interface ResourceDefinition
{
    // Name specifies the name of this API Resource
    string Name { get; }

    // Operations is a list of ApiOperations present within this API Resource
    IEnumerable<ApiOperation> Operations { get; }

    /// <summary>
    /// Constants defines the list of Constants Types used within this API Resource - including any
    /// used in either the Options payload/Resource ID too.
    /// </summary>
    IEnumerable<System.Type> Constants { get; }

    /// <summary>
    /// Models defines the list of Model Types used within this API Resource - including the discriminated
    /// types too.
    /// </summary>
    IEnumerable<System.Type> Models { get; }
}