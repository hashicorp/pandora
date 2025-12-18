// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type availableService struct {
	sourceDataOrigin sdkModels.SourceDataOrigin
	workingDirectory string
}

// discoverAvailableSourceDataWithin returns the available Source Data Origins matching the current
// Source Data Type within the specified workingDirectory.
func discoverAvailableSourceDataWithin(workingDirectory string, sourceDataType sdkModels.SourceDataType, logger hclog.Logger) (*map[string]availableService, error) {
	logger.Debug(fmt.Sprintf("Listing the subdirectories within %q..", workingDirectory))
	subDirectories, err := listSubDirectories(workingDirectory)
	if err != nil {
		return nil, err
	}

	output := make(map[string]availableService)
	for _, subDirectory := range *subDirectories {
		logger.Trace(fmt.Sprintf("Processing %q", subDirectory))
		dataSource, err := parseMetaDataForSourceDataType(subDirectory, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing information from %q: %+v", subDirectory, err)
		}
		if dataSource == nil {
			logger.Debug(fmt.Sprintf("The directory %q didn't contain a data source - skipping", subDirectory))
			continue
		}

		if dataSource.SourceDataType != sourceDataType {
			logger.Trace(fmt.Sprintf("Skipping Data Source %q since it is for SourceDataType %q and we want %q", subDirectory, dataSource.SourceDataType, sourceDataType))
			continue
		}

		// then find all the Services available within this SourceDataType
		availableServices, err := discoveryAvailableServicesWithin(subDirectory, logger)
		if err != nil {
			return nil, fmt.Errorf("discovering the available Services within %q: %+v", workingDirectory, err)
		}

		for serviceName, serviceDirectory := range *availableServices {
			// sanity-checking
			if _, existing := output[serviceName]; existing {
				return nil, fmt.Errorf("there was a conflicting Service %q", serviceName)
			}
			output[serviceName] = availableService{
				sourceDataOrigin: dataSource.SourceDataOrigin,
				workingDirectory: serviceDirectory,
			}
		}
	}

	return &output, nil
}

// discoveryAvailableServicesWithin returns the available Services within `workingDirectory`, which is expected
// to be the absolute path to the directory for a Source Data Origin (e.g. `/path/to/api-definitions/resource-manager`).
func discoveryAvailableServicesWithin(workingDirectory string, logger hclog.Logger) (*map[string]string, error) {
	output := make(map[string]string)

	logger.Trace(fmt.Sprintf("Parsing the Available Services within %q..", workingDirectory))
	subDirectories, err := listSubDirectories(workingDirectory)
	if err != nil {
		return nil, fmt.Errorf("listing sub-directories within %q: %+v", workingDirectory, err)
	}

	for _, subDirectory := range *subDirectories {
		logger.Trace(fmt.Sprintf("Parsing the Service within %q..", subDirectory))

		serviceDefinition, err := parseServiceDefinitionWithin(subDirectory, logger)
		if err != nil {
			return nil, fmt.Errorf("loading Service Definition from %q: %+v", subDirectory, err)
		}
		if serviceDefinition == nil {
			// if there isn't a file/temp directory, etc.
			continue
		}

		// sanity-checking
		if _, existing := output[serviceDefinition.Name]; existing {
			return nil, fmt.Errorf("there was a conflicting Service %q", serviceDefinition.Name)
		}
		output[serviceDefinition.Name] = subDirectory
	}

	return &output, nil
}

// discoverCommonTypesWithin discovers the Common Types available for the SourceDataType within the Data Directory
// This returns a map of APIVersion (key) to CommonTypes (value) and will merge any CommonTypes from different SourceDataOrigins
// allowing for HandWritten overrides/types to Imported types as needed.
func discoverCommonTypesWithin(workingDirectory string, sourceDataType sdkModels.SourceDataType, logger hclog.Logger) (*map[string]sdkModels.CommonTypes, error) {
	// for each set
	logger.Debug(fmt.Sprintf("Listing the subdirectories within %q..", workingDirectory))
	subDirectories, err := listSubDirectories(workingDirectory)
	if err != nil {
		return nil, err
	}

	output := make(map[string]sdkModels.CommonTypes)
	for _, subDirectory := range *subDirectories {
		logger.Trace(fmt.Sprintf("Processing %q", subDirectory))
		dataSource, err := parseMetaDataForSourceDataType(subDirectory, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing information from %q: %+v", subDirectory, err)
		}
		if dataSource == nil {
			logger.Debug(fmt.Sprintf("The directory %q didn't contain a data source - skipping", subDirectory))
			continue
		}

		if dataSource.SourceDataType != sourceDataType {
			logger.Trace(fmt.Sprintf("Skipping Data Source %q since it is for SourceDataType %q and we want %q", subDirectory, dataSource.SourceDataType, sourceDataType))
			continue
		}

		commonTypesDirectory := filepath.Join(subDirectory, helpers.CommonTypesDirectoryName)
		commonTypes, err := parseCommonTypesWithin(commonTypesDirectory, logger)
		if err != nil {
			return nil, fmt.Errorf("parsing the Common Types within %q: %+v", commonTypesDirectory, err)
		}
		if commonTypes == nil {
			logger.Debug(fmt.Sprintf("The directory at %q contained no Common Types - skipping", commonTypesDirectory))
			continue
		}
		for apiVersion, value := range *commonTypes {
			existing, hasExisting := output[apiVersion]
			if !hasExisting {
				output[apiVersion] = value
				continue
			}
			merged, err := helpers.MergeCommonTypes(existing, value)
			if err != nil {
				return nil, fmt.Errorf("merging the Common Types for API Version %q: %+v", apiVersion, err)
			}
			output[apiVersion] = *merged
		}
	}

	return &output, nil
}
