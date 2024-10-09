package cleanup

import (
	"fmt"
	"strings"
)

func NormalizeOperationName(operationId string, tag *string) string {
	operationName := operationId
	// in some cases the OperationId *is* the Tag, in this instance I guess we take that as ok?
	if tag != nil && !strings.EqualFold(operationName, *tag) {
		// we're intentionally not using `strings.TrimPrefix` here since we want
		// to account for the casing of the tag being different
		if strings.HasPrefix(strings.ToLower(operationName), strings.ToLower(*tag)) {
			operationName = operationName[len(*tag):]

			// however if the Tag is `ManagementGroupsSubscriptions`, then we need to keep the extra `S` around
			if *tag == "ManagementGroups" && !strings.HasPrefix(operationName, "_") {
				operationName = fmt.Sprintf("S%s", operationName)
			}
		}
	}
	operationName = strings.ReplaceAll(operationName, "_", "")
	operationName = strings.TrimPrefix(operationName, "Operations") // sanity checking
	if !strings.HasPrefix(strings.ToLower(operationName), "subscriptions") {
		operationName = strings.TrimPrefix(operationName, "s") // plurals
	}
	operationName = strings.TrimPrefix(operationName, "_")
	operationName = NormalizeName(operationName)
	return operationName
}

func NormalizeTag(input string) string {
	// NOTE: we could be smarter here, but given this is a handful of cases it's
	// probably prudent to hard-code these for now (and fix the swaggers as we
	// come across them?)
	output := input
	output = strings.ReplaceAll(output, "EndPoint", "Endpoint")
	output = strings.ReplaceAll(output, "NetWork", "Network")
	output = strings.ReplaceAll(output, "Baremetalinfrastructure", "BareMetalInfrastructure")
	output = strings.ReplaceAll(output, "VirtualWans", "VirtualWANs")

	return output
}
