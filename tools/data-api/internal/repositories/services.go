package repositories

import (
	"encoding/json"
	"fmt"
	"os"
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

	// graphV1 is a map of service name to string
	graphV1 *map[string]string

	// graphV2 is a map of service name to string
	graphV2 *map[string]string

	// resourceManager is map of service name to ServiceDetails, the ServiceDetails contain all the
	// Service, Version and Resource definitions loaded and unmarshalled from the JSON API definitions
	resourceManager *map[string]ServiceDetails

	// serviceNames is a list of services which the server will load
	serviceNames *[]string
}

func NewServicesRepository(directory string, serviceType ServiceType, serviceNames *[]string) ServicesRepository {
	return &ServicesRepositoryImpl{
		directory:    fmt.Sprintf("%s%s", directory, serviceType),
		serviceNames: serviceNames,
	}
}

func (s *ServicesRepositoryImpl) ClearCache() error {
	// TODO This gets automatically run if a file has changed and when serve-watch is used
	// TODO this finds the files needed and loads it
	// TODO file watching
	s.resourceManager = nil

	return nil
}

func (s *ServicesRepositoryImpl) GetAll(serviceType ServiceType) (*[]ServiceDetails, error) {
	// GetAll calls GetByName for all the service names passed to the serve command, or for all the services available in the api definitions directory
	serviceDetails := make([]ServiceDetails, 0)

	if s.resourceManager == nil {
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

	for _, details := range *s.resourceManager {
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
		return nil, fmt.Errorf("service %s does not exist: %+v", serviceName, err)
	}

	serviceDetails, err := s.ProcessServiceDefinitions(serviceName)
	if err != nil {
		return nil, fmt.Errorf("processing service definition for %s: %+v", serviceName, err)
	}

	resourceManager := make(map[string]ServiceDetails, 0)

	if s.resourceManager != nil {
		resourceManager = *s.resourceManager
	}

	resourceManager[serviceName] = *serviceDetails
	s.resourceManager = &resourceManager

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
		Name:             serviceName,
		ResourceProvider: fmt.Sprintf("Microsoft.%s", serviceName),
		ApiVersions:      versionDefinitions,
	}, nil
}

func (s *ServicesRepositoryImpl) ProcessVersionDefinitions(serviceName string, version string, resources []string) (*ServiceApiVersionDetails, error) {
	versionDefinition := ServiceApiVersionDetails{
		Name:     version,
		Generate: true,
		Source:   ResourceManagerRestApiSpecsApiDefinitionsSource,
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

	path := fmt.Sprintf("%s/%s/%s/%s", s.directory, serviceName, version, resource)
	files, err := os.ReadDir(path)
	if err != nil {
		return nil, fmt.Errorf("retrieving definitions under %s: %+v", path, err)
	}

	for _, file := range files {
		if !file.IsDir() {
			definitionType, definitionName := getDefinitionInfo(file.Name())
			switch definitionType {
			case "Constant":
				constant := Constant{}

				contents, err := loadJson(fmt.Sprintf("%s/%s", path, file.Name()))
				if err != nil {
					return nil, err
				}
				json.Unmarshal(*contents, &constant)

				values := make(map[string]string, 0)

				for _, value := range constant.Values {
					values[value.Key] = value.Value
				}

				constants[definitionName] = ConstantDetails{
					CaseInsensitive: false,
					Type:            ConstantType(constant.Type),
					Values:          values,
				}
			case "Model":
				// TODO
			case "Operation":
				// TODO
			case "ResourceId":
				// TODO
			}
		}
	}
	resourceSchema.Constants = constants
	resourceDefinition.Schema = resourceSchema

	return &resourceDefinition, nil
}
