package repositories

import (
	"encoding/json"
	"fmt"
	"os"
	"path"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories/models"
)

type ServicesRepository interface {
	GetByName(serviceName string, serviceType ServiceType) (*ServiceDetails, error)
	GetAll(serviceType ServiceType) (*[]ServiceDetails, error)
	ClearCache() error
}

var _ ServicesRepository = &ServicesRepositoryImpl{}

type ServicesRepositoryImpl struct {
	// directory is where the api definitions for all services exist - this is where the server will read from
	directory string

	// Service, Version and Resource definitions loaded and unmarshalled from the JSON API definitions
	services *map[string]ServiceDetails

	// serviceNames is a list containing the names of services which should be loaded
	// this allows the loading/parsing of a subset of services for faster iterations during development
	serviceNames *[]string
}

type ApiDefinition struct {
	// The name of the ApiDefinition, it forms part of the name of the JSON files that contain the definitions which are
	// loaded into the Data API
	name string

	// The type of definition e.g. Constant, Model, Operation, ResourceId
	definitionType string
}

func NewServicesRepository(directory string, serviceType ServiceType, serviceNames *[]string) ServicesRepository {
	// TODO we should implement some validation in here ensure that there aren't multiple API definitions for a Service
	// e.g. definitions for `Containers` under `handwritten` and under `resource-manager`
	// we probably want to save a map of map[ServiceName]FilePath for each serviceType to reduce the overhead of
	// iterating through the directories multiple times.
	return &ServicesRepositoryImpl{
		directory:    path.Join(directory, string(serviceType)),
		serviceNames: serviceNames,
	}
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
		var err error
		services := s.serviceNames
		if services == nil {
			// this means we haven't passed any specific services to the serve command, so we get whatever is available in the api definitions directory
			services, err = listSubDirectories(s.directory)
			if err != nil {
				return nil, fmt.Errorf("retrieving list of services for %s: %+v", serviceType, err)
			}
		}

		if services != nil {
			for _, service := range *services {
				// loads the service definition locations
				serviceDetail, err := s.GetByName(service, serviceType)
				if err != nil {
					return nil, fmt.Errorf("retrieving service details for %s: %+v", service, err)
				}
				serviceDetails = append(serviceDetails, *serviceDetail)
			}
		}
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
	serviceDirectory := fmt.Sprintf("%s/%s", s.directory, serviceName)
	if _, err := os.Stat(serviceDirectory); os.IsNotExist(err) {
		return nil, fmt.Errorf("service %q does not exist: %+v", serviceName, err)
	}

	serviceDetails, err := s.ProcessServiceDefinitions(serviceName)
	if err != nil {
		return nil, fmt.Errorf("processing service definition for %s: %+v", serviceName, err)
	}

	services := make(map[string]ServiceDetails, 0)

	if s.services != nil {
		services = *s.services
	}

	services[serviceName] = *serviceDetails
	s.services = &services

	return serviceDetails, nil
}

func (s *ServicesRepositoryImpl) ProcessServiceDefinitions(serviceName string) (*ServiceDetails, error) {
	versions, err := listSubDirectories(fmt.Sprintf("%s/%s", s.directory, serviceName))
	if err != nil {
		return nil, fmt.Errorf("retrieving versions: %+v", err)
	}

	versionDefinitions := make(map[string]*ServiceApiVersionDetails, 0)

	if versions != nil {
		for _, version := range *versions {
			resources, err := listSubDirectories(fmt.Sprintf("%s/%s/%s", s.directory, serviceName, version))
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

	return &ServiceDetails{
		Name: serviceName,
		// TODO RP name needs to be stored in the api definitions
		// ResourceProvider: fmt.Sprintf("Microsoft.%s", serviceName),
		ApiVersions: versionDefinitions,
	}, nil
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
	constants := make(map[string]ConstantDetails, 0)
	apiModels := make(map[string]ModelDetails)
	operations := make(map[string]ResourceOperations)
	resourceIds := make(map[string]ResourceIdDefinition)

	resourcePath := path.Join(s.directory, serviceName, version, resource)
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
		}

		if strings.EqualFold(strings.ToLower(definitionType), "operation") {
			operationDefinitionFiles = append(operationDefinitionFiles, definition)
			continue
		}

		definitionFiles = append(definitionFiles, definition)
	}

	definitionFiles = append(definitionFiles, operationDefinitionFiles...)

	for _, file := range definitionFiles {
		definitionPath := path.Join(resourcePath, fmt.Sprintf("%s-%s", file.definitionType, file.name))
		if err != nil {
			return nil, err
		}

		// we lower case this comparison so that it's compatible with other OS e.g. Windows
		switch strings.ToLower(file.definitionType) {
		// Ordering here is important, all Constants need to be processed first, then all Models
		case "constant":
			constant, err := parseConstantFromFilePath(definitionPath)
			if err != nil {
				return nil, fmt.Errorf("processing constant %s: %+v", file.name, err)
			}

			constants[file.name] = pointer.From(constant)
		case "model":
			model, err := parseModelFromFilePath(definitionPath, constants)
			if err != nil {
				return nil, fmt.Errorf("processing model %s: %+v", file.name, err)
			}

			apiModels[file.name] = pointer.From(model)
		case "resourceid":
			resourceId, err := parseResourceIdFromFilePath(definitionPath, constants)
			if err != nil {
				return nil, fmt.Errorf("processing resource id %s: %+v", file.name, err)
			}

			resourceIds[file.name] = pointer.From(resourceId)
		case "operation":
			operationDetails, err := parseOperationFromFilePath(definitionPath)
			if err != nil {
				return nil, fmt.Errorf("processing operation %s: %+v", file.name, err)
			}

			operations[file.name] = pointer.From(operationDetails)
		}
	}

	resourceSchema.Constants = constants
	resourceSchema.Models = apiModels
	resourceSchema.ResourceIds = resourceIds
	resourceDefinition.Schema = resourceSchema
	resourceDefinition.Operations = operations

	return &resourceDefinition, nil
}

func parseConstantFromFilePath(filePath string) (*ConstantDetails, error) {
	var constant models.Constant

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

func parseModelFromFilePath(filePath string, constants map[string]ConstantDetails) (*ModelDetails, error) {
	var model models.Model

	contents, err := loadJson(filePath)
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &model); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", filePath, err)
	}

	typeHintIn := ""
	fieldDetails := make(map[string]FieldDetails)
	for _, field := range model.Fields {
		fieldDetail := FieldDetails{
			IsTypeHint: field.ContainsDiscriminatedTypeValue,
			JsonName:   field.JsonName,
			Optional:   field.Optional,
			Required:   field.Required,
			// TODO remove Default attribute throughout the models since this isn't used at the moment
			//Default:          nil,
			// TODO exposed when other #3238 is merged
			//Description:      "",
			//ForceNew:         false,
		}

		objectDefinition, err := mapObjectDefinition(&field.ObjectDefinition)
		if err != nil {
			return nil, err
		}
		fieldDetail.ObjectDefinition = pointer.From(objectDefinition)

		if field.ContainsDiscriminatedTypeValue {
			if model.DiscriminatedTypeValue == nil || model.DiscriminatedParentModelName == nil {
				return nil, fmt.Errorf("missing discriminated type value and parent model name for field %q which is a type hint ", field.Name)
			}
			if typeHintIn != "" {
				return nil, fmt.Errorf("a type hint field already exists for this model: existing: %q, new: %q", typeHintIn, field.Name)
			}
			typeHintIn = field.Name
		}

		if field.ObjectDefinition.DateFormat != nil {
			dateFormat, err := mapDateFormatType(*field.ObjectDefinition.DateFormat)
			if err != nil {
				return nil, err
			}
			fieldDetail.DateFormat = dateFormat
		}

		if field.ObjectDefinition.MinItems != nil && field.ObjectDefinition.MaxItems != nil {
			// TODO these will probably be expanded on in future
			fieldDetail.Validation = &FieldValidationDetails{
				Type:   RangeFieldValidationType,
				Values: pointer.To([]interface{}{field.ObjectDefinition.MinItems, field.ObjectDefinition.MaxItems}),
			}
		}
	}

	return &ModelDetails{
		Fields:         fieldDetails,
		ParentTypeName: model.DiscriminatedParentModelName,
		TypeHintValue:  model.DiscriminatedTypeValue,
		TypeHintIn:     pointer.To(typeHintIn),
	}, nil
}

func parseOperationFromFilePath(filePath string) (*ResourceOperations, error) {
	var operation models.Operation

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
		ResourceIdName:                   operation.ResourceIdName,
		FieldContainingPaginationDetails: operation.FieldContainingPaginationDetails,
		Options:                          nil,
		UriSuffix:                        operation.UriSuffix,
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
				optionObjectDefinition, err := mapOptionObjectDefinition(option.ObjectDefinition)
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

func parseResourceIdFromFilePath(filePath string, constants map[string]ConstantDetails) (*ResourceIdDefinition, error) {
	var resourceId models.ResourceId

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
			if s.ConstantReference != nil {
				if _, ok := constants[pointer.From(s.ConstantReference)]; ok {
					constantNames = append(constantNames, pointer.From(s.ConstantReference))
					continue
				}
			}
			return nil, fmt.Errorf("no constant definition found for constant segment reference %q", s.ConstantReference)
		case ResourceGroupResourceIdSegmentType:
			s.ExampleValue = "example-resource-group"
		case ResourceProviderResourceIdSegmentType:
			continue
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

func mapObjectDefinition(input *models.ObjectDefinition) (*ObjectDefinition, error) {
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

func mapOptionObjectDefinition(input *models.OptionObjectDefinition) (*OptionObjectDefinition, error) {
	optionObjectType, err := mapOptionObjectDefinitionType(input.Type)
	if err != nil {
		return nil, err
	}

	output := OptionObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          pointer.From(optionObjectType),
	}

	if input.NestedItem != nil {
		nestedItem, err := mapOptionObjectDefinition(input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping Nested Item for Option Object Definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	return &output, nil
}

func mapDateFormatType(input models.DateFormat) (*DateFormat, error) {
	mappings := map[models.DateFormat]DateFormat{
		models.RFC3339DateFormat: RFC3339DateFormat,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Date Format Type %q", string(input))
}

func mapObjectDefinitionType(input models.ObjectDefinitionType) (*ObjectDefinitionType, error) {
	mappings := map[models.ObjectDefinitionType]ObjectDefinitionType{
		models.BooleanObjectDefinitionType:    BooleanObjectDefinitionType,
		models.DateTimeObjectDefinitionType:   DateTimeObjectDefinitionType,
		models.IntegerObjectDefinitionType:    IntegerObjectDefinitionType,
		models.FloatObjectDefinitionType:      FloatObjectDefinitionType,
		models.RawFileObjectDefinitionType:    RawFileObjectDefinitionType,
		models.RawObjectObjectDefinitionType:  RawObjectObjectDefinitionType,
		models.ReferenceObjectDefinitionType:  ReferenceObjectDefinitionType,
		models.StringObjectDefinitionType:     StringObjectDefinitionType,
		models.CsvObjectDefinitionType:        CsvObjectDefinitionType,
		models.DictionaryObjectDefinitionType: DictionaryObjectDefinitionType,
		models.ListObjectDefinitionType:       ListObjectDefinitionType,

		// TODO in a separate PR - add the more specific ObjectDefinition Types e.g. EdgeZone, Location, Tags etc.
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Object Definition Type %q", string(input))
}

func mapOptionObjectDefinitionType(input models.OptionObjectDefinitionType) (*OptionObjectDefinitionType, error) {
	mappings := map[models.OptionObjectDefinitionType]OptionObjectDefinitionType{
		models.BooleanOptionObjectDefinitionType:   BooleanOptionObjectDefinition,
		models.IntegerOptionObjectDefinitionType:   IntegerOptionObjectDefinition,
		models.FloatOptionObjectDefinitionType:     FloatOptionObjectDefinitionType,
		models.StringOptionObjectDefinitionType:    StringOptionObjectDefinitionType,
		models.CsvOptionObjectDefinitionType:       CsvOptionObjectDefinitionType,
		models.ListOptionObjectDefinitionType:      ListOptionObjectDefinitionType,
		models.ReferenceOptionObjectDefinitionType: ReferenceOptionObjectDefinitionType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Options Object Definition Type %q", string(input))
}

func mapConstantFieldType(input models.ConstantType) (*ConstantType, error) {
	mappings := map[models.ConstantType]ConstantType{
		models.FloatConstant:   FloatConstant,
		models.IntegerConstant: IntegerConstant,
		models.StringConstant:  StringConstant,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}

func mapResourceIdSegmentType(input models.ResourceIdSegmentType) (*ResourceIdSegmentType, error) {
	mappings := map[models.ResourceIdSegmentType]ResourceIdSegmentType{
		models.ConstantResourceIdSegmentType:         ConstantResourceIdSegmentType,
		models.ResourceGroupResourceIdSegmentType:    ResourceGroupResourceIdSegmentType,
		models.ResourceProviderResourceIdSegmentType: ResourceProviderResourceIdSegmentType,
		models.ScopeResourceIdSegmentType:            ScopeResourceIdSegmentType,
		models.StaticResourceIdSegmentType:           StaticResourceIdSegmentType,
		models.SubscriptionIdResourceIdSegmentType:   SubscriptionIdResourceIdSegmentType,
		models.UserSpecifiedResourceIdSegmentType:    UserSpecifiedResourceIdSegmentType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Resource Id Segment Type %q", string(input))
}
