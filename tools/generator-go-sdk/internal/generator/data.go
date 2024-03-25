// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
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

	// constants is a map of Constant Name (key) to SDKConstant (value) describing
	// the constants and their values used in this Resource
	constants map[string]models.SDKConstant

	// API Version is the default API version for this Resource
	apiVersion string

	// models is a map of Model Name (key) to SDKModel (value) describing
	// the models used in this Resource
	models map[string]models.SDKModel

	// operations is a map of Operation Name (key) to SDKOperation (value) describing
	// the available http operations
	operations map[string]models.SDKOperation

	// resourceIds is a map of key (resourceId name) to value (ResourceIdDefinition)
	// describing the ResourceId's used in these http operations
	resourceIds map[string]models.ResourceID

	// source describes the original source location for these API Definitions
	source models.SourceDataOrigin

	// the name of the service as a package (e.g. resources or eventhub)
	servicePackageName string

	// development feature flag - this requires work in the Resource ID parser to handle name conflicts
	// @tombuildsstuff: fix this
	useIdAliases bool

	// development feature flag - should this service use the new transport layer from `hashicorp/go-azure-sdk`
	// rather than the existing Autorest base layer?
	useNewBaseLayer bool
}

func (i ServiceGeneratorInput) generatorData(settings Settings) ServiceGeneratorData {
	servicePackageName := strings.ToLower(i.ServiceName)
	versionPackageName := strings.ToLower(i.VersionName)
	// TODO: it'd be nice to make these snake_case but that's a problem for another day
	resourcePackageName := strings.ToLower(i.ResourceName)
	versionOutputPath := filepath.Join(i.OutputDirectory, servicePackageName, versionPackageName)
	resourceOutputPath := filepath.Join(versionOutputPath, resourcePackageName)
	idsPath := filepath.Join(versionOutputPath, "ids")

	useNewBaseLayer := settings.ShouldUseNewBaseLayer(i.ServiceName, i.VersionName)

	return ServiceGeneratorData{
		apiVersion:         i.VersionName,
		constants:          i.ResourceDetails.Constants,
		idsOutputPath:      idsPath,
		models:             i.ResourceDetails.Models,
		operations:         i.ResourceDetails.Operations,
		resourceOutputPath: resourceOutputPath,
		packageName:        resourcePackageName,
		resourceIds:        i.ResourceDetails.ResourceIDs,
		serviceClientName:  fmt.Sprintf("%sClient", strings.Title(i.ResourceName)),
		servicePackageName: strings.ToLower(i.ServiceName),
		source:             i.Source,
		useIdAliases:       false,
		useNewBaseLayer:    useNewBaseLayer,
	}
}
