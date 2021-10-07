using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.PrivateEndpointConnections
{
    internal class AttestationProviderId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Attestation/attestationProvider/{providerName}";

        public List<ResourceIDSegment> Segments()
        {
            return new List<ResourceIDSegment>
            {
                new()
                {
                    Name = "subscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "subscriptions"
                },

                new()
                {
                    Name = "subscriptionId",
                    Type = ResourceIDSegmentType.SubscriptionId
                },

                new()
                {
                    Name = "resourceGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "resourceGroups"
                },

                new()
                {
                    Name = "resourceGroupName",
                    Type = ResourceIDSegmentType.ResourceGroup
                },

                new()
                {
                    Name = "providers",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "microsoftAttestation",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Attestation"
                },

                new()
                {
                    Name = "attestationProvider",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "attestationProvider"
                },

                new()
                {
                    Name = "providerName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
