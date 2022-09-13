package schema

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type expected struct {
	FieldName           string
	HclName             string
	Optional            bool
	Required            bool
	Computed            bool
	ForceNew            bool
	FieldType           resourcemanager.TerraformSchemaFieldType
	ReferenceName       *string
	NestedReferenceName *string
	Validation          *expectedValidation
}

type expectedValidation struct {
	Type               resourcemanager.TerraformSchemaValidationType
	PossibleValueCount int
}

type resourceUnderTest struct {
	Name         string
	CurrentModel string
}

// checkFieldName is a convenience specific check for the Name field in a Top Level mode where
// there are established conditions for it.
func (r resourceUnderTest) checkFieldName(t *testing.T, input resourcemanager.TerraformSchemaModelDefinition) {
	name, ok := input.Fields["Name"]
	if !ok {
		t.Errorf("(%s) expected there to be a field 'Name' but didn't get one", r.Name)
	}
	if name.HclName != "name" {
		t.Errorf("(%s) expected the HclName for field 'Name' to be 'name' but got %q", r.Name, name.HclName)
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Errorf("(%s) expected the field 'Name' to have the type `string` but got %q", r.Name, string(name.ObjectDefinition.Type))
	}
	// note: this differs from the model above, since this is implicitly required as a top level field
	// even if it's defined as optional in the schema
	if !name.Required {
		t.Errorf("(%s) expected the field 'Name' to be Required but it wasn't", r.Name)
	}
	if !name.ForceNew {
		t.Errorf("(%s) expected the field 'Name' to be ForceNew but it wasn't", r.Name)
	}
	// TODO: source WriteOnly from the mappings
	//if name.Optional || name.Computed || name.WriteOnly {
	//	t.Errorf("(%s) expected the field 'Name' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", r.Name name.Optional, name.Computed, name.WriteOnly)
	//}
	if name.Optional || name.Computed {
		t.Errorf("(%s) expected the field 'Name' to be !Optional, !Computed but got %t / %t", r.Name, name.Optional, name.Computed)
	}
}

// checkFieldLocation is a convenience specific check for the Location field in a Top Level mode
// where there are established conditions for it.
func (r resourceUnderTest) checkFieldLocation(t *testing.T, input resourcemanager.TerraformSchemaModelDefinition) {
	location, ok := input.Fields["Location"]
	if !ok {
		t.Errorf("(%s) expected there to be a field 'Location' but didn't get one", r.Name)
	}
	if location.HclName != "location" {
		t.Errorf("(%s) expected the HclName for field 'Location' to be 'location' but got %q", r.Name, location.HclName)
	}
	if location.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeLocation {
		t.Errorf("(%s) expected the field 'Location' to have the type `location` but got %q", r.Name, string(location.ObjectDefinition.Type))
	}
	// note: this differs from the model above, since this is implicitly required as a top level field
	// even if it's defined as optional in the schema
	if !location.Required {
		t.Errorf("(%s) expected the field 'Location' to be Required but it wasn't", r.Name)
	}
	if !location.ForceNew {
		t.Errorf("(%s) expected the field 'Location' to be ForceNew but it wasn't", r.Name)
	}
	// TODO: source WriteOnly from the mappings?
	//if location.Optional || location.Computed || location.WriteOnly {
	//	t.Errorf("(%s) expected the field 'Location' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", r.Name, location.Optional, location.Computed, location.WriteOnly)
	//}
	if location.Optional || location.Computed {
		t.Errorf("(%s) expected the field 'Location' to be !Optional, !Computed but got %t / %t", r.Name, location.Optional, location.Computed)
	}
}

// checkFieldTags is a convenience specific check for the Tags field in a Top Level mode where
// there are established conditions for it.
func (r resourceUnderTest) checkFieldTags(t *testing.T, input resourcemanager.TerraformSchemaModelDefinition) {
	tags, ok := input.Fields["Tags"]
	if !ok {
		t.Errorf("(%s) expected there to be a field 'Tags' but didn't get one", r.Name)
	}
	if tags.HclName != "tags" {
		t.Errorf("(%s) expected the HclName for field 'Tags' to be 'tags' but got %q", r.Name, tags.HclName)
	}
	if tags.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeTags {
		t.Errorf("(%s) expected the field 'Tags' to have the type `tags` but got %q", r.Name, string(tags.ObjectDefinition.Type))
	}
	if !tags.Optional {
		t.Errorf("(%s) expected the field 'Tags' to be Optional but it wasn't", r.Name)
	}
	// TODO: source WriteOnly from the mappings?
	//if tags.Required || tags.Computed || tags.ForceNew || tags.WriteOnly {
	//	t.Errorf("(%s) expected the field 'Tags' to be !Required, !Computed, !ForceNew and !WriteOnly but got %t / %t / %t / %t", r.Name, tags.Required, tags.Computed, tags.ForceNew, tags.WriteOnly)
	//}
	if tags.Required || tags.Computed || tags.ForceNew {
		t.Errorf("(%s) expected the field 'Tags' to be !Required, !Computed, !ForceNew but got %t / %t / %t", r.Name, tags.Required, tags.Computed, tags.ForceNew)
	}
}

// TODO - checkFieldTagsForceNew et al?

func (r resourceUnderTest) checkField(t *testing.T, input resourcemanager.TerraformSchemaModelDefinition, exp expected) {
	field, ok := input.Fields[exp.FieldName]
	if !ok {
		t.Errorf("(%s) expected there to be a field %q (model: %q) but didn't get one", r.Name, exp.FieldName, r.CurrentModel)
	}
	if field.HclName != exp.HclName {
		t.Errorf("(%s) expected the HclName for field %q (model: %q) to be %q but got %q", r.Name, exp.FieldName, r.CurrentModel, exp.HclName, field.HclName)
	}
	if field.ObjectDefinition.Type != exp.FieldType {
		t.Errorf("(%s) expected the field %q (model: %q) to have the type %q but got %q", r.Name, exp.FieldName, r.CurrentModel, string(exp.FieldType), string(field.ObjectDefinition.Type))
	}
	if field.Required != exp.Required {
		t.Errorf("(%s) expected the field %q (model: %q) to be Required = %t but got Required = %t", r.Name, exp.FieldName, r.CurrentModel, exp.Required, field.Required)
	}
	if field.Optional != exp.Optional {
		t.Errorf("(%s) expected the field %q (model: %q) to be Optional = %t but got Optional = %t", r.Name, exp.FieldName, r.CurrentModel, exp.Optional, field.Optional)
	}
	if field.ForceNew != exp.ForceNew {
		t.Errorf("(%s) expected the field %q (model: %q) to be ForceNew = %t but got ForceNew = %t", r.Name, exp.FieldName, r.CurrentModel, exp.ForceNew, field.ForceNew)
	}
	// TODO: source WriteOnly from the mappings
	//if field.Optional || field.Computed || field.WriteOnly {
	//	t.Errorf("(%s) expected the field 'Name' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", r.Name, r.CurrentModel, field.Optional, field.Computed, field.WriteOnly)
	//}
	if field.Computed != exp.Computed {
		t.Errorf("(%s) expected the field %q (model: %q) to be ForceNew = %t but got ForceNew = %t", r.Name, exp.FieldName, r.CurrentModel, exp.Computed, field.Computed)
	}

	if exp.ReferenceName == nil && field.ObjectDefinition.ReferenceName != nil {
		t.Errorf("(%s) expected the field %q (model: %q) to have no Refence, but got %q", r.Name, exp.FieldName, r.CurrentModel, *field.ObjectDefinition.ReferenceName)
	}
	if exp.ReferenceName != nil && field.ObjectDefinition.ReferenceName == nil {
		t.Errorf("(%s) expected the field %q (model: %q) to have a Refence to %q, but got nil", r.Name, exp.FieldName, r.CurrentModel, *exp.ReferenceName)
	}
	if exp.ReferenceName != nil && field.ObjectDefinition.ReferenceName != nil {
		if *exp.ReferenceName != *field.ObjectDefinition.ReferenceName {
			t.Errorf("(%s) expected the field %q (model: %q) to have a Refence to %q, but got %q", r.Name, exp.FieldName, r.CurrentModel, *exp.ReferenceName, *field.ObjectDefinition.ReferenceName)
		}
	}
	if exp.FieldType != field.ObjectDefinition.Type {
		t.Errorf("(%s) expected the field %q (model: %q) to be of type %q, but got %q", r.Name, exp.FieldName, r.CurrentModel, string(exp.FieldType), string(field.ObjectDefinition.Type))
	}

	if exp.NestedReferenceName == nil && (field.ObjectDefinition.NestedObject != nil && field.ObjectDefinition.NestedObject.ReferenceName != nil) {
		t.Errorf("(%s) expected the field %q (model: %q) to have no Nested Refence, but got %q", r.Name, exp.FieldName, r.CurrentModel, *field.ObjectDefinition.ReferenceName)
	}
	if exp.NestedReferenceName != nil && (field.ObjectDefinition.NestedObject == nil || field.ObjectDefinition.NestedObject.ReferenceName == nil) {
		t.Errorf("(%s) expected the field %q (model: %q) to have a Nested Refence to %q, but got nil", r.Name, exp.FieldName, r.CurrentModel, *exp.NestedReferenceName)
	}
	if exp.NestedReferenceName != nil && field.ObjectDefinition.NestedObject != nil && field.ObjectDefinition.NestedObject.ReferenceName != nil {
		if *exp.NestedReferenceName != *field.ObjectDefinition.NestedObject.ReferenceName {
			t.Errorf("(%s) expected the field %q (model: %q) to have a Nested Refence to %q, but got %q", r.Name, exp.FieldName, r.CurrentModel, *exp.NestedReferenceName, *field.ObjectDefinition.NestedObject.ReferenceName)
		}
	}

	if exp.Validation == nil && field.Validation != nil {
		t.Errorf("(%s) expected the field %q (model: %q) to have no Validation, but it did", r.Name, exp.FieldName, r.CurrentModel)
	}
	if exp.Validation != nil && field.Validation == nil {
		t.Errorf("(%s) expected the field %q (model: %q) to have Validation, but it didn't", r.Name, exp.FieldName, r.CurrentModel)
	}
	if exp.Validation != nil && field.Validation != nil {
		if exp.Validation.Type != field.Validation.Type {
			t.Errorf("(%s) expected the field %q (model: %q) to have Validation Type of %q, but got %q", r.Name, exp.FieldName, r.CurrentModel, string(exp.Validation.Type), string(field.Validation.Type))
		}
		if exp.Validation.PossibleValueCount != 0 && field.Validation.PossibleValues != nil {
			possibleValues := *field.Validation.PossibleValues
			if exp.Validation.PossibleValueCount != len(possibleValues.Values) {
				t.Errorf("(%s) expected the field %q (model: %q) to have %d Possible Values for Validation but got %d", r.Name, exp.FieldName, r.CurrentModel, exp.Validation.PossibleValueCount, len(possibleValues.Values))
			}
		}
	}
}
