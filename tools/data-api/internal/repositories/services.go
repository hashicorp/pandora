package repositories

import (
	"encoding/json"
	"fmt"
	"os"
	"path"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
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

func NewServicesRepository(directory string, serviceType ServiceType, serviceNames *[]string) ServicesRepository {
	return &ServicesRepositoryImpl{
		// TODO use path.Join
		directory:    fmt.Sprintf("%s%s", directory, serviceType),
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

	// NOTE: this has been kept here for the time being to aid development since it helps to see a sample of how the incoming
	// api definitions need to be mapped
	//return &[]ServiceDetails{
	//	{
	//		Name:                 "Compute",
	//		ResourceProvider:     "Microsoft.Compute",
	//		TerraformPackageName: pointer.To("compute"),
	//		ApiVersions: map[string]*ServiceApiVersionDetails{
	//			"2020-01-01": {
	//				Name:     "2020-01-01",
	//				Generate: true,
	//				Resources: map[string]*ServiceApiVersionResourceDetails{
	//					"VirtualMachines": {
	//						Operations: map[string]ResourceOperations{
	//							"Get": {
	//								ContentType: "application/json",
	//								ExpectedStatusCodes: []int{
	//									http.StatusOK,
	//								},
	//								LongRunning:    false,
	//								Method:         http.MethodGet,
	//								RequestObject:  nil,
	//								ResourceIdName: nil,
	//								ResponseObject: &ObjectDefinition{
	//									NestedItem: &ObjectDefinition{
	//										ReferenceName: pointer.To("Panda"),
	//										Type:          ReferenceObjectDefinitionType,
	//									},
	//									ReferenceName: pointer.To("Computa"),
	//									Type:          ReferenceObjectDefinitionType,
	//								},
	//								FieldContainingPaginationDetails: nil,
	//								Options:                          nil,
	//								UriSuffix:                        nil,
	//							},
	//						},
	//						Schema: ResourceSchema{
	//							Constants: map[string]ConstantDetails{},
	//							Models: map[string]ModelDetails{
	//								"Computa": {
	//									Fields: map[string]FieldDetails{
	//										"Name": {
	//											ObjectDefinition: ObjectDefinition{
	//												Type: ReferenceObjectDefinitionType,
	//											},
	//											Required: true,
	//										},
	//									},
	//									TypeHintIn:    nil,
	//									TypeHintValue: nil,
	//								},
	//							},
	//							ResourceIds: map[string]ResourceIdDefinition{},
	//						},
	//					},
	//				},
	//				Source: HandWrittenApiDefinitionsSource,
	//			},
	//		},
	//		TerraformDetails: TerraformDetails{
	//			Resources: map[string]TerraformResourceDetails{
	//				"virtual_machine": {
	//					ApiVersion: "2020-01-01",
	//					CreateMethod: MethodDefinition{
	//						Generate:         true,
	//						MethodName:       "VirtualMachineCreateOrUpdate",
	//						TimeoutInMinutes: 30,
	//					},
	//					DeleteMethod: MethodDefinition{
	//						Generate:         true,
	//						MethodName:       "VirtualMachineDelete",
	//						TimeoutInMinutes: 30,
	//					},
	//					DisplayName: "Virtual Machine",
	//					Documentation: ResourceDocumentationDefinition{
	//						Description:     "Manages a Virtual Machine",
	//						ExampleUsageHcl: `resource "azurerm_virtual_machine" "example" {}`,
	//					},
	//					Generate:             true,
	//					GenerateModel:        true,
	//					GenerateIdValidation: true,
	//					GenerateSchema:       true,
	//					Mappings: MappingDefinition{
	//						Fields: []FieldMappingDefinition{
	//							{
	//								Type: "DirectAssignment",
	//								DirectAssignment: pointer.To(FieldMappingDirectAssignmentDefinition{
	//									SchemaModelName: "model",
	//									SchemaFieldPath: "name",
	//									SdkModelName:    "model",
	//									SdkFieldPath:    "name",
	//								},
	//								),
	//							},
	//							{
	//								Type: "DirectAssignment",
	//								DirectAssignment: pointer.To(FieldMappingDirectAssignmentDefinition{
	//									SchemaModelName: "model",
	//									SchemaFieldPath: "resource_group",
	//									SdkModelName:    "model",
	//									SdkFieldPath:    "resource_group",
	//								},
	//								),
	//							},
	//						},
	//						ModelToModels: []ModelToModelMappingDefinition{
	//							{
	//								SchemaModelName: "VirtualMachineSchema",
	//								SdkModelName:    "VirtualMachineProperties",
	//							},
	//						},
	//						ResourceId: []ResourceIdMappingDefinition{
	//							{
	//								SchemaFieldName:    "VirtualMachineId",
	//								SegmentName:        "virtualMachineName",
	//								ParsedFromParentID: true,
	//							},
	//							{
	//								SchemaFieldName:    "ResourceGroupName",
	//								SegmentName:        "resourceGroupName",
	//								ParsedFromParentID: false,
	//							},
	//						},
	//					},
	//					ReadMethod: MethodDefinition{
	//						Generate:         true,
	//						MethodName:       "VirtualMachineGet",
	//						TimeoutInMinutes: 5,
	//					},
	//					Resource:        "VirtualMachine",
	//					ResourceIdName:  "VirtualMachineId",
	//					ResourceName:    "VirtualMachine",
	//					SchemaModelName: "VirtualMachineSchema",
	//					SchemaModels: map[string]TerraformSchemaModelDefinition{
	//						"VirtualMachineSchema": {
	//							Fields: map[string]TerraformSchemaFieldDefinition{
	//								"VirtualMachineId": {
	//									ObjectDefinition: TerraformSchemaFieldObjectDefinition{
	//										NestedObject:  nil,
	//										ReferenceName: nil,
	//										Type:          StringTerraformSchemaFieldType,
	//									},
	//									Computed: false,
	//									ForceNew: true,
	//									HclName:  "virtual_machine_id",
	//									Optional: false,
	//									Required: true,
	//									Documentation: TerraformSchemaDocumentationDefinition{
	//										Markdown: "blah",
	//									},
	//									Validation: nil,
	//								},
	//								"Name": {
	//									ObjectDefinition: TerraformSchemaFieldObjectDefinition{
	//										NestedObject:  nil,
	//										ReferenceName: nil,
	//										Type:          StringTerraformSchemaFieldType,
	//									},
	//									Computed: false,
	//									ForceNew: true,
	//									HclName:  "name",
	//									Optional: false,
	//									Required: true,
	//									Documentation: TerraformSchemaDocumentationDefinition{
	//										Markdown: "blah",
	//									},
	//									Validation: nil,
	//								},
	//							},
	//						},
	//					},
	//					Tests: TerraformResourceTestsDefinition{
	//						BasicConfiguration:          "basictest",
	//						RequiresImportConfiguration: "importtest",
	//						CompleteConfiguration:       nil,
	//						Generate:                    false,
	//						OtherTests:                  nil,
	//						TemplateConfiguration:       nil,
	//					},
	//					UpdateMethod: pointer.To(MethodDefinition{
	//						Generate:         true,
	//						MethodName:       "VirtualMachineCreateOrUpdate",
	//						TimeoutInMinutes: 30,
	//					}),
	//				},
	//			},
	//		},
	//
	//		Generate: true,
	//	},
	//}, nil
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
	models := make(map[string]ModelDetails)
	operations := make(map[string]ResourceOperations)
	resourceIds := make(map[string]ResourceIdDefinition)

	path.Join(s.directory, serviceName, version, resource)
	resourcePath := path.Join(s.directory, serviceName, version, resource)
	files, err := os.ReadDir(resourcePath)
	if err != nil {
		return nil, fmt.Errorf("retrieving definitions under %s: %+v", resourcePath, err)
	}

	for _, file := range files {
		if file.IsDir() {
			continue
		}

		definitionPath := path.Join(resourcePath, file.Name())
		definitionType, definitionName, err := getDefinitionInfo(file.Name())
		if err != nil {
			return nil, err
		}

		// we lower case this comparison so that it's compatible with other OS e.g. Windows
		switch strings.ToLower(definitionType) {
		// Ordering here is important, all Constants need to be processed first, then all Models
		case "constant":
			constant, err := processConstant(definitionPath)
			if err != nil {
				return nil, fmt.Errorf("processing constant %s: %+v", definitionName, err)
			}

			constants[definitionName] = pointer.From(constant)
		case "model":
			model, err := processModel(definitionPath)
			if err != nil {
				return nil, fmt.Errorf("processing model %s: %+v", definitionName, err)
			}

			models[definitionName] = pointer.From(model)
		case "operation":
			operationDetails, err := processOperation(definitionPath)
			if err != nil {
				return nil, fmt.Errorf("processing operation %s: %+v", definitionName, err)
			}

			operations[definitionName] = pointer.From(operationDetails)
		case "resourceid":
			resourceId, err := processResourceId(definitionPath)
			if err != nil {
				return nil, fmt.Errorf("processing resource id %s: %+v", definitionName, err)
			}

			resourceIds[definitionName] = pointer.From(resourceId)
		}
	}

	resourceSchema.Constants = constants
	resourceSchema.Models = models
	resourceSchema.ResourceIds = resourceIds
	resourceDefinition.Schema = resourceSchema
	resourceDefinition.Operations = operations

	return &resourceDefinition, nil
}

func processConstant(path string) (*ConstantDetails, error) {
	var constant Constant

	contents, err := loadJson(fmt.Sprintf(path))
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &constant); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", path, err)
	}

	values := make(map[string]string, 0)

	for _, value := range constant.Values {
		values[value.Key] = value.Value
	}

	return &ConstantDetails{
		Type:   ConstantType(constant.Type),
		Values: values,
	}, nil
}

func processModel(path string) (*ModelDetails, error) {
	var model Model

	contents, err := loadJson(path)
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &model); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", path, err)
	}

	fieldDetails := make(map[string]FieldDetails)
	for _, field := range model.Fields {
		fieldDetail := FieldDetails{
			DateFormat:       field.ObjectDefinition.DateFormat,
			IsTypeHint:       false,
			JsonName:         field.JsonName,
			Optional : field.Optional,
			Required: field.Required,
			ObjectDefinition: processObjectDefinition(field.ObjectDefinition),
			// TODO not found
			//Default:          nil,
			//Description:      "",
			//ForceNew:         false,
		}

		if field.ObjectDefinition.MinItems != nil && field.ObjectDefinition.MaxItems != nil {
			// TODO these will probably be expanded on in future
			fieldDetail.Validation = &FieldValidationDetails{
				Type: "Range",
				Values: pointer.To([]interface{}{field.ObjectDefinition.MinItems, field.ObjectDefinition.MaxItems})
			}
		}
	}

	if model.DiscriminatedTypeValue != nil && model.DiscriminatedParentModelName != nil {
		// TODO something with TypeHintIn here
	}

	return &ModelDetails{
		Fields:        fieldDetails,
		ParentTypeName: model.DiscriminatedParentModelName,
		TypeHintValue:  model.DiscriminatedTypeValue,
		//TypeHintIn:
	}, nil
}

func processObjectDefinition(input DataApiObjectDefinition) ObjectDefinition {
	output := ObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          input.Type,
	}

	if input.NestedItem != nil {
		output.NestedItem = pointer.To(processObjectDefinition(*input.NestedItem))
	}

	return output
}


func processOperation(path string) (*ResourceOperations, error) {
	var operation Operation

	contents, err := loadJson(path)
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &operation); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", path, err)
	}

	resourceOperations := ResourceOperations{
		ContentType:                      operation.ContentType,
		ExpectedStatusCodes:              operation.ExpectedStatusCodes,
		LongRunning:                      operation.LongRunning,
		Method:                           operation.HTTPMethod,
		RequestObject:                    operation.RequestObject,
		ResourceIdName:                   operation.ResourceIdName,
		ResponseObject:                   operation.ResponseObject,
		FieldContainingPaginationDetails: operation.FieldContainingPaginationDetails,
		Options:                          nil,
		UriSuffix:                        operation.UriSuffix,
	}

	if operation.Options != nil {
		options := make(map[string]OperationOptions)
		for _, option := range *operation.Options {
			operationOptions := OperationOptions{
				HeaderName:       option.HeaderName,
				QueryStringName:  option.QueryString,
				Required:         option.Required,
			}
			if option.ObjectDefinition != nil {
				operationOptions.ObjectDefinition = processOptionObjectDefinition(option.ObjectDefinition)
			}
			options[option.Field] = operationOptions
		}
		resourceOperations.Options = pointer.To(options)
	}


	return &resourceOperations, nil
}

func processOptionObjectDefinition(input *DataApiOptionObjectDefinition) *OptionObjectDefinition {
	output := OptionObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          input.Type,
	}

	if input.NestedItem != nil {
		output.NestedItem = processOptionObjectDefinition(input.NestedItem)
	}

	return &output
}

func processResourceId(path string) (*ResourceIdDefinition, error) {
	var resourceId ResourceId

	contents, err := loadJson(path)
	if err != nil {
		return nil, err
	}

	if err := json.Unmarshal(*contents, &resourceId); err != nil {
		return nil, fmt.Errorf("unmarshaling %q: %+v", path, err)
	}

	segments := make([]ResourceIdSegment, 0)
	for _, segment := range resourceId.Segments {
		segments = append(segments, ResourceIdSegment{
			Name: segment.Name,
			Type: ResourceIdSegmentType(segment.Type),
			// TODO unable to find these attributes
			// ConstantReference: segment,
			// ExampleValue:      segment,
			// FixedValue:        nil,
		})
	}

	return &ResourceIdDefinition{
		CommonAlias: pointer.To(resourceId.CommonAlias),
		Id:          resourceId.Id,
		Segments: segments,
		// TODO unable to find this attribute
		// ConstantNames:
	}, nil
}