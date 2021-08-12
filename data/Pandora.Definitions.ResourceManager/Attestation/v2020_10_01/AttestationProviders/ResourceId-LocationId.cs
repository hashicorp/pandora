using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders
{
    internal class LocationId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.Attestation/locations/{location}";
    }
}
