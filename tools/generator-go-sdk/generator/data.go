package generator

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ServiceGeneratorData struct {
	// the name of the package which should be used e.g. Service1 becomes service1
	packageName string

	// the name of the Client e.g. MyThingClient
	serviceClientName string

	// This is the output path for Resource IDs, which then gets aliased by packages
	// for example {workingDir}/service/version/ids
	idsOutputPath string

	// This is the working directory where files should be output for this specific service
	// for example {workingDir}/service/version/resource
	outputPath string

	// constants is a map of key (constant name) to value (ConstantDetails) describing
	// the constants and their values used in this Resource
	constants map[string]resourcemanager.ConstantDetails

	// API Version is the default API version for this Resource
	apiVersion string

	// models is a map of key (model name) to value (ModelDetails) describing
	// the models used in this Resource
	models map[string]resourcemanager.ModelDetails

	// operations is a map of key (operation name) to value (ApiOperation) describing
	// the available http operations
	operations map[string]resourcemanager.ApiOperation

	resourceIds map[string]string

	// the name of the service as a package (e.g. resources or eventhub)
	servicePackageName string

	// development feature flag - this requires work in the Resource ID parser to handle name conflicts
	// @tombuildsstuff: fix this
	useIdAliases bool
}

func (i ServiceGeneratorInput) generatorData() ServiceGeneratorData {
	servicePackageName := strings.ToLower(i.ServiceName)
	versionPackageName := strings.ToLower(i.VersionName)
	// TODO: it'd be nice to make these snake_case but that's a problem for another day
	resourcePackageName := strings.ToLower(i.ResourceName)
	outputPath := filepath.Join(i.OutputDirectory, servicePackageName, versionPackageName, resourcePackageName)
	idsPath := filepath.Join(i.OutputDirectory, servicePackageName, versionPackageName, "ids")

	return ServiceGeneratorData{
		apiVersion:         i.VersionName,
		constants:          i.ResourceDetails.Schema.Constants,
		idsOutputPath:      idsPath,
		models:             i.ResourceDetails.Schema.Models,
		operations:         i.ResourceDetails.Operations.Operations,
		outputPath:         outputPath,
		packageName:        resourcePackageName,
		resourceIds:        i.ResourceDetails.Schema.ResourceIds,
		serviceClientName:  fmt.Sprintf("%sClient", strings.Title(i.ResourceName)),
		servicePackageName: strings.ToLower(i.ServiceName),

		useIdAliases: false,
	}
}
