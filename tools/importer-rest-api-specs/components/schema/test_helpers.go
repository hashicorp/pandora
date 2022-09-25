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
	NestedReferenceType resourcemanager.TerraformSchemaFieldType
	Validation          *expectedValidation
}

type expectedValidation struct {
	Type               resourcemanager.TerraformSchemaValidationType
	PossibleValueCount int
}

type resourceUnderTest struct {
	Name           string
	CurrentModel   string
	IdentityConfig *IdentityConfig
	LocationConfig *FieldConfig
	NameConfig     *FieldConfig
	TagsConfig     *FieldConfig
}

type FieldConfig struct {
	Required  bool
	Optional  bool
	ForceNew  bool
	Computed  bool
	WriteOnly bool
}

type IdentityConfig struct {
	*FieldConfig
	IdentityType resourcemanager.TerraformSchemaFieldType
}

// checkFieldName is a convenience specific check for the Name field in a Top Level mode where
// there are established conditions for it. Defaults to expecting Required: true, ForceNew: true.
// Set resourceUnderTest.NameConfig to override.
func (r resourceUnderTest) checkFieldName(t *testing.T, input resourcemanager.TerraformSchemaModelDefinition) {
	if r.NameConfig == nil {
		r.NameConfig = &FieldConfig{
			Required: true,
			ForceNew: true,
		}
	}
	name, ok := input.Fields["Name"]
	if !ok {
		t.Errorf("(%s) expected there to be a field 'Name' but didn't get one", r.Name)
	} else {
		if name.HclName != "name" {
			t.Errorf("(%s) expected the HclName for field 'Name' to be 'name' but got %q", r.Name, name.HclName)
		}
		if r.Name == "Resource Group" {
			// the `name` field for a Resource Group is special-cased
			if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeResourceGroup {
				t.Errorf("(%s) expected the field 'Name' to have the type `ResourceGroup` but got %q", r.Name, string(name.ObjectDefinition.Type))
			}
		} else {
			if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
				t.Errorf("(%s) expected the field 'Name' to have the type `string` but got %q", r.Name, string(name.ObjectDefinition.Type))
			}
		}
		// note: this differs from the model above, since this is implicitly required as a top level field
		// even if it's defined as optional in the schema
		if name.Computed != r.NameConfig.Computed {
			t.Errorf("(%s) expected the field 'Name' to be Computed: %t but got Computed: %t", r.Name, r.LocationConfig.Computed, name.Computed)
		}
		if name.ForceNew != r.NameConfig.ForceNew {
			t.Errorf("(%s) expected the field 'Name' to be ForceNew: %t but got ForceNew: %t", r.Name, r.LocationConfig.ForceNew, name.ForceNew)
		}
		if name.Optional != r.NameConfig.Optional {
			t.Errorf("(%s) expected the field 'Name' to be Optional: %t but got Optional: %t", r.Name, r.LocationConfig.Optional, name.Optional)
		}
		if name.Required != r.NameConfig.Required {
			t.Errorf("(%s) expected the field 'Name' to be Required: %t but got Required: %t", r.Name, r.LocationConfig.Required, name.Required)
		}
		// TODO: source WriteOnly from the mappings
		// if name.WriteOnly != r.NameConfig.Required {
		//	t.Errorf("(%s) expected the field 'Name' to be Required: %t but got Required: %t", r.Name, r.LocationConfig.Required, name.Required)
		// }
	}
}

// checkFieldLocation is a convenience specific check for the Location field in a Top Level mode
// where there are established conditions for it. Defaults to expecting Required: true, ForceNew: true.
// Set resourceUnderTest.LocationConfig to override.
func (r resourceUnderTest) checkFieldLocation(t *testing.T, input resourcemanager.TerraformSchemaModelDefinition) {
	if r.LocationConfig == nil {
		r.LocationConfig = &FieldConfig{
			Required: true,
			ForceNew: true,
		}
	}
	location, ok := input.Fields["Location"]
	if !ok {
		t.Errorf("(%s) expected there to be a field 'Location' but didn't get one", r.Name)
	} else {
		if location.HclName != "location" {
			t.Errorf("(%s) expected the HclName for field 'Location' to be 'location' but got %q", r.Name, location.HclName)
		}
		if location.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeLocation {
			t.Errorf("(%s) expected the field 'Location' to have the type `location` but got %q", r.Name, string(location.ObjectDefinition.Type))
		}
		// note: this differs from the model above, since this is implicitly required as a top level field
		// even if it's defined as optional in the schema
		if location.Computed != r.LocationConfig.Computed {
			t.Errorf("(%s) expected the field 'Location' to be Computed: %t but got Computed: %t", r.Name, r.LocationConfig.Computed, location.Computed)
		}

		if location.Optional != r.LocationConfig.Optional {
			t.Errorf("(%s) expected the field 'Location' to be Optional: %t but got Optional: %t", r.Name, r.LocationConfig.Optional, location.Optional)
		}

		if location.Required != r.LocationConfig.Required {
			t.Errorf("(%s) expected the field 'Location' to be Required: %t but got Required: %t", r.Name, r.LocationConfig.Required, location.Required)
		}

		if location.ForceNew != r.LocationConfig.ForceNew {
			t.Errorf("(%s) expected the field 'Location' to be ForceNew: %t but got ForceNew: %t", r.Name, r.LocationConfig.ForceNew, location.ForceNew)
		}

		// TODO: source WriteOnly from the mappings?
		// if location.WriteOnly != r.LocationConfig.WriteOnly {
		//	t.Errorf("(%s) expected the field 'Location' to be WriteOnly: %t but got WriteOnly: %t", r.Name, r.LocationConfig.WriteOnly, location.WriteOnly)
		// }
	}
}

// checkFieldTags is a convenience specific check for the Tags field in a Top Level mode where
// there are established conditions for it. Defaults to expecting Optional: true.
// Set resourceUnderTest.TagsConfig to override.
func (r resourceUnderTest) checkFieldTags(t *testing.T, input resourcemanager.TerraformSchemaModelDefinition) {
	if r.TagsConfig == nil {
		r.TagsConfig = &FieldConfig{
			Optional: true,
		}
	}
	tags, ok := input.Fields["Tags"]
	if !ok {
		t.Errorf("(%s) expected there to be a field 'Tags' but didn't get one", r.Name)
	} else {
		if tags.HclName != "tags" {
			t.Errorf("(%s) expected the HclName for field 'Tags' to be 'tags' but got %q", r.Name, tags.HclName)
		}
		if tags.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeTags {
			t.Errorf("(%s) expected the field 'Tags' to have the type `tags` but got %q", r.Name, string(tags.ObjectDefinition.Type))
		}
		if tags.Computed != r.TagsConfig.Computed {
			t.Errorf("(%s) expected the field 'Tags' to be Computed: %t but got Computed: %t", r.Name, r.TagsConfig.Computed, tags.Computed)
		}

		if tags.ForceNew != r.TagsConfig.ForceNew {
			t.Errorf("(%s) expected the field 'Tags' to be ForceNew: %t but got ForceNew: %t", r.Name, r.TagsConfig.ForceNew, tags.ForceNew)
		}

		if tags.Optional != r.TagsConfig.Optional {
			t.Errorf("(%s) expected the field 'Tags' to be Optional: %t but got Optional: %t", r.Name, r.TagsConfig.Optional, tags.Optional)
		}

		if tags.Required != r.TagsConfig.Required {
			t.Errorf("(%s) expected the field 'Tags' to be Required: %t but got Required: %t", r.Name, r.TagsConfig.Required, tags.Required)
		}

		// TODO: source WriteOnly from the mappings?
		// if tags.WriteOnly != r.TagsConfig.WriteOnly{
		//	t.Errorf("(%s) expected the field 'Tags' to be WriteOnly: %t but got WriteOnly: %t", r.Name, r.TagsConfig.WriteOnly, tags.WriteOnly)
		// }
	}
}

// checkFieldIdentity checks the top level field Identity. Due to the highly variable nature of this property setting a configuration is *required*
// in resourceUnderTest.IdentityConfig for the type of Identity as a minimum. If no Schema expectations are set in
// *resourceUnderTest.IdentityConfig.FieldConfig, then the following defaults are used: Optional: true, Required: false, Computed: false,
// ForceNew: false, WriteOnly: false
func (r resourceUnderTest) checkFieldIdentity(t *testing.T, input resourcemanager.TerraformSchemaModelDefinition) {
	if r.IdentityConfig == nil {
		t.Fatalf("expected identity config missing to check identity field in %q. Please set in resourceUnderTest.IdentityConfig", r.Name)
	}
	if r.IdentityConfig.FieldConfig == nil {
		r.IdentityConfig.FieldConfig = &FieldConfig{
			Optional: true,
		}
	}
	identity, ok := input.Fields["Identity"]
	if !ok {
		t.Errorf("(%s) expected there to be a field 'Identity' but didn't get one", r.Name)
	} else {
		if identity.HclName != "identity" {
			t.Errorf("(%s) expected the HclName for field 'identity' to be 'identity' but got %q", r.Name, identity.HclName)
		}
		if identity.ObjectDefinition.Type != r.IdentityConfig.IdentityType {
			t.Errorf("(%s) expected the field 'Identity' to have the type %q but got %q", r.Name, r.IdentityConfig.IdentityType, string(identity.ObjectDefinition.Type))
		}
		if identity.Computed != r.IdentityConfig.Computed {
			t.Errorf("(%s) expected the field 'Identity' to be Computed: %t but got Computed: %t", r.Name, r.IdentityConfig.Computed, identity.Computed)
		}
		if identity.ForceNew != r.IdentityConfig.ForceNew {
			t.Errorf("(%s) expected the field 'Identity' to be ForceNew: %t but got ForceNew: %t", r.Name, r.IdentityConfig.ForceNew, identity.ForceNew)
		}
		if identity.Optional != r.IdentityConfig.Optional {
			t.Errorf("(%s) expected the field 'Identity' to be Optional: %t but got Optional: %t", r.Name, r.IdentityConfig.Optional, identity.Optional)
		}
		if identity.Required != r.IdentityConfig.Required {
			t.Errorf("(%s) expected the field 'Identity' to be Required: %t but got Required: %t", r.Name, r.IdentityConfig.Required, identity.Required)
		}

		// TODO: source WriteOnly from the mappings?
		//if identity.WriteOnly != r.IdentityConfig.WriteOnly {
		//	t.Errorf("(%s) expected the field 'Identity' to be WriteOnly: %t but got WriteOnly: %t", r.Name, r.IdentityConfig.WriteOnly, identity.WriteOnly)
		//}

	}
}

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

	if field.Computed != exp.Computed {
		t.Errorf("(%s) expected the field %q (model: %q) to be ForceNew = %t but got ForceNew = %t", r.Name, exp.FieldName, r.CurrentModel, exp.Computed, field.Computed)
	}

	if field.Optional != exp.Optional {
		t.Errorf("(%s) expected the field %q (model: %q) to be Optional = %t but got Optional = %t", r.Name, exp.FieldName, r.CurrentModel, exp.Optional, field.Optional)
	}

	if field.Required != exp.Required {
		t.Errorf("(%s) expected the field %q (model: %q) to be Required = %t but got Required = %t", r.Name, exp.FieldName, r.CurrentModel, exp.Required, field.Required)
	}
	if field.ForceNew != exp.ForceNew {
		t.Errorf("(%s) expected the field %q (model: %q) to be ForceNew = %t but got ForceNew = %t", r.Name, exp.FieldName, r.CurrentModel, exp.ForceNew, field.ForceNew)
	}
	// TODO: source WriteOnly from the mappings
	// if field.WriteOnly != exp.WriteOnly {
	//	t.Errorf("(%s) expected the field %q (model: %q) to be WriteOnly = %t but got WriteOnly = %t", r.Name, exp.FieldName, r.CurrentModel, exp.WriteOnly, field.WriteOnly)
	// }

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
		t.Errorf("(%s) expected the field %q (model: %q) to have no Nested Refence, but got %q", r.Name, exp.FieldName, r.CurrentModel, *field.ObjectDefinition.NestedObject.ReferenceName)
	}
	if exp.NestedReferenceName != nil && (field.ObjectDefinition.NestedObject == nil || field.ObjectDefinition.NestedObject.ReferenceName == nil) {
		t.Errorf("(%s) expected the field %q (model: %q) to have a Nested Refence to %q, but got nil", r.Name, exp.FieldName, r.CurrentModel, *exp.NestedReferenceName)
	}
	if exp.NestedReferenceName != nil && field.ObjectDefinition.NestedObject != nil && field.ObjectDefinition.NestedObject.ReferenceName != nil {
		if *exp.NestedReferenceName != *field.ObjectDefinition.NestedObject.ReferenceName {
			t.Errorf("(%s) expected the field %q (model: %q) to have a Nested Refence to %q, but got %q", r.Name, exp.FieldName, r.CurrentModel, *exp.NestedReferenceName, *field.ObjectDefinition.NestedObject.ReferenceName)
		}
	}

	if exp.NestedReferenceType == "" && (field.ObjectDefinition.NestedObject != nil && field.ObjectDefinition.NestedObject.Type != "") {
		t.Errorf("(%s) expected the field %q (model: %q) to have no Nested Refence Type, but got %q", r.Name, exp.FieldName, r.CurrentModel, string(field.ObjectDefinition.NestedObject.Type))
	}
	if exp.NestedReferenceType != "" && (field.ObjectDefinition.NestedObject == nil || field.ObjectDefinition.NestedObject.Type == "") {
		t.Errorf("(%s) expected the field %q (model: %q) to have a Nested Refence Type of %q, but it didn't", r.Name, exp.FieldName, r.CurrentModel, exp.NestedReferenceType)
	}
	if exp.NestedReferenceType != "" && field.ObjectDefinition.NestedObject != nil && field.ObjectDefinition.NestedObject.Type != "" {
		if exp.NestedReferenceType != field.ObjectDefinition.NestedObject.Type {
			t.Errorf("(%s) expected the field %q (model: %q) to have a Nested Refence Type of %q, but got %q", r.Name, exp.FieldName, r.CurrentModel, exp.NestedReferenceType, field.ObjectDefinition.NestedObject.Type)
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
