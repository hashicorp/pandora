package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseConstantsIntegersTopLevelAsInts(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Int that's output as an Integer.
	result, err := ParseSwaggerFileForTesting(t, "constants_integers_as_ints.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.IntegerConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Integer' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 4 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 4 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["One"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'One'")
	}
	if v != "1" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['One'] to be '1' but got %q", v)
	}
	v, ok = favouriteTable.Values["Two"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'Two'")
	}
	if v != "2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Two'] to be '2' but got %q", v)
	}
	v, ok = favouriteTable.Values["Three"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'Three'")
	}
	if v != "3" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Three'] to be '3' but got %q", v)
	}
	v, ok = favouriteTable.Values["FourFiveSixSeven"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'FourFiveSixSeven'")
	}
	if v != "4567" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['FourFiveSixSeven'] to be '4567' but got %q", v)
	}
}

func TestParseConstantsIntegersTopLevelAsStrings(t *testing.T) {
	// Tests an Integer Constant with modelAsString, which is bad data / should be ignored
	result, err := ParseSwaggerFileForTesting(t, "constants_integers_as_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['FavouriteTable'] was not found")
	}
	if favouriteTable.FieldType != models.IntegerConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Integer' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["One"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'One'")
	}
	if v != "1" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['One'] to be '1' but got %q", v)
	}
	v, ok = favouriteTable.Values["Two"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'Two'")
	}
	if v != "2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Two'] to be '2' but got %q", v)
	}
	v, ok = favouriteTable.Values["Three"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'Three'")
	}
	if v != "3" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Three'] to be '3' but got %q", v)
	}
}

func TestParseConstantsIntegersInlinedAsInts(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Int that's output as an Integer.
	result, err := ParseSwaggerFileForTesting(t, "constants_integers_as_ints_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['FavouriteTable'] was not found")
	}
	if favouriteTable.FieldType != models.IntegerConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Integer' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["One"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'One'")
	}
	if v != "1" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['One'] to be '1' but got %q", v)
	}
	v, ok = favouriteTable.Values["Two"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'Two'")
	}
	if v != "2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Two'] to be '2' but got %q", v)
	}
	v, ok = favouriteTable.Values["Three"]
	if !ok {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Three'] to be '3' but got %q", v)
	}
	if v != "3" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Three'] to be '3' but got %q", v)
	}
}

func TestParseConstantsIntegersInlinedAsStrings(t *testing.T) {
	// Tests an Integer Constant defined Inline with modelAsString, which is bad data / should be ignored
	result, err := ParseSwaggerFileForTesting(t, "constants_integers_as_strings_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.IntegerConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Integer' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["One"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'One'")
	}
	if v != "1" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['One'] to be '1' but got %q", v)
	}
	v, ok = favouriteTable.Values["Two"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'Two'")
	}
	if v != "2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Two'] to be '2' but got %q", v)
	}
	v, ok = favouriteTable.Values["Three"]
	if !ok {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Three'] to be '3' but got %q", v)
	}
	if v != "3" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['Three'] to be '3' but got %q", v)
	}
}

func TestParseConstantsFloatsTopLevelAsFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Float that's output as a Float.
	result, err := ParseSwaggerFileForTesting(t, "constants_floats_as_floats.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.FloatConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Float' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["OnePointOne"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'OnePointOne'")
	}
	if v != "1.1" {
		t.Fatalf("expected the value for resource.Constants['FavouriteTable'].Values['OnePointOne'] to be '1.1' but got %q", v)
	}
	v, ok = favouriteTable.Values["TwoPointTwo"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'TwoPointTwo'")
	}
	if v != "2.2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['TwoPointTwo'] to be '2.2' but got %q", v)
	}
	v, ok = favouriteTable.Values["ThreePointThreeZeroZeroZeroFour"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'ThreePointThreeZeroZeroZeroFour'")
	}
	if v != "3.30004" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['ThreePointThreeZeroZeroZeroFour'] to be '3.30004' but got %q", v)
	}
}

func TestParseConstantsStringsTopLevelContainingFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Float that's output as a String.
	result, err := ParseSwaggerFileForTesting(t, "constants_strings_which_are_floats.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.StringConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'String' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["OnePointOne"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'OnePointOne'")
	}
	if v != "1.1" {
		t.Fatalf("expected the value for resource.Constants['FavouriteTable'].Values['OnePointOne'] to be '1.1' but got %q", v)
	}
	v, ok = favouriteTable.Values["TwoPointTwo"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'TwoPointTwo'")
	}
	if v != "2.2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['TwoPointTwo'] to be '2.2' but got %q", v)
	}
	v, ok = favouriteTable.Values["ThreePointThreeZeroZeroZeroFour"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'ThreePointThreeZeroZeroZeroFour'")
	}
	if v != "3.30004" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['ThreePointThreeZeroZeroZeroFour'] to be '3.30004' but got %q", v)
	}
}

func TestParseConstantsStringsInlinedContainingFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Float that's output as a Float.
	result, err := ParseSwaggerFileForTesting(t, "constants_floats_as_floats_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.FloatConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Float' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["OnePointOne"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'OnePointOne'")
	}
	if v != "1.1" {
		t.Fatalf("expected the value for resource.Constants['FavouriteTable'].Values['OnePointOne'] to be '1.1' but got %q", v)
	}
	v, ok = favouriteTable.Values["TwoPointTwo"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'TwoPointTwo'")
	}
	if v != "2.2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['TwoPointTwo'] to be '2.2' but got %q", v)
	}
	v, ok = favouriteTable.Values["ThreePointThreeZeroZeroZeroFour"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'ThreePointThreeZeroZeroZeroFour'")
	}
	if v != "3.30004" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['ThreePointThreeZeroZeroZeroFour'] to be '3.30004' but got %q", v)
	}
}

func TestParseConstantsFloatsTopLevelAsStrings(t *testing.T) {
	// Tests an Float Constant with modelAsString, which is bad data / should be ignored
	result, err := ParseSwaggerFileForTesting(t, "constants_floats_as_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.FloatConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Float' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["OnePointOne"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'OnePointOne'")
	}
	if v != "1.1" {
		t.Fatalf("expected the value for resource.Constants['FavouriteTable'].Values['OnePointOne'] to be '1.1' but got %q", v)
	}
	v, ok = favouriteTable.Values["TwoPointTwo"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'TwoPointTwo'")
	}
	if v != "2.2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['TwoPointTwo'] to be '2.2' but got %q", v)
	}
	v, ok = favouriteTable.Values["ThreePointThreeZeroZeroZeroFour"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'ThreePointThreeZeroZeroZeroFour'")
	}
	if v != "3.30004" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['ThreePointThreeZeroZeroZeroFour'] to be '3.30004' but got %q", v)
	}
}

func TestParseConstantsFloatsInlinedAsFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Float that's output as a Float.
	result, err := ParseSwaggerFileForTesting(t, "constants_floats_as_floats_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.FloatConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Float' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["OnePointOne"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'OnePointOne'")
	}
	if v != "1.1" {
		t.Fatalf("expected the value for resource.Constants['FavouriteTable'].Values['OnePointOne'] to be '1.1' but got %q", v)
	}
	v, ok = favouriteTable.Values["TwoPointTwo"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'TwoPointTwo'")
	}
	if v != "2.2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['TwoPointTwo'] to be '2.2' but got %q", v)
	}
	v, ok = favouriteTable.Values["ThreePointThreeZeroZeroZeroFour"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'ThreePointThreeZeroZeroZeroFour'")
	}
	if v != "3.30004" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['ThreePointThreeZeroZeroZeroFour'] to be '3.30004' but got %q", v)
	}
}

func TestParseConstantsFloatsInlinedAsStrings(t *testing.T) {
	// Tests an Float Constant defined inline with modelAsString, which is bad data / should be ignored
	result, err := ParseSwaggerFileForTesting(t, "constants_floats_as_strings_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 2 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	person, ok := resource.Models["Person"]
	if !ok {
		t.Fatalf("the Model `Person` was not found")
	}
	if len(person.Fields) != 1 {
		t.Fatalf("expected person.Fields to have 1 field but got %d", len(person.Fields))
	}
	favouriteTableField, ok := person.Fields["FavouriteTable"]
	if !ok {
		t.Fatal("animal.Fields['FavouriteTable'] did not exist")
	}
	if favouriteTableField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ObjectDefinition")
	}
	if favouriteTableField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['FavouriteTable'] should be a Reference but got %q", string(favouriteTableField.ObjectDefinition.Type))
	}
	if *favouriteTableField.ObjectDefinition.ReferenceName != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ObjectDefinition.ReferenceName)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.FloatConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'Float' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["OnePointOne"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'OnePointOne'")
	}
	if v != "1.1" {
		t.Fatalf("expected the value for resource.Constants['FavouriteTable'].Values['OnePointOne'] to be '1.1' but got %q", v)
	}
	v, ok = favouriteTable.Values["TwoPointTwo"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'TwoPointTwo'")
	}
	if v != "2.2" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['TwoPointTwo'] to be '2.2' but got %q", v)
	}
	v, ok = favouriteTable.Values["ThreePointThreeZeroZeroZeroFour"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] didn't contain the key 'ThreePointThreeZeroZeroZeroFour'")
	}
	if v != "3.30004" {
		t.Fatalf("expected the value for resource.Constants['TableNumber'].Values['ThreePointThreeZeroZeroZeroFour'] to be '3.30004' but got %q", v)
	}
}

func TestParseConstantsStringsTopLevel(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "constants_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 4 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if len(animal.Fields) != 1 {
		t.Fatalf("expected animal.Fields to have 1 field but got %d", len(animal.Fields))
	}
	animalTypeField, ok := animal.Fields["Type"]
	if !ok {
		t.Fatal("animal.Fields['Type'] did not exist")
	}
	if animalTypeField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['Type'] had a nil ObjectDefinition")
	}
	if animalTypeField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['Type'] should be a Reference but got %q", string(animalTypeField.ObjectDefinition.Type))
	}
	if *animalTypeField.ObjectDefinition.ReferenceName != "AnimalType" {
		t.Fatalf("animal.Fields['Type'] should be 'AnimalType' but was %q", *animalTypeField.ObjectDefinition.ReferenceName)
	}

	animalType, ok := resource.Constants["AnimalType"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] was not found")
	}
	if animalType.FieldType != models.StringConstant {
		t.Fatalf("expected animalType.FieldType to be a 'String' but got %q", animalType.FieldType)
	}
	if len(animalType.Values) != 4 {
		t.Fatalf("expected resource.Constants['AnimalType'] to have 4 values but got %d", len(animalType.Values))
	}
	v, ok := animalType.Values["Cat"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Cat'")
	}
	if v != "cat" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Cat'] to be 'cat' but got %q", v)
	}
	v, ok = animalType.Values["Dog"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Dog'")
	}
	if v != "dog" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Dog'] to be 'dog' but got %q", v)
	}
	v, ok = animalType.Values["Panda"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Panda'")
	}
	if v != "panda" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Panda'] to be 'panda' but got %q", v)
	}
	v, ok = animalType.Values["Any"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Any'")
	}
	if v != "*" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Any'] to be '*' but got %q", v)
	}
}

func TestParseConstantsStringsTopLevelAsNonStrings(t *testing.T) {
	// whilst the value is "string", due to (what appears to be) bad data the
	// "modelAsString" property can be set to false - as such we force it to
	// a string either way, since that's what it is
	result, err := ParseSwaggerFileForTesting(t, "constants_strings_as_non_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 4 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if len(animal.Fields) != 1 {
		t.Fatalf("expected animal.Fields to have 1 field but got %d", len(animal.Fields))
	}
	animalTypeField, ok := animal.Fields["Type"]
	if !ok {
		t.Fatal("animal.Fields['Type'] did not exist")
	}
	if animalTypeField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['Type'] had a nil ObjectDefinition")
	}
	if animalTypeField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['Type'] should be a Reference but got %q", string(animalTypeField.ObjectDefinition.Type))
	}
	if *animalTypeField.ObjectDefinition.ReferenceName != "AnimalType" {
		t.Fatalf("animal.Fields['Type'] should be 'AnimalType' but was %q", *animalTypeField.ObjectDefinition.ReferenceName)
	}

	animalType, ok := resource.Constants["AnimalType"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] was not found")
	}
	if animalType.FieldType != models.StringConstant {
		t.Fatalf("expected animalType.FieldType to be a 'String' but got %q", animalType.FieldType)
	}
	if len(animalType.Values) != 3 {
		t.Fatalf("expected resource.Constants['AnimalType'] to have 3 values but got %d", len(animalType.Values))
	}
	v, ok := animalType.Values["Cat"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Cat'")
	}
	if v != "cat" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Cat'] to be 'cat' but got %q", v)
	}
	v, ok = animalType.Values["Dog"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Dog'")
	}
	if v != "dog" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Dog'] to be 'dog' but got %q", v)
	}
	v, ok = animalType.Values["Panda"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Panda'")
	}
	if v != "panda" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Panda'] to be 'panda' but got %q", v)
	}
}

func TestParseConstantsStringsInlined(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "constants_strings_inlined.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 4 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if len(animal.Fields) != 1 {
		t.Fatalf("expected animal.Fields to have 1 field but got %d", len(animal.Fields))
	}
	animalTypeField, ok := animal.Fields["Type"]
	if !ok {
		t.Fatal("animal.Fields['Type'] did not exist")
	}
	if animalTypeField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['Type'] had a nil ObjectDefinition")
	}
	if animalTypeField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['Type'] should be a Reference but got %q", string(animalTypeField.ObjectDefinition.Type))
	}
	if *animalTypeField.ObjectDefinition.ReferenceName != "AnimalType" {
		t.Fatalf("animal.Fields['Type'] should be 'AnimalType' but was %q", *animalTypeField.ObjectDefinition.ReferenceName)
	}

	animalType, ok := resource.Constants["AnimalType"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] was not found")
	}
	if animalType.FieldType != models.StringConstant {
		t.Fatalf("expected animalType.FieldType to be a 'String' but got %q", animalType.FieldType)
	}
	if len(animalType.Values) != 3 {
		t.Fatalf("expected resource.Constants['AnimalType'] to have 3 values but got %d", len(animalType.Values))
	}
	v, ok := animalType.Values["Cat"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Cat'")
	}
	if v != "cat" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Cat'] to be 'cat' but got %q", v)
	}
	v, ok = animalType.Values["Dog"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Dog'")
	}
	if v != "dog" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Dog'] to be 'dog' but got %q", v)
	}
	v, ok = animalType.Values["Panda"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Panda'")
	}
	if v != "panda" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Panda'] to be 'panda' but got %q", v)
	}
}

func TestParseConstantsStringsInlinedAsNonStrings(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "constants_strings_inlined_as_non_strings.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["Discriminator"]
	if !ok {
		t.Fatal("the Resource 'Discriminator' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 2 {
		t.Fatalf("expected 4 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	wrapper, ok := resource.Models["ExampleWrapper"]
	if !ok {
		t.Fatalf("the Model `ExampleWrapper` was not found")
	}
	if len(wrapper.Fields) != 2 {
		t.Fatalf("expected wrapper.Fields to have 2 fields but got %d", len(wrapper.Fields))
	}

	animal, ok := resource.Models["Animal"]
	if !ok {
		t.Fatalf("the Model `Animal` was not found")
	}
	if len(animal.Fields) != 1 {
		t.Fatalf("expected animal.Fields to have 1 field but got %d", len(animal.Fields))
	}
	animalTypeField, ok := animal.Fields["Type"]
	if !ok {
		t.Fatal("animal.Fields['Type'] did not exist")
	}
	if animalTypeField.ObjectDefinition == nil {
		t.Fatal("animal.Fields['Type'] had a nil ObjectDefinition")
	}
	if animalTypeField.ObjectDefinition.Type != models.ObjectDefinitionReference {
		t.Fatalf("animal.Fields['Type'] should be a Reference but got %q", string(animalTypeField.ObjectDefinition.Type))
	}
	if *animalTypeField.ObjectDefinition.ReferenceName != "AnimalType" {
		t.Fatalf("animal.Fields['Type'] should be 'AnimalType' but was %q", *animalTypeField.ObjectDefinition.ReferenceName)
	}

	animalType, ok := resource.Constants["AnimalType"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] was not found")
	}
	if animalType.FieldType != models.StringConstant {
		t.Fatalf("expected animalType.FieldType to be a 'String' but got %q", animalType.FieldType)
	}
	if len(animalType.Values) != 3 {
		t.Fatalf("expected resource.Constants['AnimalType'] to have 3 values but got %d", len(animalType.Values))
	}
	v, ok := animalType.Values["Cat"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Cat'")
	}
	if v != "cat" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Cat'] to be 'cat' but got %q", v)
	}
	v, ok = animalType.Values["Dog"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Dog'")
	}
	if v != "dog" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Dog'] to be 'dog' but got %q", v)
	}
	v, ok = animalType.Values["Panda"]
	if !ok {
		t.Fatalf("resource.Constants['AnimalType'] didn't contain the key 'Panda'")
	}
	if v != "panda" {
		t.Fatalf("expected the value for resource.Constants['AnimalType'].Values['Panda'] to be 'panda' but got %q", v)
	}
}

func TestParseConstantsFromParameters(t *testing.T) {
	result, err := ParseSwaggerFileForTesting(t, "constants_in_operation_parameters.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}
	if result == nil {
		t.Fatal("result was nil")
	}
	if len(result.Resources) != 1 {
		t.Fatalf("expected 1 resource but got %d", len(result.Resources))
	}

	resource, ok := result.Resources["ConstantFunTime"]
	if !ok {
		t.Fatal("the Resource 'ConstantFunTime' was not found")
	}

	// sanity checking
	if len(resource.Constants) != 1 {
		t.Fatalf("expected 1 constant but got %d", len(resource.Constants))
	}
	if len(resource.Models) != 0 {
		t.Fatalf("expected 0 models but got %d", len(resource.Models))
	}
	if len(resource.Operations) != 1 {
		t.Fatalf("expected 1 operation but got %d", len(resource.Operations))
	}
	if len(resource.ResourceIds) != 1 {
		t.Fatalf("expected 1 Resource ID but got %d", len(resource.ResourceIds))
	}

	favouriteTable, ok := resource.Constants["MediaType"]
	if !ok {
		t.Fatalf("resource.Constants['TableNumber'] was not found")
	}
	if favouriteTable.FieldType != models.StringConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'String' but got %q", favouriteTable.FieldType)
	}
	if len(favouriteTable.Values) != 3 {
		t.Fatalf("expected resource.Constants['TableNumber'] to have 3 values but got %d", len(favouriteTable.Values))
	}
	v, ok := favouriteTable.Values["EightTrack"]
	if !ok {
		t.Fatalf("resource.Constants['MediaType'] didn't contain the key 'One'")
	}
	if v != "8Track" {
		t.Fatalf("expected the value for resource.Constants['MediaType'].Values['EightTrack'] to be '8Track' but got %q", v)
	}
	v, ok = favouriteTable.Values["Cassette"]
	if !ok {
		t.Fatalf("resource.Constants['MediaType'] didn't contain the key 'Cassette'")
	}
	if v != "Cassette" {
		t.Fatalf("expected the value for resource.Constants['MediaType'].Values['Cassette'] to be 'Cassette' but got %q", v)
	}
	v, ok = favouriteTable.Values["Vinyl"]
	if !ok {
		t.Fatalf("resource.Constants['MediaType'] didn't contain the key 'Vinyl'")
	}
	if v != "Vinyl" {
		t.Fatalf("expected the value for resource.Constants['MediaType'].Values['Vinyl'] to be 'Vinyl' but got %q", v)
	}
}
