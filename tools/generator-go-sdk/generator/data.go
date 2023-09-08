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
	resourceOutputPath string

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

	// resourceIds is a map of key (resourceId name) to value (ResourceIdDefinition)
	// describing the ResourceId's used in these http operations
	resourceIds map[string]resourcemanager.ResourceIdDefinition

	// source describes the original source location for these API Definitions
	source resourcemanager.ApiDefinitionsSource

	// the name of the service as a package (e.g. resources or eventhub)
	servicePackageName string

	// baseClientMethod is the go function for instantiating the particular base client
	baseClientMethod string

	// baseClientPackage is the go package where the base client can be found
	baseClientPackage string

	// commonPackageName is the go package containing common types (models, constants, predicates)
	commonPackageName string

	// commonPackageImportPath is the go import path where common types can be found
	commonPackageImportPath string

	// development feature flag - this requires work in the Resource ID parser to handle name conflicts
	// @tombuildsstuff: fix this
	useIdAliases bool

	// development feature flag - should this service use the new transport layer from `hashicorp/go-azure-sdk`
	// rather than the existing Autorest base layer?
	useNewBaseLayer bool
}

func (i ServiceGeneratorInput) generatorData(settings Settings) ServiceGeneratorData {
	servicePackageName := golangPackageName(i.ServiceName)
	versionPackageName := golangPackageName(i.VersionName)
	// TODO: it'd be nice to make these snake_case but that's a problem for another day
	resourcePackageName := golangPackageName(i.ResourceName)
	versionOutputPath := filepath.Join(i.OutputDirectoryPath, servicePackageName, versionPackageName)
	resourceOutputPath := filepath.Join(versionOutputPath, resourcePackageName)
	idsPath := filepath.Join(versionOutputPath, "ids")
	commonPackageImportPath := fmt.Sprintf("%s/%s", i.OutputSubDirectoryName, i.CommonPackageRelativePath)

	useNewBaseLayer := settings.ShouldUseNewBaseLayer(i.ServiceName, i.VersionName)

	return ServiceGeneratorData{
		apiVersion:              i.VersionName,
		baseClientMethod:        i.BaseClientMethod,
		baseClientPackage:       i.BaseClientPackage,
		commonPackageName:       i.CommonPackageName,
		commonPackageImportPath: commonPackageImportPath,
		constants:               i.ResourceDetails.Schema.Constants,
		idsOutputPath:           idsPath,
		models:                  i.ResourceDetails.Schema.Models,
		operations:              i.ResourceDetails.Operations.Operations,
		resourceOutputPath:      resourceOutputPath,
		packageName:             resourcePackageName,
		resourceIds:             i.ResourceDetails.Schema.ResourceIds,
		serviceClientName:       fmt.Sprintf("%sClient", strings.Title(i.ResourceName)),
		servicePackageName:      strings.ToLower(i.ServiceName),
		source:                  i.Source,
		useIdAliases:            false,
		useNewBaseLayer:         useNewBaseLayer,
	}
}
