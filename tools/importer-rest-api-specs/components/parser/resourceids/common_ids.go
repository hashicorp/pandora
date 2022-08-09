package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type commonIdMatcher interface {
	// id returns the Resource ID for this Common ID
	id() models.ParsedResourceId
}

var commonIdTypes = []commonIdMatcher{
	commonIdManagementGroupMatcher{},
	commonIdResourceGroupMatcher{},
	commonIdSubscriptionMatcher{},
	commonIdScopeMatcher{},
	commonIdUserAssignedIdentity{},

	// Network ids
	// "Core"
	commonIdNetworkInterface{},
	commonIdPublicIPAddress{},
	commonIdVPNConnection{},

	// RP Spcific
	commonIdCloudServicesIPConfiguration{},
	commonIdCloudServicesPublicIPAddress{},
	commonIdExpressRouteCircuitPeering{},
	commonIdNetworkInterfaceIPConfiguration{},
	commonIdVirtualHubBGPConnection{},
	commonIdVirtualHubIPConfiguration{},
	commonIdVirtualMachineScaleSetIPConfiguration{},
	commonIdVirtualMachineScaleSetNetworkInterface{},
	commonIdVirtualMachineScaleSetPublicIPAddress{},
	commonIdVirtualRouterPeering{},
	commonIdVirtualWANP2SVPNGateway{},
}

func switchOutCommonResourceIDsAsNeeded(input []models.ParsedResourceId) []models.ParsedResourceId {
	output := make([]models.ParsedResourceId, 0)

	for _, value := range input {
		for _, commonId := range commonIdTypes {
			if commonId.id().Matches(value) {
				value = commonId.id()
				break
			}
		}

		output = append(output, value)
	}

	return output
}

//var overloadedIDNames = []string{
//	"bgpConnections",
//	"ipconfigurations",
//	"peerings",
//	"p2svpnGateways",
//	"publicipaddresses",
//}

//func uniquifyOverloadedIdNames(input []models.ParsedResourceId) []models.ParsedResourceId {
//	//output := make([]models.ParsedResourceId, 0)
//
//	for i, v := range input {
//		for _, n := range overloadedIDNames {
//			if v.CommonAlias != nil && *v.CommonAlias != "" {
//				continue
//			}
//
//			segmentCount := len(v.Segments)
//			if name := v.Segments[segmentCount-2].FixedValue; name != nil && strings.EqualFold(*name, n) {
//				for o, p := range v.Segments {
//					if p.Type == resourcemanager.ResourceProviderSegment {
//						//grab the next static segment for the unique name
//						prefix := v.Segments[o+1].FixedValue
//						if prefix != nil && strings.EqualFold(*prefix, n) {
//							// This is the top level ID, not a resource specific, so just add it back in
//							//output = append(output, v)
//							break
//						} else {
//							newName := fmt.Sprintf("%s%s", *v.Segments[o+1].FixedValue, n)
//
//							newId := models.ParsedResourceId{
//								CommonAlias: &newName,
//								Constants:   map[string]resourcemanager.ConstantDetails{},
//								Segments:    v.Segments,
//							}
//							//output = append(output, newId)
//							input[i] = newId
//							break
//						}
//					}
//				}
//			}
//		}
//		//output = append(output, v)
//	}
//
//	return input
//}
