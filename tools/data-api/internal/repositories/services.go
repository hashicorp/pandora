package repositories

import (
	"fmt"
	"net/http"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
)

type ServicesRepository interface {
	GetByName(serviceName string, serviceType ServiceType) (*ServiceDetails, error)

	GetAll(serviceType ServiceType) (*[]ServiceDetails, error)
}

var _ ServicesRepository = &ServicesRepositoryImpl{}

type ServicesRepositoryImpl struct {
	// TODO:
	// directory string
}

func (s *ServicesRepositoryImpl) GetByName(serviceName string, serviceType ServiceType) (*ServiceDetails, error) {
	allServices, err := s.GetAll(serviceType)
	if err != nil {
		return nil, fmt.Errorf("parsing the list of services: %+v", err)
	}
	for _, service := range *allServices {
		if service.Name == serviceName {
			return &service, nil
		}
	}

	return nil, nil
}

func (s *ServicesRepositoryImpl) GetAll(serviceType ServiceType) (*[]ServiceDetails, error) {
	return &[]ServiceDetails{
		{
			Name:                 "Compute",
			ResourceProvider:     "Microsoft.Compute",
			TerraformPackageName: pointer.To("compute"),
			ApiVersions: map[string]*ServiceApiVersionDetails{
				"2020-01-01": {
					Name:     "2020-01-01",
					Generate: true,
					Resources: map[string]*ServiceApiVersionResourceDetails{
						"VirtualMachines": {
							Operations: map[string]ResourceOperations{
								"Get": {
									ContentType: "application/json",
									ExpectedStatusCodes: []int{
										http.StatusOK,
									},
									LongRunning:    false,
									Method:         http.MethodGet,
									RequestObject:  nil,
									ResourceIdName: nil,
									ResponseObject: &ObjectDefinition{
										NestedItem: &ObjectDefinition{
											ReferenceName: pointer.To("Panda"),
											Type:          ReferenceObjectDefinitionType,
										},
										ReferenceName: pointer.To("Computa"),
										Type:          ReferenceObjectDefinitionType,
									},
									FieldContainingPaginationDetails: nil,
									Options:                          nil,
									UriSuffix:                        nil,
								},
							},
							Schema: ResourceSchema{
								Constants: map[string]ConstantDetails{},
								Models: map[string]ModelDetails{
									"Computa": {
										Fields: map[string]FieldDetails{
											"Name": {
												ObjectDefinition: ObjectDefinition{
													Type: ReferenceObjectDefinitionType,
												},
												Required: true,
											},
										},
										TypeHintIn:    nil,
										TypeHintValue: nil,
									},
								},
								ResourceIds: map[string]ResourceIdDefinition{},
							},
						},
					},
					Source: HandWrittenApiDefinitionsSource,
				},
			},
			TerraformDetails: TerraformDetails{
				Resources: map[string]TerraformResourceDetails{
					"virtual_machine": {
						ApiVersion: "2020-01-01",
						CreateMethod: MethodDefinition{
							Generate:         true,
							MethodName:       "VirtualMachineCreateOrUpdate",
							TimeoutInMinutes: 30,
						},
						DeleteMethod: MethodDefinition{
							Generate:         true,
							MethodName:       "VirtualMachineDelete",
							TimeoutInMinutes: 30,
						},
						DisplayName: "Virtual Machine",
						Documentation: ResourceDocumentationDefinition{
							Description:     "Manages a Virtual Machine",
							ExampleUsageHcl: "resource \"azurerm_virtual_machine\" \"example\" {}",
						},
						Generate:             true,
						GenerateModel:        true,
						GenerateIdValidation: true,
						GenerateSchema:       true,
						Mappings: MappingDefinition{
							Fields: []FieldMappingDefinition{
								{
									Type: "DirectAssignment",
									DirectAssignment: pointer.To(FieldMappingDirectAssignmentDefinition{
										SchemaModelName: "model",
										SchemaFieldPath: "name",
										SdkModelName:    "model",
										SdkFieldPath:    "name",
									},
									),
								},
								{
									Type: "DirectAssignment",
									DirectAssignment: pointer.To(FieldMappingDirectAssignmentDefinition{
										SchemaModelName: "model",
										SchemaFieldPath: "resource_group",
										SdkModelName:    "model",
										SdkFieldPath:    "resource_group",
									},
									),
								},
							},
							ModelToModels: []ModelToModelMappingDefinition{
								{
									SchemaModelName: "VirtualMachineSchema",
									SdkModelName:    "VirtualMachineProperties",
								},
							},
							ResourceId: []ResourceIdMappingDefinition{
								{
									SchemaFieldName:    "VirtualMachineId",
									SegmentName:        "virtualMachineName",
									ParsedFromParentID: true,
								},
								{
									SchemaFieldName:    "ResourceGroupName",
									SegmentName:        "resourceGroupName",
									ParsedFromParentID: false,
								},
							},
						},
						ReadMethod: MethodDefinition{
							Generate:         true,
							MethodName:       "VirtualMachineGet",
							TimeoutInMinutes: 5,
						},
						Resource:        "VirtualMachine",
						ResourceIdName:  "VirtualMachineId",
						ResourceName:    "VirtualMachine",
						SchemaModelName: "VirtualMachineSchema",
						SchemaModels: map[string]TerraformSchemaModelDefinition{
							"VirtualMachineSchema": {
								Fields: map[string]TerraformSchemaFieldDefinition{
									"VirtualMachineId": {
										ObjectDefinition: TerraformSchemaFieldObjectDefinition{
											NestedObject:  nil,
											ReferenceName: nil,
											Type:          StringTerraformSchemaFieldType,
										},
										Computed: false,
										ForceNew: true,
										HclName:  "virtual_machine_id",
										Optional: false,
										Required: true,
										Documentation: TerraformSchemaDocumentationDefinition{
											Markdown: "blah",
										},
										Validation: nil,
									},
									"Name": {
										ObjectDefinition: TerraformSchemaFieldObjectDefinition{
											NestedObject:  nil,
											ReferenceName: nil,
											Type:          StringTerraformSchemaFieldType,
										},
										Computed: false,
										ForceNew: true,
										HclName:  "name",
										Optional: false,
										Required: true,
										Documentation: TerraformSchemaDocumentationDefinition{
											Markdown: "blah",
										},
										Validation: nil,
									},
								},
							},
						},
						Tests: TerraformResourceTestsDefinition{
							BasicConfiguration:          "basictest",
							RequiresImportConfiguration: "importtest",
							CompleteConfiguration:       nil,
							Generate:                    false,
							OtherTests:                  nil,
							TemplateConfiguration:       nil,
						},
						UpdateMethod: pointer.To(MethodDefinition{
							Generate:         true,
							MethodName:       "VirtualMachineCreateOrUpdate",
							TimeoutInMinutes: 30,
						}),
					},
				},
			},

			Generate: true,
		},
	}, nil
}
