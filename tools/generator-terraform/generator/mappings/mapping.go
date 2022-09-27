package mappings

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// Two types of Mappings:
//  1. Resource ID Segments <-> SDK Path
//  2. Schema Model/Field <-> SDK Path
// TODO: support for Resource ID Mappings

type Mappings struct {
	apiResourcePackageName string
	mappings               resourcemanager.MappingDefinition
	resourceName           string

	sdkConstants    map[string]resourcemanager.ConstantDetails
	sdkModels       map[string]resourcemanager.ModelDetails
	sdkResourceIDs  map[string]resourcemanager.ResourceIdDefinition
	sdkResourceName string

	schemaModels    map[string]resourcemanager.TerraformSchemaModelDefinition
	schemaModelName string

	createMethods map[string]string
	readMethods   map[string]string
	updateMethods map[string]string

	createAndUpdateAreTheSame bool
}

func NewResourceMappings(terraformDefinition resourcemanager.TerraformResourceDetails, schema resourcemanager.ApiSchemaDetails) (*Mappings, error) {
	mappings := Mappings{
		apiResourcePackageName: strings.ToLower(terraformDefinition.Resource),
		mappings:               terraformDefinition.Mappings,
		resourceName:           terraformDefinition.ResourceName,
		schemaModels:           terraformDefinition.SchemaModels,
		schemaModelName:        terraformDefinition.SchemaModelName,
		sdkConstants:           schema.Constants,
		sdkModels:              schema.Models,
		sdkResourceIDs:         schema.ResourceIds,
		sdkResourceName:        terraformDefinition.Resource,
	}
	mappings.createAndUpdateAreTheSame = mappings.areCreateAndUpdateMappingsTheSame()
	if err := mappings.populateMappingFunctions(); err != nil {
		return nil, fmt.Errorf("populating mapping functions: %+v", err)
	}
	return &mappings, nil
}

func (m *Mappings) CodeForCreateMappings() string {
	return sortAndOutputMappingFunctions(m.createMethods)
}

func (m *Mappings) CodeForUpdateMappings() (*string, error) {
	// possible this resource doesn't support update
	if m.createAndUpdateAreTheSame || m.mappings.Update == nil {
		return nil, nil
	}

	out := sortAndOutputMappingFunctions(m.updateMethods)
	return &out, nil
}

func (m *Mappings) CodeForReadMappings() string {
	return sortAndOutputMappingFunctions(m.readMethods)
}

func (m *Mappings) areCreateAndUpdateMappingsTheSame() bool {
	if m.mappings.Update == nil || (len(m.mappings.Create) != len(*m.mappings.Update)) {
		return false
	}

	for _, v := range m.mappings.Create {
		other := findMappingBetween(*m.mappings.Update, v)
		if other == nil {
			return false
		}

		if !mappingsAreTheSame(v, other) {
			return false
		}
	}

	return false
}

func (m *Mappings) populateMappingFunctions() error {
	/*
		So:
			1. These will all be output as Instance methods, so we don't need to include the Type in the name
			2. These will all be grouped by the From/To type, so we need to group the items
			3. Note: we're going to need to add Manual Mapping and "nested items" mappings to the SDK/API
			4. The other option would be to output these as methods on the Type which would reduce the noise?
				to{SdkType} and from{SdkType} - needs to be that way around due to packages/vendoring
	*/
	m.createMethods = make(map[string]string)
	groupedCreateMappings := groupMappings(m.mappings.Create)
	for _, mapping := range groupedCreateMappings {
		methodCreateUpdateType := "Create"
		if m.createAndUpdateAreTheSame {
			methodCreateUpdateType = "CreateUpdate"
		}
		// TODO: these method names aren't ideal, can we make this shorter/instance methods?
		methodName := fmt.Sprintf("map%s%sTo%s", methodCreateUpdateType, mapping.fromTypeName, mapping.toTypeName)
		if _, hasExisting := m.createMethods[methodName]; hasExisting {
			return fmt.Errorf("duplicate Create mapping methods named %q", methodName)
		}
		lines, err := m.assignmentCreateUpdateLinesForMappings(mapping.mappings)
		if err != nil {
			return fmt.Errorf("building create assignment lines for mappings: %+v", err)
		}
		m.createMethods[methodName] = fmt.Sprintf(`func %[1]s(input %[2]s, out *%[3]s.%[4]s) error {
			%[5]s
			return nil
		}`, methodName, mapping.fromTypeName, m.apiResourcePackageName, mapping.toTypeName, *lines)
	}

	// Update methods should be (`map{ResourceName}Update{FromType}{FromField}To{ToType}{ToField}`)
	// however if Create and Update are the same, reuse Create (which'll be CreateUpdate)
	if !m.createAndUpdateAreTheSame && m.mappings.Update != nil {
		m.updateMethods = make(map[string]string)
		groupedUpdateMappings := groupMappings(*m.mappings.Update)
		for _, mapping := range groupedUpdateMappings {
			// TODO: these method names aren't ideal, can we make this shorter/instance methods?
			methodName := fmt.Sprintf("mapUpdate%sTo%s", mapping.fromTypeName, mapping.toTypeName)
			if _, hasExisting := m.updateMethods[methodName]; hasExisting {
				return fmt.Errorf("duplicate Update mapping methods named %q", methodName)
			}
			lines, err := m.assignmentCreateUpdateLinesForMappings(mapping.mappings)
			if err != nil {
				return fmt.Errorf("building update assignment lines for mappings: %+v", err)
			}
			m.updateMethods[methodName] = fmt.Sprintf(`func %[1]s(input %[2]s, out *%[3]s.%[4]s) error {
			%[5]s
			return nil
		}`, methodName, mapping.fromTypeName, m.apiResourcePackageName, mapping.toTypeName, *lines)
		}
	}

	// Read methods invert the method name/direction (`mapRead{ToType}{ToField}To{FromType}{FromField}`)
	m.readMethods = make(map[string]string)
	groupedReadMappings := groupMappings(m.mappings.Read)
	for _, mapping := range groupedReadMappings {
		// TODO: these method names aren't ideal, can we make this shorter/instance methods?
		methodName := fmt.Sprintf("mapRead%sTo%s", mapping.toTypeName, mapping.fromTypeName)
		if _, hasExisting := m.readMethods[methodName]; hasExisting {
			return fmt.Errorf("duplicate Read mapping methods named %q", methodName)
		}
		lines, err := m.assignmentReadLinesForMappings(mapping.mappings)
		if err != nil {
			return fmt.Errorf("building read assignment lines for mappings: %+v", err)
		}
		m.readMethods[methodName] = fmt.Sprintf(`func %[1]s(input %[3]s.%[4]s, out *%[2]s) error {
			%[5]s
			return nil
		}`, methodName, mapping.fromTypeName, m.apiResourcePackageName, mapping.toTypeName, *lines)
	}

	return nil
}
