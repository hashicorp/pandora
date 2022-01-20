using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.GenerateDetailedCostReportOperationStatus;

internal class ScopedOperationStatuId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.CostManagement/operationStatus/{operationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
                new()
                {
                    Name = "scope",
                    Type = ResourceIDSegmentType.Scope
                },

                new()
                {
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftCostManagement",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.CostManagement"
                },

                new()
                {
                    Name = "staticOperationStatus",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "operationStatus"
                },

                new()
                {
                    Name = "operationId",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
