// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package ignore

import "strings"

func Services(name string) bool {
	servicesToIgnore := []string{
		"ADHybridHealthService", // EOL? Contains a Constant of an empty string: https://github.com/Azure/azure-rest-api-specs/blob/3eaa729b3686f20817145e771a8ab707c739dbbd/specification/adhybridhealthservice/resource-manager/Microsoft.ADHybridHealthService/stable/2014-01-01/ADHybridHealthService.json#L460-L471
		"Blockchain",            // EOL - https://github.com/Azure-Samples/blockchain/blob/1b712d6d05cca8da17bdd1894de8c3d25905685d/abs/migration-guide.md
		"DevSpaces",             // EOL - https://azure.microsoft.com/en-us/updates/azure-dev-spaces-is-retiring-on-31-october-2023/
		"DynamicsTelemetry",     // Fake RP - https://github.com/Azure/azure-rest-api-specs/pull/5161#issuecomment-486705231
		"IoTSpaces",             // EOL - https://github.com/Azure/azure-rest-api-specs/pull/13993
		"ServiceFabricMesh",     // EOL - https://azure.microsoft.com/en-us/updates/azure-service-fabric-mesh-preview-retirement/
	}
	for _, v := range servicesToIgnore {
		if strings.EqualFold(name, v) {
			return true
		}
	}
	return false
}
