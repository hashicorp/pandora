using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-10-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AggregatedCost.Definition(),
        new Balances.Definition(),
        new Budgets.Definition(),
        new Charges.Definition(),
        new Credits.Definition(),
        new Events.Definition(),
        new Forecasts.Definition(),
        new Lots.Definition(),
        new Marketplaces.Definition(),
        new PriceSheet.Definition(),
        new ReservationDetails.Definition(),
        new ReservationRecommendationDetails.Definition(),
        new ReservationRecommendations.Definition(),
        new ReservationSummaries.Definition(),
        new ReservationTransactions.Definition(),
        new UsageDetails.Definition(),
    };
}
