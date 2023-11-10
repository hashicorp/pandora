package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"path"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (s Generator) generateTerraformResourceDefinition(resourceLabel string, details resourcemanager.TerraformResourceDetails) error {
	s.logger.Trace("Building Definition for the Terraform Resource..")
	resourceDefinition, err := buildTerraformResourceDefinition(resourceLabel, details)
	if err != nil {
		return fmt.Errorf("building Terraform Resource Definition: %+v", err)
	}
	s.logger.Trace("Marshalling Definition for the Terraform Resource..")
	resourceDefinitionCode, err := json.MarshalIndent(resourceDefinition, "", "\t")
	if err != nil {
		return fmt.Errorf("marshaling Terraform Resource Definition: %+v", err)
	}
	resourceFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource.json", details.ResourceName))
	s.logger.Trace(fmt.Sprintf("Writing Resource Definition into %q..", resourceFileName))
	if err := writeJsonToFile(resourceFileName, resourceDefinitionCode); err != nil {
		return fmt.Errorf("writing Terraform Resource Definition to %q: %+v", resourceFileName, err)
	}

	s.logger.Debug("Processing Models for the Terraform Resource..")
	if err := s.generateTerraformSchemaModelsForResource(details.ResourceName, details.SchemaModelName, details.SchemaModels); err != nil {
		return fmt.Errorf("generating the Schema Models for the Terraform Resource %q: %+v", resourceLabel, err)
	}

	// output the Mappings for this Terraform Resource
	s.logger.Trace("Building Resource Mappings..")
	resourceMappings, err := mapTerraformSchemaMappings(details.Mappings)
	if err != nil {
		return fmt.Errorf("building Mappings for the Terraform Resource %q: %+v", resourceLabel, err)
	}
	s.logger.Trace("Marshalling Resource Mappings..")
	resourceMappingsCode, err := json.MarshalIndent(resourceMappings, "", "\t")
	if err != nil {
		return fmt.Errorf("marshaling Mappings for the Terraform Resource %q: %+v", resourceLabel, err)
	}
	resourceMappingsFileName := path.Join(s.workingDirectoryForTerraform, fmt.Sprintf("%s-Resource-Mappings.json", details.ResourceName))
	s.logger.Trace(fmt.Sprintf("Generating Mappings for the Terraform Resource into %q", resourceMappingsFileName))
	if err := writeJsonToFile(resourceMappingsFileName, resourceMappingsCode); err != nil {
		return fmt.Errorf("generating Mappings for the Terraform Resource %q: %+v", resourceLabel, err)
	}

	// output the Tests for this Terraform Resource
	resourceTestsFileName := path.Join(s.workingDirectoryForTerraformTests, fmt.Sprintf("%s-Resource-Tests.hcl", details.ResourceName))
	s.logger.Trace(fmt.Sprintf("Generating Tests for the Terraform Resource into %q", resourceTestsFileName))
	resourceTestsCode := mapTerraformResourceTestDefinition(details.Tests)
	if err := writeTestsHclToFile(s.workingDirectoryForTerraformTests, details.ResourceName, resourceTestsCode); err != nil {
		return fmt.Errorf("generating Tests for the Terraform Resource %q: %+v", resourceLabel, err)
	}

	return nil
}

func (s Generator) generateTerraformSchemaModelsForResource(resourceName, resourceSchemaModelName string, models map[string]resourcemanager.TerraformSchemaModelDefinition) error {
	for modelName, model := range models {
		s.logger.Trace(fmt.Sprintf("Mapping Terraform Resource Schema Model for %q..", modelName))
		mappedModel, err := mapTerraformSchemaModelDefinition(modelName, model)
		if err != nil {
			return fmt.Errorf("mapping Terraform Schema Model %q: %+v", modelName, err)
		}

		s.logger.Trace(fmt.Sprintf("Marshalling Terraform Resource Schema Model for %q..", modelName))
		marshalledModel, err := json.MarshalIndent(mappedModel, "", "\t")
		if err != nil {
			return fmt.Errorf("marshaling Terraform Resource Definition: %+v", err)
		}

		fileName := fmt.Sprintf("%s-Resource-Schema-%s.json", resourceName, strings.TrimPrefix(modelName, resourceSchemaModelName))
		if modelName == resourceSchemaModelName {
			// Special-case the Resources Model so that it's easier to find the Resource's Schema quickly
			fileName = fmt.Sprintf("%s-Resource-Schema.json", resourceName)
		}
		schemaFileName := path.Join(s.workingDirectoryForTerraform, fileName)
		s.logger.Trace(fmt.Sprintf("Writing Schema Model %q into %q", modelName, schemaFileName))
		if err := writeJsonToFile(schemaFileName, marshalledModel); err != nil {
			return fmt.Errorf("writing Terraform Resource Schema Model for %q: %+v", modelName, err)
		}

		s.logger.Trace("Processed Schema Model %q.", modelName)
	}
	return nil
}
