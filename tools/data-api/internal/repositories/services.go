package repositories

import (
	"encoding/json"
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"os"
	"strings"

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

	terraformDetails, err := s.ProcessTerraformDefinitions(serviceName)
	if err != nil {
		return nil, err
	}

	serviceDetails := &ServiceDetails{
		Name: serviceName,
		// TODO RP name needs to be stored in the api definitions
		// ResourceProvider: fmt.Sprintf("Microsoft.%s", serviceName),
		ApiVersions: versionDefinitions,
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
	constants := make(map[string]ConstantDetails, 0)

	// TODO rename this var so we can import path to use path.Join
	path := fmt.Sprintf("%s/%s/%s/%s", s.directory, serviceName, version, resource)
	files, err := os.ReadDir(path)
	if err != nil {
		return nil, fmt.Errorf("retrieving definitions under %s: %+v", path, err)
	}

	for _, file := range files {
		if file.IsDir() {
			continue
		}

		definitionType, definitionName, err := getDefinitionInfo(file.Name())
		if err != nil {
			return nil, err
		}
		// we lower case these so that it's compatible with other OS e.g. Windows
		switch strings.ToLower(definitionType) {
		case "constant":
			var constant Constant

			// TODO use path.Join() so that this works on windows
			contents, err := loadJson(fmt.Sprintf("%s/%s", path, file.Name()))
			if err != nil {
				return nil, err
			}

			if err := json.Unmarshal(*contents, &constant); err != nil {
				return nil, fmt.Errorf("unmarshaling blah")
			}

			values := make(map[string]string, 0)

			for _, value := range constant.Values {
				values[value.Key] = value.Value
			}

			constants[definitionName] = ConstantDetails{
				Type:   ConstantType(constant.Type),
				Values: values,
			}
		case "model":
			// TODO
		case "operation":
			// TODO
		case "resourceid":
			// TODO
		}
	}

	resourceSchema.Constants = constants
	resourceDefinition.Schema = resourceSchema

	return &resourceDefinition, nil
}

func (s *ServicesRepositoryImpl) ProcessTerraformDefinitions(serviceName string) (*TerraformDetails, error) {
	terraformDetails := TerraformDetails{
		Resources:   make(map[string]TerraformResourceDetails),
		DataSources: make(map[string]TerraformDataSourceDetails),
	}
	path := fmt.Sprintf("%s/%s/Terraform", s.directory, serviceName)
	files, err := os.ReadDir(path)
	if err != nil {
		if strings.Contains(err.Error(), "no such file or directory") {
			return nil, nil
		}
		return nil, fmt.Errorf("retrieving definitions under %s: %+v", path, err)
	}

	for _, file := range files {
		if file.IsDir() {
			continue
		}

		definitionName, definitionType, err := getTerraformDefinitionInfo(file.Name())
		if err != nil {
			return nil, err
		}

		// todo do we have to do the same for DataSources?
		if _, ok := terraformDetails.Resources[definitionName]; !ok {
			terraformDetails.Resources[definitionName] = TerraformResourceDetails{
				ResourceName: definitionName,
			}
		}
		resource := terraformDetails.Resources[definitionName]

		// we lower case these so that it's compatible with other OS e.g. Windows
		switch strings.ToLower(definitionType) {
		case "resource":
			if resource, err = processTerraformDefinitionResource(path, file, resource); err != nil {
				return nil, err
			}

		case "resource-mappings":
			// todo figure out why this is in the model but it's not showing up in the api
			resource.Mappings, err = processTerraformDefinitionResourceMappings(path, file)
			if err != nil {
				return nil, err
			}

		case "resource-schema":
			resource.SchemaModels, err = processTerraformDefinitionResourceSchema(path, file)
			if err != nil {
				return nil, err
			}

		case "resource-tests":
			resource.Tests, err = processTerraformDefinitionResourceTests(path, file)
			if err != nil {
				return nil, err
			}
		}

		terraformDetails.Resources[definitionName] = resource
	}

	return &terraformDetails, nil
}

func processTerraformDefinitionResource(path string, file os.DirEntry, definition TerraformResourceDetails) (TerraformResourceDetails, error) {
	// TODO use path.Join() so that this works on windows
	contents, err := loadJson(fmt.Sprintf("%s/%s", path, file.Name()))
	if err != nil {
		return definition, err
	}

	var resourceDefinition models.TerraformResourceDefinition

	if err := json.Unmarshal(*contents, &resourceDefinition); err != nil {
		return definition, fmt.Errorf("unmarshaling Terraform Resource Definition")
	}

	definition.DisplayName = resourceDefinition.DisplayName
	definition.GenerateModel = resourceDefinition.GenerateModel
	definition.GenerateIdValidation = resourceDefinition.GenerateIdValidationFunction
	definition.GenerateSchema = resourceDefinition.GenerateSchema
	definition.ApiVersion = resourceDefinition.ApiVersion
	definition.Generate = resourceDefinition.Generate
	definition.ResourceIdName = resourceDefinition.ResourceIdName

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

	// todo the following are missing from the current information available
	// TerraformResourceDetails{
	//	Documentation:  ResourceDocumentationDefinition{},
	//	Resource:       "",
	// }

	return definition, nil
}

func processTerraformDefinitionResourceMappings(path string, file os.DirEntry) (MappingDefinition, error) {
	var mappings MappingDefinition
	// TODO use path.Join() so that this works on windows
	contents, err := loadJson(fmt.Sprintf("%s/%s", path, file.Name()))
	if err != nil {
		return mappings, err
	}

	var resourceMapping models.TerraformMappingDefinition

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
	}

	return mappings, nil
}

func processTerraformDefinitionResourceSchema(path string, file os.DirEntry) (map[string]TerraformSchemaModelDefinition, error) {
	schemaModelDefinition := make(map[string]TerraformSchemaModelDefinition)
	// TODO use path.Join() so that this works on windows
	contents, err := loadJson(fmt.Sprintf("%s/%s", path, file.Name()))
	if err != nil {
		return schemaModelDefinition, err
	}

	var schemaModel models.TerraformSchemaModel

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

func processTerraformDefinitionResourceTests(path string, file os.DirEntry) (TerraformResourceTestsDefinition, error) {
	// TODO use path.Join() so that this works on windows
	contents, err := loadJson(fmt.Sprintf("%s/%s", path, file.Name()))
	if err != nil {
		return TerraformResourceTestsDefinition{}, err
	}

	var testConfig models.TerraformResourceTestConfig
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

func terraformSchemaFieldObjectDefinitionFromField(input models.TerraformSchemaObjectDefinition) TerraformSchemaFieldObjectDefinition {
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
