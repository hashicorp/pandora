package internal

import "strings"

func OperationShouldBeIgnored(operationUri string) bool {
	// we're not concerned with exposing the "operations" API's at this time - e.g.
	// /providers/Microsoft.CognitiveServices/operations
	if strings.HasPrefix(strings.ToLower(operationUri), "/providers/") {
		split := strings.Split(strings.TrimPrefix(operationUri, "/"), "/")
		if len(split) == 3 && strings.EqualFold(split[2], "operations") {
			return true
		}
	}

	// LRO's shouldn't be directly exposed
	if strings.Contains(strings.ToLower(operationUri), "/azureasyncoperations/") {
		return true
	}
	if strings.Contains(strings.ToLower(operationUri), "/backupoperationresults/") {
		return true
	}
	if strings.Contains(strings.ToLower(operationUri), "/backupvalidateoperationresults/") {
		return true
	}
	if strings.Contains(strings.ToLower(operationUri), "/costdetailsoperationresults/") {
		return true
	}
	if strings.Contains(strings.ToLower(operationUri), "/operationresults/") {
		return true
	}
	if strings.Contains(strings.ToLower(operationUri), "/operationstatus/") {
		return true
	}
	if strings.Contains(strings.ToLower(operationUri), "/operationstatuses/") {
		return true
	}
	if strings.Contains(strings.ToLower(operationUri), "/operationsstatus/") {
		return true
	}

	// we're not concerned with the associated `trigger` operations at this time
	if strings.Contains(strings.ToLower(operationUri), "/backuptriggervalidateoperation/") {
		return true
	}

	return false
}
