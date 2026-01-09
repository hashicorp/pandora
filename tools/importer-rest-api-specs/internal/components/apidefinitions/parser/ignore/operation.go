// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package ignore

import "strings"

func Operation(operationUri string) bool {
	loweredOperationUri := strings.ToLower(operationUri)

	// we're not concerned with exposing the "operations" API's at this time - e.g.
	// /providers/Microsoft.CognitiveServices/operations
	if strings.HasPrefix(loweredOperationUri, "/providers/") {
		split := strings.Split(strings.TrimPrefix(operationUri, "/"), "/")
		if len(split) == 3 && strings.EqualFold(split[2], "operations") {
			return true
		}
	}

	// LRO's shouldn't be directly exposed
	pathsContainingLROs := map[string]struct{}{
		"/ascoperations/":                             {},
		"/azureasyncoperations/":                      {},
		"/backupcrroperationresults/":                 {},
		"/backupoperationresults/":                    {},
		"/backupvalidateoperationresults/":            {},
		"/costdetailsoperationresults/":               {},
		"/deploymentstatus/":                          {},
		"/managedclusteroperations/":                  {},
		"/managedclusteroperationresults/":            {},
		"/manageddatabasemoveoperationresults/":       {},
		"/mediaservicesoperationresults/":             {},
		"/mediaservicesoperationstatuses/":            {},
		"/operationlocations/":                        {},
		"/operationresults/":                          {},
		"/operationstatus/":                           {},
		"/operationstatuses/":                         {},
		"/operationsstatus/":                          {},
		"/privatelinkscopeoperationstatuses/":         {},
		"/recommendedactionsessionsoperationresults/": {},

		// Tags within this package is unnecessary
		"/providers/microsoft.consumption/tags": {},

		// usageDetails doesn't make sense for our use-cases
		"/providers/microsoft.consumption/usagedetails": {},

		// we can't just use `/operations` since some APIs (e.g. API Management) expose these, so we're intentionally
		// checking more (but not all) of the path
		// /providers/Microsoft.KubernetesConfiguration/extensions/{extensionName}/operations/{operationId}
		"/providers/microsoft.dataprotection/backupvaults/{backupvaultname}/backupjobs/operations/{operationid}":           {},
		"/providers/microsoft.kubernetesconfiguration/fluxconfigurations/{fluxconfigurationname}/operations/{operationid}": {},
		"/providers/microsoft.kubernetesconfiguration/extensions/{extensionname}/operations/{operationid}":                 {},
		"/providers/microsoft.sql/servers/{servername}/databases/{databasename}/operations/{operationid}":                  {},
		"/providers/microsoft.sql/managedinstances/{managedinstancename}/operations/{operationid}":                         {},
		"/providers/microsoft.storagesync/locations/{locationname}/workflows/{workflowid}/operations/{operationid}":        {},
		"/providers/microsoft.storagesync/locations/{locationName}/operations/{operationid}":                               {},
	}
	for key := range pathsContainingLROs {
		if strings.Contains(loweredOperationUri, key) {
			return true
		}
	}

	// we're not concerned with the associated `trigger` operations at this time
	if strings.Contains(loweredOperationUri, "/backuptriggervalidateoperation/") {
		return true
	}

	return false
}
