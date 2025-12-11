// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/transforms"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func parseServiceDefinitionWithin(workingDirectory string, logger hclog.Logger) (*repositoryModels.ServiceDefinition, error) {
	filePath := filepath.Join(workingDirectory, "ServiceDefinition.json")
	logger.Trace(fmt.Sprintf("Trying to parse the Service Definition file at %q..", filePath))
	return parseConfig[repositoryModels.ServiceDefinition](filePath)
}

func parseMetaDataForSourceDataType(workingDirectory string, logger hclog.Logger) (*transforms.MetaData, error) {
	filePath := filepath.Join(workingDirectory, "metadata.json")
	logger.Trace(fmt.Sprintf("Trying to parse the MetaData file at %q..", filePath))
	config, err := parseConfig[repositoryModels.MetaData](filePath)
	if err != nil {
		return nil, err
	}
	if config == nil {
		// if the file doesn't exist this'll be a new/cleared-out set of data
		return nil, nil
	}

	transformed, err := transforms.MapMetaDataFromRepository(*config)
	if err != nil {
		return nil, fmt.Errorf("transforming metadata: %+v", err)
	}

	return transformed, nil
}

func parseCommonTypesWithin(workingDirectory string, logger hclog.Logger) (*map[string]sdkModels.CommonTypes, error) {
	logger.Trace(fmt.Sprintf("Discovering sub-directories within %q..", workingDirectory))
	subDirectories, err := listSubDirectories(workingDirectory)
	if err != nil {
		return nil, fmt.Errorf("listing the sub-directories within %q: %+v", workingDirectory, err)
	}
	if subDirectories == nil {
		return nil, nil
	}

	output := make(map[string]sdkModels.CommonTypes)
	for _, subDirectory := range *subDirectories {
		apiVersion := strings.TrimPrefix(subDirectory, workingDirectory)
		apiVersion = strings.TrimPrefix(apiVersion, "/")

		commonTypes := sdkModels.CommonTypes{
			Constants:   map[string]sdkModels.SDKConstant{},
			Models:      map[string]sdkModels.SDKModel{},
			ResourceIDs: make(map[string]sdkModels.ResourceID),
		}

		logger.Trace(fmt.Sprintf("Discovering the Common Type Constants within %q..", subDirectory))
		constants, err := parseConstantsWithin(subDirectory, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing the Common Type Constants within %q: %+v", subDirectory, err)
		}
		commonTypes.Constants = *constants

		logger.Trace(fmt.Sprintf("Discovering the Common Type Models within %q..", subDirectory))
		models, err := parseModelsWithin(subDirectory, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing the Common Type Models within %q: %+v", subDirectory, err)
		}
		commonTypes.Models = *models

		logger.Trace(fmt.Sprintf("Discovering the Common Type Resource IDs within %q..", subDirectory))
		resourceIds, err := parseResourceIDsWithin(subDirectory, *constants, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing the Common Type Models within %q: %+v", subDirectory, err)
		}
		commonTypes.ResourceIDs = *resourceIds

		if len(commonTypes.Constants) > 0 || len(commonTypes.Models) > 0 || len(commonTypes.ResourceIDs) > 0 {
			output[apiVersion] = commonTypes
		}
	}

	if len(output) == 0 {
		return nil, nil
	}

	return &output, nil
}

func parseServiceWithin(workingDirectory string, service repositoryModels.ServiceDefinition, commonTypes map[string]sdkModels.CommonTypes, logger hclog.Logger) (*sdkModels.Service, error) {
	// discover the API Versions available for this Service and load those in-turn
	apiVersions := make(map[string]sdkModels.APIVersion)
	subDirectories, err := listSubDirectories(workingDirectory)
	if err != nil {
		return nil, fmt.Errorf("listing the sub-directories within %q: %+v", workingDirectory, err)
	}
	for _, subDirectory := range *subDirectories {
		logger.Trace(fmt.Sprintf("Processing API Version within %q..", subDirectory))
		apiVersion, err := parseAPIVersionWithin(subDirectory, commonTypes, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing the API Version within %q: %+v", subDirectory, err)
		}

		if apiVersion == nil {
			logger.Trace(fmt.Sprintf("The path %q did not contain an API Version - skipping", subDirectory))
			continue
		}

		apiVersions[apiVersion.APIVersion] = *apiVersion
	}

	terraformDefinition, err := parseTerraformDefinitionForServiceWithin(workingDirectory, service.Terraform, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing the Terraform Definition for Service within %q: %+v", workingDirectory, err)
	}

	transformed, err := transforms.MapServiceDefinitionFromRepository(service, apiVersions, terraformDefinition)
	if err != nil {
		return nil, fmt.Errorf("transforming the Service Definition: %+v", err)
	}
	return transformed, nil
}

func parseAPIVersionWithin(workingDirectory string, commonTypes map[string]sdkModels.CommonTypes, logger hclog.Logger) (*sdkModels.APIVersion, error) {
	filePath := filepath.Join(workingDirectory, "ApiVersionDefinition.json")
	logger.Trace(fmt.Sprintf("Parsing the API Version Definition in %q..", filePath))
	config, err := parseConfig[repositoryModels.ApiVersionDefinition](filePath)
	if err != nil {
		return nil, fmt.Errorf("parsing the API Version Definition in %q: %+v", filePath, err)
	}
	if config == nil {
		// no file exists, so this doesn't contain an APIVersionDefinition
		return nil, nil
	}

	var commonTypesForThisAPIVersion *sdkModels.CommonTypes
	if v, ok := commonTypes[config.ApiVersion]; ok {
		commonTypesForThisAPIVersion = &v
	}

	apiResources := make(map[string]sdkModels.APIResource)
	for _, resourceName := range config.Resources {
		// we need to find the config
		subDirectory := filepath.Join(workingDirectory, resourceName)
		logger.Trace(fmt.Sprintf("Processing the API Resource within %q..", subDirectory))
		apiResource, err := parseAPIResourceWithin(subDirectory, resourceName, commonTypesForThisAPIVersion, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing the API Resource within %q: %+v", subDirectory, err)
		}

		if _, existing := apiResources[apiResource.Name]; existing {
			return nil, fmt.Errorf("duplicate APIResource %q", apiResource.Name)
		}

		apiResources[apiResource.Name] = *apiResource
	}

	transformedConfig, err := transforms.MapAPIVersionFromRepository(*config, apiResources)
	if err != nil {
		return nil, fmt.Errorf("transforming the API Version Definition in %q: %+v", filePath, err)
	}

	return transformedConfig, nil
}

func parseAPIResourceWithin(workingDirectory, resourceName string, commonTypesForThisAPIVersion *sdkModels.CommonTypes, logger hclog.Logger) (*sdkModels.APIResource, error) {
	logger.Trace(fmt.Sprintf("Parsing the Constants within %q..", workingDirectory))
	constants, err := parseConstantsWithin(workingDirectory, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing the Constants within %q: %+v", workingDirectory, err)
	}

	logger.Trace(fmt.Sprintf("Parsing the Models within %q..", workingDirectory))
	models, err := parseModelsWithin(workingDirectory, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing the Models within %q: %+v", workingDirectory, err)
	}

	logger.Trace(fmt.Sprintf("Parsing the Resource IDs within %q..", workingDirectory))
	resourceIds, err := parseResourceIDsWithin(workingDirectory, *constants, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing the Resource IDs within %q: %+v", workingDirectory, err)
	}

	knownData := helpers.KnownData{
		Constants:              *constants,
		Models:                 *models,
		ResourceIds:            *resourceIds,
		CommonTypeConstants:    make(map[string]sdkModels.SDKConstant),
		CommonTypeModels:       make(map[string]sdkModels.SDKModel),
		CommonTypesResourceIds: make(map[string]sdkModels.ResourceID),
	}
	if commonTypesForThisAPIVersion != nil {
		knownData.CommonTypeConstants = commonTypesForThisAPIVersion.Constants
		knownData.CommonTypeModels = commonTypesForThisAPIVersion.Models
		knownData.CommonTypesResourceIds = commonTypesForThisAPIVersion.ResourceIDs
	}

	logger.Trace(fmt.Sprintf("Parsing the Operations within %q..", workingDirectory))
	operations, err := parseOperationsWithin(workingDirectory, knownData, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing the Operations within %q: %+v", workingDirectory, err)
	}

	return &sdkModels.APIResource{
		Constants:   *constants,
		Models:      *models,
		Name:        resourceName,
		Operations:  *operations,
		ResourceIDs: *resourceIds,
	}, nil
}

func parseConstantsWithin(workingDirectory string, logger hclog.Logger) (*map[string]sdkModels.SDKConstant, error) {
	constantFiles, err := listFilesMatching(workingDirectory, "Constant-", "json")
	if err != nil {
		return nil, fmt.Errorf("listing Constants: %+v", err)
	}

	output := make(map[string]sdkModels.SDKConstant)
	for _, filePath := range *constantFiles {
		logger.Trace(fmt.Sprintf("Processing Constant within %q..", filePath))
		constant, err := parseConfig[repositoryModels.Constant](filePath)
		if err != nil {
			return nil, fmt.Errorf("parsing the Constant within %q: %+v", filePath, err)
		}
		transformed, err := transforms.MapSDKConstantFromRepository(*constant)
		if err != nil {
			return nil, fmt.Errorf("transforming the Constant from %q: %+v", filePath, err)
		}

		if _, existing := output[constant.Name]; existing {
			return nil, fmt.Errorf("duplicate Constant %q", constant.Name)
		}

		output[constant.Name] = *transformed
	}

	return &output, nil
}

func parseModelsWithin(workingDirectory string, logger hclog.Logger) (*map[string]sdkModels.SDKModel, error) {
	modelFiles, err := listFilesMatching(workingDirectory, "Model-", "json")
	if err != nil {
		return nil, fmt.Errorf("listing Models: %+v", err)
	}

	output := make(map[string]sdkModels.SDKModel)
	for _, filePath := range *modelFiles {
		logger.Trace(fmt.Sprintf("Processing Model within %q..", filePath))
		model, err := parseConfig[repositoryModels.Model](filePath)
		if err != nil {
			return nil, fmt.Errorf("parsing the Model within %q: %+v", filePath, err)
		}
		transformed, err := transforms.MapSDKModelFromRepository(*model)
		if err != nil {
			return nil, fmt.Errorf("transforming the Model from %q: %+v", filePath, err)
		}

		if _, existing := output[model.Name]; existing {
			return nil, fmt.Errorf("duplicate Model %q", model.Name)
		}

		output[model.Name] = *transformed
	}

	return &output, nil
}

func parseOperationsWithin(workingDirectory string, knownData helpers.KnownData, logger hclog.Logger) (*map[string]sdkModels.SDKOperation, error) {
	operationFiles, err := listFilesMatching(workingDirectory, "Operation-", "json")
	if err != nil {
		return nil, fmt.Errorf("listing Operations: %+v", err)
	}

	output := make(map[string]sdkModels.SDKOperation)
	for _, filePath := range *operationFiles {
		logger.Trace(fmt.Sprintf("Processing Operation within %q..", filePath))
		operation, err := parseConfig[repositoryModels.Operation](filePath)
		if err != nil {
			return nil, fmt.Errorf("parsing the Operation within %q: %+v", filePath, err)
		}
		transformed, err := transforms.MapSDKOperationFromRepository(*operation, knownData)
		if err != nil {
			return nil, fmt.Errorf("transforming the Operation from %q: %+v", filePath, err)
		}

		if _, existing := output[operation.Name]; existing {
			return nil, fmt.Errorf("duplicate Operation %q", operation.Name)
		}

		output[operation.Name] = *transformed
	}

	return &output, nil
}

func parseResourceIDsWithin(workingDirectory string, availableConstants map[string]sdkModels.SDKConstant, logger hclog.Logger) (*map[string]sdkModels.ResourceID, error) {
	resourceIdFiles, err := listFilesMatching(workingDirectory, "ResourceId-", "json")
	if err != nil {
		return nil, fmt.Errorf("listing ResourceIDs: %+v", err)
	}
	output := make(map[string]sdkModels.ResourceID)
	for _, filePath := range *resourceIdFiles {
		logger.Trace(fmt.Sprintf("Processing Resource ID within %q..", filePath))
		resourceId, err := parseConfig[repositoryModels.ResourceId](filePath)
		if err != nil {
			return nil, fmt.Errorf("parsing the Resource ID within %q: %+v", filePath, err)
		}
		transformed, err := transforms.MapResourceIDFromRepository(*resourceId, availableConstants)
		if err != nil {
			return nil, fmt.Errorf("transforming the Resource ID from %q: %+v", filePath, err)
		}

		if _, existing := output[resourceId.Name]; existing {
			return nil, fmt.Errorf("duplicate ResourceId %q", resourceId.Name)
		}

		output[resourceId.Name] = *transformed
	}

	return &output, nil
}

func parseTerraformDefinitionForServiceWithin(workingDirectory string, terraform *repositoryModels.TerraformServiceDefinition, logger hclog.Logger) (*sdkModels.TerraformDefinition, error) {
	if terraform == nil {
		return nil, nil
	}

	terraformDirectory := filepath.Join(workingDirectory, "Terraform")

	// we know which Terraform Resources we're looking for, so let's load those
	resources := make(map[string]sdkModels.TerraformResourceDefinition)
	for _, resourceName := range terraform.Resources {
		logger.Trace(fmt.Sprintf("Loading information for the Terraform Resource %q..", resourceName))
		parsedResource, err := parseTerraformResourceWithin(terraformDirectory, resourceName, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing the Terraform Resource %q: %+v", resourceName, err)
		}

		if _, existing := resources[parsedResource.ResourceLabel]; existing {
			return nil, fmt.Errorf("duplicate Terraform Resource %q", parsedResource.ResourceLabel)
		}

		resources[parsedResource.ResourceLabel] = *parsedResource
	}

	return &sdkModels.TerraformDefinition{
		Resources:            resources,
		TerraformPackageName: terraform.ServicePackageName,
	}, nil
}

func parseTerraformResourceWithin(terraformDirectory string, resourceName string, logger hclog.Logger) (*sdkModels.TerraformResourceDefinition, error) {
	// %s-Resource.json
	resourceFile := filepath.Join(terraformDirectory, fmt.Sprintf("%s-Resource.json", resourceName))
	resource, err := parseConfig[repositoryModels.TerraformResourceDefinition](resourceFile)
	if err != nil {
		return nil, fmt.Errorf("parsing the Terraform Resource Definition at %q: %+v", resourceFile, err)
	}
	if resource == nil {
		return nil, fmt.Errorf("a Terraform Resource Definition was not found at %q for %q", resourceFile, resourceName)
	}

	logger.Trace("Parsing the Terraform Schema Models..")
	schemaModels, err := parseTerraformSchemaModelsWithin(terraformDirectory, resourceName)
	if err != nil {
		return nil, fmt.Errorf("parsing the Terraform Schema Models within %q for %q: %+v", terraformDirectory, resourceName, err)
	}

	logger.Trace("Parsing the Terraform Mappings..")
	// %s-Resource-Mappings.json
	mappings, err := parseTerraformMappingsWithin(terraformDirectory, resourceName)
	if err != nil {
		return nil, fmt.Errorf("parsing the Terraform Mappings within %q for %q: %+v", terraformDirectory, resourceName, err)
	}

	logger.Trace("Parsing the Terraform Tests..")
	tests, err := parseTerraformTestsWithin(terraformDirectory, resourceName, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing the Terraform Tests within %q for %q: %+v", terraformDirectory, resourceName, err)
	}

	mapped, err := transforms.MapTerraformResourceDefinitionFromRepository(resourceName, *resource, *schemaModels, *mappings, *tests)
	if err != nil {
		return nil, fmt.Errorf("transforming the Terraform Resource Definition: %+v", err)
	}

	return mapped, nil
}

func parseTerraformMappingsWithin(terraformDirectory, resourceName string) (*sdkModels.TerraformMappingDefinition, error) {
	filePath := filepath.Join(terraformDirectory, fmt.Sprintf("%s-Resource-Mappings.json", resourceName))
	mappings, err := parseConfig[repositoryModels.TerraformMappingDefinition](filePath)
	if err != nil {
		return nil, fmt.Errorf("parsing the Terraform Mappings from %q: %+v", filePath, err)
	}
	if mappings == nil {
		return nil, fmt.Errorf("missing Terraform Mappings for %q", resourceName)
	}

	transformed, err := transforms.MapTerraformSchemaMappingsFromRepository(*mappings)
	if err != nil {
		return nil, fmt.Errorf("transforming the Terraform Schema Mappings: %+v", err)
	}

	return transformed, nil
}

func parseTerraformSchemaModelsWithin(terraformDirectory, resourceName string) (*map[string]sdkModels.TerraformSchemaModel, error) {
	// The Main Schema Model is in: `%s-Resource-Schema.json`
	// Additional Files are in: `%s-Resource-*-Schema.json`
	schemaModelFiles, err := listFilesMatching(terraformDirectory, fmt.Sprintf("%s-Resource-", resourceName), ".json")
	if err != nil {
		return nil, fmt.Errorf("listing Test files: %+v", err)
	}

	output := make(map[string]sdkModels.TerraformSchemaModel)
	for _, schemaModelFilePath := range *schemaModelFiles {
		if !strings.HasSuffix(schemaModelFilePath, "-Schema.json") {
			continue
		}

		schemaModel, err := parseConfig[repositoryModels.TerraformSchemaModel](schemaModelFilePath)
		if err != nil {
			return nil, fmt.Errorf("parsing the Terraform Schema Model %q: %+v", schemaModelFilePath, err)
		}
		if schemaModel == nil {
			return nil, fmt.Errorf("the Schema Model for %q was not found", schemaModelFilePath)
		}
		mapped, err := transforms.MapTerraformSchemaModelFromRepository(schemaModel)
		if err != nil {
			return nil, fmt.Errorf("transforming the Terraform Schema Model %q: %+v", schemaModelFilePath, err)
		}

		output[schemaModel.Name] = *mapped
	}

	return &output, nil
}

func parseTerraformTestsWithin(terraformDirectory, resourceName string, logger hclog.Logger) (*sdkModels.TerraformResourceTestsDefinition, error) {
	testsDirectory := filepath.Join(terraformDirectory, "Tests")
	files, err := listFilesMatching(testsDirectory, fmt.Sprintf("%s-Resource-", resourceName), "hcl")
	if err != nil {
		return nil, fmt.Errorf("listing the Test files within %q: %+v", testsDirectory, err)
	}

	// TODO: update this to use a Repository specific type
	output := sdkModels.TerraformResourceTestsDefinition{
		// TODO: the repository TerraformResourceDefinition should store the `Generate` flag and the files to load
		BasicConfiguration:          "",
		RequiresImportConfiguration: "",
		CompleteConfiguration:       nil,
		Generate:                    true,
		OtherTests:                  &map[string][]sdkModels.TerraformTestDefinition{},
		TemplateConfiguration:       nil,
	}
	for _, file := range *files {
		if !strings.HasSuffix(file, "-Test.hcl") {
			continue
		}

		// Tests/%s-Resource-Basic-Test.hcl
		// Tests/%s-Resource-Requires-Import-Test.hcl
		// Tests/%s-Resource-Complete-Test.hcl (Optional)
		// Tests/%s-Resource-Template-Test.hcl (Optional)
		testFileName := strings.TrimPrefix(file, testsDirectory)
		testFileName = strings.TrimPrefix(testFileName, fmt.Sprintf("/%s-Resource-", resourceName))
		testFileName = strings.TrimSuffix(testFileName, "-Test.hcl")
		logger.Trace(fmt.Sprintf("Test File Name is %q", testFileName))
		switch testFileName {
		case "Basic":
			{
				config, err := parseTestConfiguration(file)
				if err != nil {
					return nil, fmt.Errorf("parsing the Basic Test at %q: %+v", file, err)
				}
				output.BasicConfiguration = *config
			}
		case "Requires-Import":
			{
				config, err := parseTestConfiguration(file)
				if err != nil {
					return nil, fmt.Errorf("parsing the RequiresImport Test at %q: %+v", file, err)
				}
				output.RequiresImportConfiguration = *config
			}
		case "Complete":
			{
				config, err := parseTestConfiguration(file)
				if err != nil {
					return nil, fmt.Errorf("parsing the Complete Test at %q: %+v", file, err)
				}
				output.CompleteConfiguration = config
			}
		case "Template":
			{
				config, err := parseTestConfiguration(file)
				if err != nil {
					return nil, fmt.Errorf("parsing the Template Test at %q: %+v", file, err)
				}
				output.TemplateConfiguration = config
			}

		default:
			{
				// This'd be an "other" test, which we've threaded through but would need to rework for
				// the moment, so for now since this is unexpected we're temporarily raising an error here
				// but once the Test data (that is `Generate` & the File Names to load) is stored within the
				// TerraformResourceDefinition, we can support these and remove this
				return nil, fmt.Errorf("internal-error: support for 'Other' tests has been temporarily disabled but found one at %q", file)
			}
		}
	}

	// TODO: temporary - remove this and validate the Basic test exists once https://github.com/hashicorp/pandora/issues/3352 is fixed
	if output.BasicConfiguration == "" {
		return &sdkModels.TerraformResourceTestsDefinition{
			Generate: false,
		}, nil
	}
	if output.RequiresImportConfiguration == "" {
		return nil, fmt.Errorf("a RequiresImport Test is required but none was found")
	}

	return &output, nil
}
