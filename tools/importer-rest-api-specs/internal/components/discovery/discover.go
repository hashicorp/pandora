package discovery

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

func DiscoverForService(workingDirectory string, service services.Service) (*models.AvailableDataSet, error) {
	logging.Infof("Discovering API Definitions for Service %q within %q..", service.Name, workingDirectory)
	specificationsDirectory := filepath.Join(workingDirectory, "specification")
	serviceDirectory, err := filepath.Abs(filepath.Join(specificationsDirectory, service.Directory))
	if err != nil {
		return nil, fmt.Errorf("determining the absolute path to Service %q in %q: %+v", serviceDirectory, workingDirectory, err)
	}

	dataSetsForAPIVersions := make(map[string]models.AvailableDataSetForAPIVersion)
	for _, apiVersion := range service.Available {
		// Most API Definitions are structured under:
		// /specification/{serviceName}/resource-manager/{ResourceProvider}/(stable|preview)/{apiVersion}
		// e.g. `specification/addons/resource-manager/Microsoft.Addons/preview/(2017-05-15|2018-03-01)`
		// which are currently built-from the TypeSpec housed within
		// `specification/{serviceName}/{ResourceProvider}` (e.g. `specification/containerservice/Fleet.Management`)
		//
		// However some Services contain a single Resource Provider which is split up into smaller chunks due to the
		// size of the Resource Provider, which Microsoft calls a `Service Group`:
		// https://github.com/Azure/azure-rest-api-specs/blob/abad0096677005817d2c19df2364663e5583c8fc/documentation/directory-structure.md#about-legacy-deprecated-directory-structure-for-services-and-service-groups
		// which is LEGACY and DEPRECATED - however we still need to parse these Services.
		// Example:
		//   ./specification/mediaservices/
		//
		// In addition, some Services contain Services from multiple Resource Providers, so these need to be flattened
		// into a single set of data. This can be combined with a Service Group, for example Compute:
		//   ./specification/compute/resource-manager/{ResourceProvider}/(Grouping)/(stable|preview)/{apiVersion}
		//   ./specification/compute/resource-manager/Microsoft.Compute/CloudserviceRP/stable/2022-09-04

	}

	return &models.AvailableDataSet{
		ServiceName:            service.Name,
		DataSetsForAPIVersions: dataSetsForAPIVersions,
		ResourceProvider:       service.ResourceProvider,
	}, nil
}
