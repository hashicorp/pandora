package repositories

import (
	"encoding/json"
	"errors"
	"fmt"
	"os"
	"path"
	"sort"
	"strings"
	"sync"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

type ServicesRepository interface {
	GetByName(serviceName string, serviceType ServiceType) (*ServiceDetails, error)
	GetAll(serviceType ServiceType) (*[]ServiceDetails, error)
	ClearCache() error
}

var _ ServicesRepository = &ServicesRepositoryImpl{}

type ServicesRepositoryImpl struct {
	// Service, Version and Resource definitions loaded and unmarshalled from the JSON API definitions
	services *map[string]ServiceDetails

	// serviceDirectory is a map of all the services belonging to a serviceType mapped to the directory containing its
	// definitions
	serviceDirectory map[string]string

	// serviceNames is a list containing the names of services which should be loaded
	// this allows the loading/parsing of a subset of services for faster iterations during development
	serviceNames *[]string

	sync.Mutex
}

type ApiDefinition struct {
	// The name of the ApiDefinition, it forms part of the name of the JSON files that contain the definitions which are
	// loaded into the Data API
	name string

	// The type of definition e.g. Constant, Model, Operation, ResourceId
	definitionType string

	// The complete file name as stored on disk
	fileName string
}

func NewServicesRepository(directory string, serviceType ServiceType, serviceNames *[]string) (ServicesRepository, error) {
	// NewServicesRepository initialises a service repository for a given service type (e.g. resource-manager/graph etc.)
	// beginning in the root directory for all api definitions, it auto discovers subdirectories with a metadata.json and collects
	// all service definitions for the specified service type, building a complete list of services as well as their directory paths
	// to load
	dirs, err := listSubDirectories(directory)
	if err != nil {
		return nil, fmt.Errorf("initialising service repository for %q: %+v", string(serviceType), err)
	}

	allServices := make(map[string]string, 0)
	for _, d := range *dirs {
		serviceDir := path.Join(directory, d)

		// check whether directory contains a metadata.json
		var metadata dataapimodels.MetaData
		contents, err := loadJson(fmt.Sprintf(path.Join(serviceDir, "metadata.json")))
		if err != nil {
			var pathError *os.PathError
			if errors.As(err, &pathError) {
				// this folder has no metadata.json, so we skip it
				continue
			}
			return nil, fmt.Errorf("initialising service repository for %q, loading metadata.json: %+v", string(serviceType), err)
		}

		if err := json.Unmarshal(*contents, &metadata); err != nil {
			return nil, fmt.Errorf("initialising service repository for %q, unmarshaling metadata.json: %+v", string(serviceType), err)
		}

		if serviceType == ResourceManagerServiceType {
			if metadata.DataSource != dataapimodels.AzureResourceManagerDataSource {
				continue
			}
		}
		if serviceType == MicrosoftGraphV1StableServiceType {
			if metadata.DataSource != dataapimodels.MicrosoftGraphDataSource {
				continue
			}
		}

		files, err := os.ReadDir(serviceDir)
		if err != nil {
			return nil, fmt.Errorf("initialising service repository for %q, getting services: %+v", string(serviceType), err)
		}

		for _, f := range files {
			if f.IsDir() {
				if _, ok := allServices[f.Name()]; ok {
					return nil, fmt.Errorf("initialising service repository for %q, duplicate definitions for service %q: %+v", string(serviceType), f.Name(), err)
				}
				allServices[f.Name()] = path.Join(serviceDir, f.Name())
			}
		}
	}

	return &ServicesRepositoryImpl{
		serviceNames:     serviceNames,
		serviceDirectory: allServices,
	}, nil
}

func (s *ServicesRepositoryImpl) ClearCache() error {
	// TODO This gets automatically run if a file has changed and when serve-watch is used
	// TODO this finds the files needed and loads it
	// TODO file watching
	s.services = nil

	return nil
}

func (s *ServicesRepositoryImpl) GetAll(serviceType ServiceType) (*[]ServiceDetails, error) {
	// GetAll calls GetByName for all the service names passed to the serve command, or for all the services available in the api definitions directory
	serviceDetails := make([]ServiceDetails, 0)

	// TODO add locking around this when reloading data/clearing cache so that it's only done once
	if s.services == nil {
		servicesToLoad := make([]string, 0)
		if s.serviceNames == nil {
			for service := range s.serviceDirectory {
				servicesToLoad = append(servicesToLoad, service)
			}
		} else {
			for _, service := range *s.serviceNames {
				if _, ok := s.serviceDirectory[service]; !ok {
					// TODO errors: api definitions for service x not found
				}
			}
			servicesToLoad = *s.serviceNames
		}

		sort.Strings(servicesToLoad)

		servicesMap := make(map[string]ServiceDetails)
		for _, service := range servicesToLoad {
			serviceDetail, err := s.GetByName(service, serviceType)
			if err != nil {
				return nil, fmt.Errorf("retrieving service details for %s: %+v", service, err)
			}
			serviceDetails = append(serviceDetails, *serviceDetail)
			servicesMap[serviceDetail.Name] = *serviceDetail
		}
		s.services = &servicesMap

		return &serviceDetails, nil
	}

	for _, details := range *s.services {
		serviceDetails = append(serviceDetails, details)
	}

	return &serviceDetails, nil
}

func (s *ServicesRepositoryImpl) GetByName(serviceName string, serviceType ServiceType) (*ServiceDetails, error) {
	// GetByName builds the ServiceDetails for a singular service by calling processing functions to build the
	// structs for the ServiceApiVersionDetails and ServiceApiVersionResourceDetails
	if _, err := os.Stat(s.serviceDirectory[serviceName]); os.IsNotExist(err) {
		return nil, fmt.Errorf("service %q does not exist: %+v", serviceName, err)
	}

	serviceDetails, err := s.ProcessServiceDefinitions(serviceName)
	if err != nil {
		return nil, fmt.Errorf("processing service definition for %s: %+v", serviceName, err)
	}

	if s.services != nil {
		s.Lock()
		services := *s.services
		services[serviceName] = *serviceDetails
		s.Unlock()
	}

	return serviceDetails, nil
}

func (s *ServicesRepositoryImpl) ProcessServiceDefinitions(serviceName string) (*ServiceDetails, error) {
	versions, err := listSubDirectories(s.serviceDirectory[serviceName])
	if err != nil {
		return nil, fmt.Errorf("retrieving versions: %+v", err)
	}

	versionDefinitions := make(map[string]*ServiceApiVersionDetails, 0)

	if versions != nil {
		for _, version := range *versions {
			// The Terraform directory can be skipped as it only has a subdirectory for tests
			if version == "Terraform" {
				continue
			}
			resources, err := listSubDirectories(path.Join(s.serviceDirectory[serviceName], version))
			if err != nil {
				return nil, fmt.Errorf("retrieving resources for %s: %+v", version, err)
			}
			versionDetails, err := s.ProcessVersionDefinitions(serviceName, version, *resources)
			if err != nil {
				return nil, fmt.Errorf("processing version definitions for %s: %+v", version, err)
			}
			versionDefinitions[version] = versionDetails
		}
	}

	terraformDetails, err := s.ProcessTerraformDefinitions(serviceName)
	if err != nil {
		return nil, err
	}

	var serviceDefinition dataapimodels.ServiceDefinition

	contents, err := loadJson(path.Join(s.serviceDirectory[serviceName], "ServiceDefinition.json"))
	if err != nil {
		return nil, fmt.Errorf("processing service definition for %q: %+v", serviceName, err)
	}

	if err = json.Unmarshal(*contents, &serviceDefinition); err != nil {
		return nil, fmt.Errorf("unmarshaling service definition for %q: %+v", serviceName, err)
	}

	serviceDetails := &ServiceDetails{
		Name:             serviceName,
		ResourceProvider: *serviceDefinition.ResourceProvider,
		ApiVersions:      versionDefinitions,
	}

	if terraformDetails != nil {
		serviceDetails.TerraformDetails = *terraformDetails
	}

	return serviceDetails, nil
}

func (s *ServicesRepositoryImpl) ProcessVersionDefinitions(serviceName string, version string, resources []string) (*ServiceApiVersionDetails, error) {
	versionDefinition := ServiceApiVersionDetails{
		Name:     version,
		Generate: true,
	}

	resourceDefinitions := make(map[string]*ServiceApiVersionResourceDetails, 0)

	for _, resource := range resources {
		resourceDetail, err := s.ProcessResourceDefinitions(serviceName, version, resource)
		if err != nil {
			return nil, fmt.Errorf("processing resource definition for %s: %+v", resource, err)
		}

		resourceDefinitions[resource] = resourceDetail
	}

	versionDefinition.Resources = resourceDefinitions

	return &versionDefinition, nil
}

func (s *ServicesRepositoryImpl) ProcessResourceDefinitions(serviceName string, version string, resource string) (*ServiceApiVersionResourceDetails, error) {
	resourceDefinition := ServiceApiVersionResourceDetails{}
	resourceSchema := ResourceSchema{}
	constants := make(map[string]ConstantDetails)
	apiModels := make(map[string]ModelDetails)
	operations := make(map[string]ResourceOperations)
	resourceIds := make(map[string]ResourceIdDefinition)

	resourcePath := path.Join(s.serviceDirectory[serviceName], version, resource)
	files, err := os.ReadDir(resourcePath)
	if err != nil {
		return nil, fmt.Errorf("retrieving definitions under %s: %+v", resourcePath, err)
	}

	// The order in which we load the API definitions is important since:
	// * Models can contain Constants
	// * Resource IDs can contain Constants
	// * Operations can reference Constants, Models and Resource IDs
	// ReadDir returns the list of files in the order stored on the file system which is alphabetical
	// We reorder the array such that Operation definitions get processed after Resource ID definitions

	definitionFiles := make([]ApiDefinition, 0)
	operationDefinitionFiles := make([]ApiDefinition, 0)

	for _, file := range files {
		if file.IsDir() {
			continue
		}
		definitionType, definitionName, err := getDefinitionInfo(file.Name())
		if err != nil {
			return nil, err
		}

		definition := ApiDefinition{
			name:           definitionName,
			definitionType: definitionType,
			fileName:       file.Name(),
		}

		if strings.EqualFold(strings.ToLower(definitionType), "operation") {
			operationDefinitionFiles = append(operationDefinitionFiles, definition)
			continue
		}

		definitionFiles = append(definitionFiles, definition)
	}

	definitionFiles = append(definitionFiles, operationDefinitionFiles...)

	for _, definition := range definitionFiles {
		definitionPath := path.Join(resourcePath, definition.fileName)
		if err != nil {
			return nil, err
		}

		// we lower case this comparison so that it's compatible with other OS e.g. Windows
		switch strings.ToLower(definition.definitionType) {
		// Ordering here is important, all Constants need to be processed first, then all Models
		case "constant":
			constant, err := parseConstantFromFilePath(definitionPath)
			if err != nil {
				return nil, fmt.Errorf("processing constant %s: %+v", definition.fileName, err)
			}

			constants[definition.name] = pointer.From(constant)
		case "model":
			model, err := parseModelFromFilePath(definitionPath)
			if err != nil {
				return nil, fmt.Errorf("processing model %s: %+v", definition.fileName, err)
			}

			apiModels[definition.name] = pointer.From(model)
		case "resourceid":
			resourceId, err := parseResourceIdFromFilePath(definitionPath, constants)
			if err != nil {
				return nil, fmt.Errorf("processing resource id %s: %+v", definition.fileName, err)
			}

			resourceIds[definition.name] = pointer.From(resourceId)
		case "operation":
			operationDetails, err := parseOperationFromFilePath(definitionPath, constants, apiModels, resourceIds)
			if err != nil {
				return nil, fmt.Errorf("processing operation %s: %+v", definition.fileName, err)
			}

			operations[definition.name] = pointer.From(operationDetails)
		}
	}

	// We perform some validation on the parsed data for models here, since we can only do this after we have a complete list of constants and models
	// validation is done on the object definitions as well as models that are discriminated parent types or implement a discriminated type
	if err := validateModels(apiModels, constants); err != nil {
		return nil, fmt.Errorf("validating models: %+v", err)
	}

	// The validation for the request and response objects of operations could be done as we're loading and parsing the files above, but it's done separately
	// here to reduce unnecessary code duplication
	if err := validateOperations(operations, apiModels, constants); err != nil {
		return nil, fmt.Errorf("validating operations: %+v", err)
	}

	resourceSchema.Constants = constants
	resourceSchema.Models = apiModels
	resourceSchema.ResourceIds = resourceIds
	resourceDefinition.Schema = resourceSchema
	resourceDefinition.Operations = operations

	return &resourceDefinition, nil
}

func parseConstantFromFilePath(filePath string) (*ConstantDetails, error) {
	var constant dataapimodels.Constant

	contents, err := loadJson(fmt.Sprintf(filePath))
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &constant); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", filePath, err)
	}

	values := make(map[string]string, 0)

	for _, value := range constant.Values {
		values[value.Key] = value.Value
	}

	constantType, err := mapConstantFieldType(constant.Type)
	if err != nil {
		return nil, err
	}

	return &ConstantDetails{
		Type:   pointer.From(constantType),
		Values: values,
	}, nil
}

func parseModelFromFilePath(filePath string) (*ModelDetails, error) {
	var model dataapimodels.Model

	contents, err := loadJson(filePath)
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &model); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", filePath, err)
	}

	fieldDetails := make(map[string]FieldDetails)
	for _, field := range model.Fields {
		fieldDetail := FieldDetails{
			IsTypeHint:  field.ContainsDiscriminatedTypeValue,
			JsonName:    field.JsonName,
			Optional:    field.Optional,
			Required:    field.Required,
			Description: field.Description,
		}

		objectDefinition, err := mapObjectDefinition(&field.ObjectDefinition)
		if err != nil {
			return nil, err
		}
		fieldDetail.ObjectDefinition = pointer.From(objectDefinition)

		if field.ObjectDefinition.DateFormat != nil {
			dateFormat, err := mapDateFormatType(*field.ObjectDefinition.DateFormat)
			if err != nil {
				return nil, err
			}
			fieldDetail.DateFormat = dateFormat
		}

		if field.ObjectDefinition.MinItems != nil && field.ObjectDefinition.MaxItems != nil {
			fieldDetail.Validation = &FieldValidationDetails{
				Type:   RangeFieldValidationType,
				Values: pointer.To([]interface{}{field.ObjectDefinition.MinItems, field.ObjectDefinition.MaxItems}),
			}
		}
		fieldDetails[field.Name] = fieldDetail
	}

	return &ModelDetails{
		Fields:         fieldDetails,
		ParentTypeName: model.DiscriminatedParentModelName,
		TypeHintValue:  model.DiscriminatedTypeValue,
		TypeHintIn:     model.TypeHintIn,
	}, nil
}

func parseOperationFromFilePath(filePath string, constants map[string]ConstantDetails, apiModels map[string]ModelDetails, resourceIds map[string]ResourceIdDefinition) (*ResourceOperations, error) {
	var operation dataapimodels.Operation

	contents, err := loadJson(filePath)
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &operation); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", filePath, err)
	}

	resourceOperations := ResourceOperations{
		ContentType:                      operation.ContentType,
		ExpectedStatusCodes:              operation.ExpectedStatusCodes,
		LongRunning:                      operation.LongRunning,
		Method:                           operation.HTTPMethod,
		FieldContainingPaginationDetails: operation.FieldContainingPaginationDetails,
		Options:                          nil,
		UriSuffix:                        operation.UriSuffix,
	}

	if resourceIdName := operation.ResourceIdName; resourceIdName != nil {
		if _, ok := resourceIds[*resourceIdName]; !ok {
			return nil, fmt.Errorf("resource id %q for operation not found", *resourceIdName)
		}
		resourceOperations.ResourceIdName = resourceIdName
	}

	requestObject, err := mapObjectDefinition(operation.RequestObject)
	if err != nil {
		return nil, fmt.Errorf("processing Request Object: %+v", err)
	}
	resourceOperations.RequestObject = requestObject

	responseObject, err := mapObjectDefinition(operation.ResponseObject)
	if err != nil {
		return nil, fmt.Errorf("processing Response Object: %+v", err)
	}
	resourceOperations.ResponseObject = responseObject

	if operation.Options != nil {
		options := make(map[string]OperationOptions)
		for _, option := range *operation.Options {
			operationOptions := OperationOptions{
				HeaderName:      option.HeaderName,
				QueryStringName: option.QueryString,
				Required:        option.Required,
				// TODO thread Optional through so this can be exposed through the API
				// Optional: option.Optional
			}
			if option.ObjectDefinition != nil {
				optionObjectDefinition, err := mapOptionObjectDefinition(option.ObjectDefinition, constants, apiModels)
				if err != nil {
					return nil, err
				}
				operationOptions.ObjectDefinition = optionObjectDefinition
			}
			options[option.Field] = operationOptions
		}
		resourceOperations.Options = pointer.To(options)
	}

	return &resourceOperations, nil
}

func (s *ServicesRepositoryImpl) ProcessTerraformDefinitions(serviceName string) (*TerraformDetails, error) {
	terraformDetails := TerraformDetails{
		Resources:   make(map[string]TerraformResourceDetails),
		DataSources: make(map[string]TerraformDataSourceDetails),
	}

	terraformDefinitionsPath := path.Join(s.serviceDirectory[serviceName], "Terraform")
	files, err := os.ReadDir(terraformDefinitionsPath)
	if err != nil {
		if strings.Contains(err.Error(), "no such file or directory") {
			return nil, nil
		}
		return nil, fmt.Errorf("retrieving definitions under %s: %+v", terraformDefinitionsPath, err)
	}

	for _, file := range files {
		if file.IsDir() {
			continue
		}

		definitionName, definitionType, err := getTerraformDefinitionInfo(file.Name())
		if err != nil {
			return nil, err
		}
		// todo do we have to do the same for DataSources
		if _, ok := terraformDetails.Resources[definitionName]; !ok {
			terraformDetails.Resources[definitionName] = TerraformResourceDetails{
				ResourceName: definitionName,
			}
		}
		resource := terraformDetails.Resources[definitionName]

		// we lower case these so that it's compatible with other OS e.g. Windows
		switch strings.ToLower(definitionType) {
		case "resource":
			if resource, err = parseTerraformDefinitionResourceFromFilePath(terraformDefinitionsPath, file, resource); err != nil {
				return nil, err
			}

		case "resource-mappings":
			resource.Mappings, err = parseTerraformDefinitionResourceMappingsFromFilePath(terraformDefinitionsPath, file)
			if err != nil {
				return nil, err
			}

		case "resource-schema":
			resource.SchemaModels, err = parseTerraformDefinitionResourceSchemaFromFilePath(terraformDefinitionsPath, file)
			if err != nil {
				return nil, err
			}

		case "resource-tests":
			resource.Tests, err = parseTerraformDefinitionResourceTestsFromFilePath(terraformDefinitionsPath, file)
			if err != nil {
				return nil, err
			}
		}

		terraformDetails.Resources[definitionName] = resource
	}

	terraformTestsPath := path.Join(terraformDefinitionsPath, "Tests")
	testFiles, err := os.ReadDir(terraformTestsPath)
	if err != nil {
		if strings.Contains(err.Error(), "no such file or directory") {
			return nil, nil
		}
		return nil, fmt.Errorf("retrieving tests under %s: %+v", terraformTestsPath, err)
	}

	for _, file := range testFiles {
		if file.IsDir() {
			continue
		}

		// todo the `_` is defintionType (ie. Resource, Datasource?), we'll probably do something with that later but for now we'll ignore
		definitionName, _, testType, err := getTerraformTestInfo(file.Name())
		if err != nil {
			return nil, err
		}

		if _, ok := terraformDetails.Resources[definitionName]; !ok {
			break
		}
		resource := terraformDetails.Resources[definitionName]
		tests := resource.Tests

		lowerCaseTestType := strings.ToLower(testType)
		switch {
		case lowerCaseTestType == "basic-test":
			basicConfig, err := parseTerraformTestFromFilePath(terraformTestsPath, file)
			if err != nil {
				return nil, err
			}
			tests.BasicConfiguration = basicConfig
		case lowerCaseTestType == "complete-test":
			completeConfig, err := parseTerraformTestFromFilePath(terraformTestsPath, file)
			if err != nil {
				return nil, err
			}
			tests.CompleteConfiguration = &completeConfig
		case lowerCaseTestType == "requires-import-test":
			requiresImportConfig, err := parseTerraformTestFromFilePath(terraformTestsPath, file)
			if err != nil {
				return nil, err
			}
			tests.RequiresImportConfiguration = requiresImportConfig
		case lowerCaseTestType == "template-test":
			templateConfig, err := parseTerraformTestFromFilePath(terraformTestsPath, file)
			if err != nil {
				return nil, err
			}
			tests.TemplateConfiguration = &templateConfig

		case strings.HasPrefix(lowerCaseTestType, "other"):
			// todo we're assuming that tests are read in order and we should instead confirm that order
			testName, _, err := getTerraformOtherTestInfo(testType)
			if err != nil {
				return nil, err
			}

			if tests.OtherTests == nil {
				tests.OtherTests = make(map[string][]string)
			}
			otherTests := tests.OtherTests

			if otherTests[testName] == nil {
				otherTests[testName] = make([]string, 0)
			}
			otherTest := otherTests[testName]

			otherTestConfig, err := parseTerraformTestFromFilePath(terraformTestsPath, file)
			if err != nil {
				return nil, err
			}

			otherTest = append(otherTest, otherTestConfig)
			otherTests[testName] = otherTest
			tests.OtherTests = otherTests
		}

		resource.Tests = tests
		terraformDetails.Resources[definitionName] = resource
	}

	return &terraformDetails, nil
}

func parseTerraformDefinitionResourceFromFilePath(resourcePath string, file os.DirEntry, definition TerraformResourceDetails) (TerraformResourceDetails, error) {
	contents, err := loadJson(path.Join(resourcePath, file.Name()))
	if err != nil {
		return definition, err
	}

	var resourceDefinition dataapimodels.TerraformResourceDefinition

	if err := json.Unmarshal(*contents, &resourceDefinition); err != nil {
		return definition, fmt.Errorf("unmarshaling Terraform Resource Definition")
	}

	definition.DisplayName = resourceDefinition.DisplayName
	definition.GenerateModel = resourceDefinition.GenerateModel
	definition.GenerateIdValidation = resourceDefinition.GenerateIdValidationFunction
	definition.GenerateSchema = resourceDefinition.GenerateSchema
	definition.ApiVersion = resourceDefinition.ApiVersion
	definition.Generate = resourceDefinition.Generate
	definition.Resource = resourceDefinition.Resource
	definition.ResourceIdName = resourceDefinition.ResourceIdName
	definition.SchemaModelName = resourceDefinition.SchemaModelName
	definition.Label = resourceDefinition.Label

	definition.CreateMethod = MethodDefinition{
		Generate:         resourceDefinition.CreateMethod.Generate,
		MethodName:       resourceDefinition.CreateMethod.Name,
		TimeoutInMinutes: resourceDefinition.CreateMethod.TimeoutInMinutes,
	}

	definition.ReadMethod = MethodDefinition{
		Generate:         resourceDefinition.ReadMethod.Generate,
		MethodName:       resourceDefinition.ReadMethod.Name,
		TimeoutInMinutes: resourceDefinition.ReadMethod.TimeoutInMinutes,
	}

	definition.DeleteMethod = MethodDefinition{
		Generate:         resourceDefinition.DeleteMethod.Generate,
		MethodName:       resourceDefinition.DeleteMethod.Name,
		TimeoutInMinutes: resourceDefinition.DeleteMethod.TimeoutInMinutes,
	}

	if resourceDefinition.UpdateMethod != nil {
		definition.UpdateMethod = &MethodDefinition{
			Generate:         resourceDefinition.UpdateMethod.Generate,
			MethodName:       resourceDefinition.UpdateMethod.Name,
			TimeoutInMinutes: resourceDefinition.UpdateMethod.TimeoutInMinutes,
		}
	}

	definition.Documentation = ResourceDocumentationDefinition{
		Category:        resourceDefinition.DisplayName,
		Description:     resourceDefinition.Description,
		ExampleUsageHcl: resourceDefinition.ExampleUsage,
	}

	// todo the following are missing from the current information available
	// TerraformResourceDetails{
	//	Documentation:  ResourceDocumentationDefinition{},
	//	Resource:       "",
	// }

	return definition, nil
}

func parseTerraformDefinitionResourceMappingsFromFilePath(resourcePath string, file os.DirEntry) (MappingDefinition, error) {
	var mappings MappingDefinition
	contents, err := loadJson(path.Join(resourcePath, file.Name()))
	if err != nil {
		return mappings, err
	}

	var resourceMapping dataapimodels.TerraformMappingDefinition

	if err := json.Unmarshal(*contents, &resourceMapping); err != nil {
		return mappings, fmt.Errorf("unmarshaling Terraform Resource Mapping")
	}

	if resourceMapping.ResourceIdMappings != nil {
		resourceIds := make([]ResourceIdMappingDefinition, 0)
		for _, id := range *resourceMapping.ResourceIdMappings {
			resourceIds = append(resourceIds, ResourceIdMappingDefinition{
				SchemaFieldName:    id.SchemaFieldName,
				SegmentName:        id.SegmentName,
				ParsedFromParentID: id.ParsedFromParentId,
			})
		}

		mappings.ResourceId = resourceIds
	}

	if resourceMapping.FieldMappings != nil {
		fields := make([]FieldMappingDefinition, 0)
		for _, fieldMapping := range *resourceMapping.FieldMappings {
			field := FieldMappingDefinition{
				Type: MappingDefinitionType(fieldMapping.Type),
			}

			if fieldMapping.DirectAssignment != nil {
				field.DirectAssignment = &FieldMappingDirectAssignmentDefinition{
					SchemaModelName: fieldMapping.DirectAssignment.SchemaModelName,
					SchemaFieldPath: fieldMapping.DirectAssignment.SchemaFieldPath,
					SdkModelName:    fieldMapping.DirectAssignment.SdkModelName,
					SdkFieldPath:    fieldMapping.DirectAssignment.SdkFieldPath,
				}
			}

			if fieldMapping.ModelToModel != nil {
				field.ModelToModel = &FieldMappingModelToModelDefinition{
					SchemaModelName: fieldMapping.ModelToModel.SchemaModelName,
					SdkModelName:    fieldMapping.ModelToModel.SdkModelName,
					SdkFieldName:    fieldMapping.ModelToModel.SdkFieldName,
				}
			}

			if fieldMapping.Manual != nil {
				field.Manual = &FieldManualMappingDefinition{
					MethodName: fieldMapping.Manual.MethodName,
				}
			}

			fields = append(fields, field)
		}
		mappings.Fields = fields
	}

	if resourceMapping.ModelToModelMappings != nil {
		modelToModels := make([]ModelToModelMappingDefinition, 0)
		for _, modelToModelMapping := range *resourceMapping.ModelToModelMappings {
			modelToModels = append(modelToModels, ModelToModelMappingDefinition{
				SchemaModelName: modelToModelMapping.SchemaModelName,
				SdkModelName:    modelToModelMapping.SdkModelName,
			})
		}
		mappings.ModelToModels = modelToModels
	}

	return mappings, nil
}

func parseTerraformTestFromFilePath(resourcePath string, file os.DirEntry) (string, error) {
	contents, err := loadHcl(path.Join(resourcePath, file.Name()))
	if err != nil {
		return contents, err
	}

	return contents, nil
}

func parseTerraformDefinitionResourceSchemaFromFilePath(resourcePath string, file os.DirEntry) (map[string]TerraformSchemaModelDefinition, error) {
	schemaModelDefinition := make(map[string]TerraformSchemaModelDefinition)
	contents, err := loadJson(path.Join(resourcePath, file.Name()))
	if err != nil {
		return schemaModelDefinition, err
	}

	var schemaModel dataapimodels.TerraformSchemaModel

	if err := json.Unmarshal(*contents, &schemaModel); err != nil {
		return schemaModelDefinition, fmt.Errorf("unmarshaling Terraform Resource Schema %+v", err)
	}

	fields := make(map[string]TerraformSchemaFieldDefinition)
	for _, field := range schemaModel.Fields {
		fieldDefinition := TerraformSchemaFieldDefinition{
			ObjectDefinition: terraformSchemaFieldObjectDefinitionFromField(field.ObjectDefinition),
			Computed:         pointer.From(field.Computed),
			ForceNew:         pointer.From(field.ForceNew),
			HclName:          field.HclName,
			Optional:         pointer.From(field.Optional),
			Required:         pointer.From(field.Required),
		}

		if field.Validation != nil {
			fieldDefinition.Validation = &TerraformSchemaValidationDefinition{
				Type: TerraformSchemaValidationType(field.Validation.Type),
			}

			if field.Validation.PossibleValues != nil {
				fieldDefinition.Validation.PossibleValues = &TerraformSchemaValidationPossibleValuesDefinition{
					Type:   fieldDefinition.Validation.PossibleValues.Type,
					Values: fieldDefinition.Validation.PossibleValues.Values,
				}
			}
		}

		if field.Documentation != nil {
			fieldDefinition.Documentation = TerraformSchemaDocumentationDefinition{
				Markdown: field.Documentation.Markdown,
			}
		}

		fields[field.Name] = fieldDefinition
	}

	// todo do we take the file name and strip it of these pieces or is this information somewhere else
	// the v1 data api has this value as `LoadTestResourceSchema` which is the filename (LoadTest-Resource-Schema.json) with the following stripped
	modelDefinitionName := strings.Replace(strings.Replace(file.Name(), "-", "", -1), ".json", "", -1)

	schemaModelDefinition[modelDefinitionName] = TerraformSchemaModelDefinition{
		Fields: fields,
	}

	return schemaModelDefinition, nil
}

func parseTerraformDefinitionResourceTestsFromFilePath(resourcePath string, file os.DirEntry) (TerraformResourceTestsDefinition, error) {
	contents, err := loadJson(path.Join(resourcePath, file.Name()))
	if err != nil {
		return TerraformResourceTestsDefinition{}, err
	}

	var testConfig dataapimodels.TerraformResourceTestConfig
	if err := json.Unmarshal(*contents, &testConfig); err != nil {
		return TerraformResourceTestsDefinition{}, fmt.Errorf("unmarshaling Terraform Resource Tests %+v", err)
	}

	testDefinition := TerraformResourceTestsDefinition{
		BasicConfiguration:          testConfig.BasicConfig,
		RequiresImportConfiguration: testConfig.RequiresImport,
		CompleteConfiguration:       testConfig.CompleteConfig,
		TemplateConfiguration:       testConfig.TemplateConfig,
		Generate:                    testConfig.Generate,
		OtherTests:                  testConfig.OtherTests,
	}

	return testDefinition, nil
}

func terraformSchemaFieldObjectDefinitionFromField(input dataapimodels.TerraformSchemaObjectDefinition) TerraformSchemaFieldObjectDefinition {
	objectDefinition := TerraformSchemaFieldObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          TerraformSchemaFieldType(input.Type),
	}

	if input.NestedItem != nil {
		nestedObject := terraformSchemaFieldObjectDefinitionFromField(*input.NestedItem)
		objectDefinition.NestedObject = &nestedObject
	}

	return objectDefinition
}

func parseResourceIdFromFilePath(filePath string, constants map[string]ConstantDetails) (*ResourceIdDefinition, error) {
	var resourceId dataapimodels.ResourceId

	contents, err := loadJson(filePath)
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &resourceId); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", filePath, err)
	}

	segments := make([]ResourceIdSegment, 0)
	constantNames := make([]string, 0)
	for _, segment := range resourceId.Segments {
		segmentType, err := mapResourceIdSegmentType(segment.Type)
		if err != nil {
			return nil, err
		}

		s := ResourceIdSegment{
			ConstantReference: segment.ConstantName,
			FixedValue:        segment.Value,
			Name:              segment.Name,
			Type:              pointer.From(segmentType),
		}

		switch *segmentType {
		case ConstantResourceIdSegmentType:
			if s.ConstantReference == nil {
				return nil, fmt.Errorf("constant segment has no constant reference")
			}
			constant, ok := constants[*s.ConstantReference]
			if !ok {
				return nil, fmt.Errorf("no constant definition found for constant segment reference %q", *s.ConstantReference)
			}
			constantValues := make([]string, 0)
			for _, v := range constant.Values {
				constantValues = append(constantValues, v)
			}
			sort.Strings(constantValues)
			s.ExampleValue = constantValues[0]

			constantNames = append(constantNames, *s.ConstantReference)
		case ResourceGroupResourceIdSegmentType:
			s.ExampleValue = "example-resource-group"
		case ResourceProviderResourceIdSegmentType:
			s.ExampleValue = pointer.From(segment.Value)
		case ScopeResourceIdSegmentType:
			s.ExampleValue = "/subscriptions/12345678-1234-9876-4563-123456789012/resourceGroups/some-resource-group"
		case StaticResourceIdSegmentType:
			s.ExampleValue = pointer.From(segment.Value)
		case SubscriptionIdResourceIdSegmentType:
			s.ExampleValue = "12345678-1234-9876-4563-123456789012"
		case UserSpecifiedResourceIdSegmentType:
			s.ExampleValue = strings.TrimSuffix(segment.Name, "Name") + "Value"
		default:
			return nil, fmt.Errorf("unimplemented segment type %q for example value", *segmentType)
		}
		segments = append(segments, s)

	}

	return &ResourceIdDefinition{
		CommonAlias: resourceId.CommonAlias,
		Id:          resourceId.Id,
		Segments:    segments,
		// TODO This might want to be it's own Data API endpoint where ConstantNames is a unique and ordered map
		// however this might already be supported under the `commonTypes` endpoint, keeping this here until clarified
		ConstantNames: constantNames,
	}, nil
}

func mapObjectDefinition(input *dataapimodels.ObjectDefinition) (*ObjectDefinition, error) {
	if input == nil {
		return nil, nil
	}

	objectDefinitionType, err := mapObjectDefinitionType(input.Type)
	if err != nil {
		return nil, err
	}

	output := ObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          pointer.From(objectDefinitionType),
	}

	if input.NestedItem != nil {
		nestedItem, err := mapObjectDefinition(input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping Nested Item for Object Definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	return &output, nil
}

func mapOptionObjectDefinition(input *dataapimodels.OptionObjectDefinition, constants map[string]ConstantDetails, apiModels map[string]ModelDetails) (*OptionObjectDefinition, error) {
	optionObjectType, err := mapOptionObjectDefinitionType(input.Type)
	if err != nil {
		return nil, err
	}

	output := OptionObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          pointer.From(optionObjectType),
	}

	if input.NestedItem != nil {
		nestedItem, err := mapOptionObjectDefinition(input.NestedItem, constants, apiModels)
		if err != nil {
			return nil, fmt.Errorf("mapping Nested Item for Option Object Definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	if err := validateOptionObjectDefinition(output, constants, apiModels); err != nil {
		return nil, fmt.Errorf("validating mapped Option Object Definition: %+v", err)
	}

	return &output, nil
}

func mapDateFormatType(input dataapimodels.DateFormat) (*DateFormat, error) {
	mappings := map[dataapimodels.DateFormat]DateFormat{
		dataapimodels.RFC3339DateFormat: RFC3339DateFormat,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Date Format Type %q", string(input))
}

func mapObjectDefinitionType(input dataapimodels.ObjectDefinitionType) (*ObjectDefinitionType, error) {
	mappings := map[dataapimodels.ObjectDefinitionType]ObjectDefinitionType{
		dataapimodels.BooleanObjectDefinitionType:    BooleanObjectDefinitionType,
		dataapimodels.DateTimeObjectDefinitionType:   DateTimeObjectDefinitionType,
		dataapimodels.IntegerObjectDefinitionType:    IntegerObjectDefinitionType,
		dataapimodels.FloatObjectDefinitionType:      FloatObjectDefinitionType,
		dataapimodels.RawFileObjectDefinitionType:    RawFileObjectDefinitionType,
		dataapimodels.RawObjectObjectDefinitionType:  RawObjectObjectDefinitionType,
		dataapimodels.ReferenceObjectDefinitionType:  ReferenceObjectDefinitionType,
		dataapimodels.StringObjectDefinitionType:     StringObjectDefinitionType,
		dataapimodels.CsvObjectDefinitionType:        CsvObjectDefinitionType,
		dataapimodels.DictionaryObjectDefinitionType: DictionaryObjectDefinitionType,
		dataapimodels.ListObjectDefinitionType:       ListObjectDefinitionType,

		dataapimodels.EdgeZoneObjectDefinitionType:                                EdgeZoneObjectDefinitionType,
		dataapimodels.LocationObjectDefinitionType:                                LocationObjectDefinitionType,
		dataapimodels.TagsObjectDefinitionType:                                    TagsObjectDefinitionType,
		dataapimodels.SystemAssignedIdentityObjectDefinitionType:                  SystemAssignedIdentityObjectDefinitionType,
		dataapimodels.SystemAndUserAssignedIdentityListObjectDefinitionType:       SystemAndUserAssignedIdentityListObjectDefinitionType,
		dataapimodels.SystemAndUserAssignedIdentityMapObjectDefinitionType:        SystemAndUserAssignedIdentityMapObjectDefinitionType,
		dataapimodels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType: LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
		dataapimodels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType:  LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
		dataapimodels.SystemOrUserAssignedIdentityListObjectDefinitionType:        SystemOrUserAssignedIdentityListObjectDefinitionType,
		dataapimodels.SystemOrUserAssignedIdentityMapObjectDefinitionType:         SystemOrUserAssignedIdentityMapObjectDefinitionType,
		dataapimodels.UserAssignedIdentityListObjectDefinitionType:                UserAssignedIdentityListObjectDefinitionType,
		dataapimodels.UserAssignedIdentityMapObjectDefinitionType:                 UserAssignedIdentityMapObjectDefinitionType,
		dataapimodels.SystemDataObjectDefinitionType:                              SystemDataObjectDefinitionType,
		dataapimodels.ZoneObjectDefinitionType:                                    ZoneObjectDefinitionType,
		dataapimodels.ZonesObjectDefinitionType:                                   ZonesObjectDefinitionType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Object Definition Type %q", string(input))
}

func mapOptionObjectDefinitionType(input dataapimodels.OptionObjectDefinitionType) (*OptionObjectDefinitionType, error) {
	mappings := map[dataapimodels.OptionObjectDefinitionType]OptionObjectDefinitionType{
		dataapimodels.BooleanOptionObjectDefinitionType:   BooleanOptionObjectDefinition,
		dataapimodels.IntegerOptionObjectDefinitionType:   IntegerOptionObjectDefinition,
		dataapimodels.FloatOptionObjectDefinitionType:     FloatOptionObjectDefinitionType,
		dataapimodels.StringOptionObjectDefinitionType:    StringOptionObjectDefinitionType,
		dataapimodels.CsvOptionObjectDefinitionType:       CsvOptionObjectDefinitionType,
		dataapimodels.ListOptionObjectDefinitionType:      ListOptionObjectDefinitionType,
		dataapimodels.ReferenceOptionObjectDefinitionType: ReferenceOptionObjectDefinitionType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Options Object Definition Type %q", string(input))
}

func mapConstantFieldType(input dataapimodels.ConstantType) (*ConstantType, error) {
	mappings := map[dataapimodels.ConstantType]ConstantType{
		dataapimodels.FloatConstant:   FloatConstant,
		dataapimodels.IntegerConstant: IntegerConstant,
		dataapimodels.StringConstant:  StringConstant,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}

func mapResourceIdSegmentType(input dataapimodels.ResourceIdSegmentType) (*ResourceIdSegmentType, error) {
	mappings := map[dataapimodels.ResourceIdSegmentType]ResourceIdSegmentType{
		dataapimodels.ConstantResourceIdSegmentType:         ConstantResourceIdSegmentType,
		dataapimodels.ResourceGroupResourceIdSegmentType:    ResourceGroupResourceIdSegmentType,
		dataapimodels.ResourceProviderResourceIdSegmentType: ResourceProviderResourceIdSegmentType,
		dataapimodels.ScopeResourceIdSegmentType:            ScopeResourceIdSegmentType,
		dataapimodels.StaticResourceIdSegmentType:           StaticResourceIdSegmentType,
		dataapimodels.SubscriptionIdResourceIdSegmentType:   SubscriptionIdResourceIdSegmentType,
		dataapimodels.UserSpecifiedResourceIdSegmentType:    UserSpecifiedResourceIdSegmentType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Resource Id Segment Type %q", string(input))
}
