using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2017-04-01";
        public bool Preview => false;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new AuthorizationRulesDisasterRecoveryConfigs.Definition(),
            new AuthorizationRulesEventHubs.Definition(),
            new AuthorizationRulesNamespaces.Definition(),
            new CheckNameAvailabilityDisasterRecoveryConfigs.Definition(),
            new CheckNameAvailabilityNamespaces.Definition(),
            new ConsumerGroups.Definition(),
            new DisasterRecoveryConfigs.Definition(),
            new EventHubs.Definition(),
            new MessagingPlan.Definition(),
            new Namespaces.Definition(),
            new NetworkRuleSets.Definition(),
            new Regions.Definition(),
        };
    }
}
