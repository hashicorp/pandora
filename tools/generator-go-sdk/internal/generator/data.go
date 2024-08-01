// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type GeneratorData struct {
	// the name of the package which should be used
	packageName string

	// baseClientPackage is the name of the base client package to use for this SDK
	baseClientPackage string

	// commonTypes contains any common models and constants for this API version
	commonTypes models.CommonTypes

	// the name of the package containing common types (unique to the API version)
	commonTypesPackageName *string

	// relative include path for common types package
	commonTypesIncludePath *string

	// the name of the Client e.g. MyThingClient
	serviceClientName string

	// This is the working directory where files should be output for this specific service
	// for example {workingDir}/{service}/{version}/{resource}
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

	// sourceType is the source data type and is the SDK package name
	sourceType models.SourceDataType

	// whether this is a data plane SDK (omits certain Resource Manager specific features, currently used in ID parsers)
	isDataPlane bool

	// development feature flag - should this service use the new transport layer from `hashicorp/go-azure-sdk`
	// rather than the existing Autorest base layer?
	useNewBaseLayer bool
}

func (i ServiceGeneratorInput) generatorData(settings Settings) GeneratorData {
	resourcePackageName := strings.ToLower(i.ResourceName)
	servicePackageName := strings.ToLower(i.ServiceName)
	versionPackageName := strings.ToLower(i.VersionName)

	versionOutputPath := filepath.Join(i.OutputDirectory, servicePackageName, versionPackageName)
	resourceOutputPath := filepath.Join(versionOutputPath, resourcePackageName)

	useNewBaseLayer := settings.ShouldUseNewBaseLayer(i.ServiceName, i.VersionName)

	var commonTypesPackageName, commonTypesIncludePath *string
	if len(i.CommonTypes.Constants) > 0 && len(i.CommonTypes.Models) > 0 {
		commonTypesPackageName = pointer.To(strings.ToLower(strings.ReplaceAll(i.VersionName, "-", "_")))
		commonTypesIncludePath = pointer.To(fmt.Sprintf("%s/%s", settings.CommonTypesPackageName, *commonTypesPackageName))
	}

	return GeneratorData{
		apiVersion:             i.VersionName,
		baseClientPackage:      baseClientPackageForSdk(i.Type),
		commonTypes:            i.CommonTypes,
		commonTypesIncludePath: commonTypesIncludePath,
		commonTypesPackageName: commonTypesPackageName,
		constants:              i.ResourceDetails.Constants,
		isDataPlane:            models.SourceDataTypeIsDataPlane(i.Type),
		models:                 i.ResourceDetails.Models,
		operations:             i.ResourceDetails.Operations,
		packageName:            resourcePackageName,
		resourceIds:            i.ResourceDetails.ResourceIDs,
		resourceOutputPath:     resourceOutputPath,
		serviceClientName:      fmt.Sprintf("%sClient", strings.Title(i.ResourceName)),
		servicePackageName:     strings.ToLower(i.ServiceName),
		source:                 i.Source,
		sourceType:             i.Type,
		useNewBaseLayer:        useNewBaseLayer,
	}
}

type VersionGeneratorData struct {
	GeneratorData

	// This is the directory where versioned common types should be output
	// for example {workingDir}/common-types/{version}
	commonTypesOutputPath string

	// resources specifies a map of API Resource Names (key) to APIResource (value).
	resources map[string]models.APIResource

	// This is the directory for the API version where the meta client should be output
	// for example {workingDir}/{service}/{version}
	versionOutputPath string

	// the name of the version as a package
	versionPackageName string
}

func (i VersionGeneratorInput) generatorData(settings Settings) VersionGeneratorData {
	servicePackageName := strings.ToLower(i.ServiceName)
	versionPackageName := strings.ToLower(strings.ReplaceAll(i.VersionName, "-", "_"))

	commonTypesOutputPath := filepath.Join(i.OutputDirectory, settings.CommonTypesPackageName, versionPackageName)
	versionOutputPath := filepath.Join(i.OutputDirectory, servicePackageName, versionPackageName)

	useNewBaseLayer := settings.ShouldUseNewBaseLayer(i.ServiceName, i.VersionName)

	return VersionGeneratorData{
		GeneratorData: GeneratorData{
			apiVersion:         i.VersionName,
			baseClientPackage:  baseClientPackageForSdk(i.Type),
			commonTypes:        i.CommonTypes,
			constants:          i.CommonTypes.Constants,
			isDataPlane:        models.SourceDataTypeIsDataPlane(i.Type),
			models:             i.CommonTypes.Models,
			packageName:        versionPackageName,
			servicePackageName: strings.ToLower(i.ServiceName),
			source:             i.Source,
			sourceType:         i.Type,
			useNewBaseLayer:    useNewBaseLayer,
		},
		commonTypesOutputPath: commonTypesOutputPath,
		resources:             i.Resources,
		versionOutputPath:     versionOutputPath,
		versionPackageName:    versionPackageName,
	}
}
