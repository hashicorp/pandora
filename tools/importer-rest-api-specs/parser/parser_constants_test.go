package parser

import (
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseConstantsIntegersTopLevelAsInts(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Int that's output as an Integer.
	parsed, err := Load("testdata/", "constants_integers_as_ints.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'] should be 'FavouriteTable' but was %q", *favouriteTableField.ConstantReference)
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
	// Enums can either be modelled as strings or not.. this is an Int that's output as a String.
	parsed, err := Load("testdata/", "constants_integers_as_strings.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'].ConstantReference should be 'TableNumber' but was %q", *favouriteTableField.ConstantReference)
	}

	favouriteTable, ok := resource.Constants["TableNumber"]
	if !ok {
		t.Fatalf("resource.Constants['FavouriteTable'] was not found")
	}
	if favouriteTable.FieldType != models.StringConstant {
		t.Fatalf("expected resource.Constants['TableNumber'].FieldType to be 'String' but got %q", favouriteTable.FieldType)
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
	parsed, err := Load("testdata/", "constants_integers_as_ints_inlined.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'].ConstantReference should be 'FavouriteTable' but was %q", *favouriteTableField.ConstantReference)
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
	// Enums can either be modelled as strings or not.. this is an Int that's output as a String.
	parsed, err := Load("testdata/", "constants_integers_as_strings_inlined.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'].ConstantReference should be 'TableNumber' but was %q", *favouriteTableField.ConstantReference)
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
	parsed, err := Load("testdata/", "constants_floats_as_floats.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'].ConstantReference should be 'TableNumber' but was %q", *favouriteTableField.ConstantReference)
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
	parsed, err := Load("testdata/", "constants_strings_which_are_floats.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['favouriteTable'].ConstantReference should be 'TableNumber' but was %q", *favouriteTableField.ConstantReference)
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
	parsed, err := Load("testdata/", "constants_floats_as_floats_inlined.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'].ConstantReference should be 'TableNumber' but was %q", *favouriteTableField.ConstantReference)
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
	// Enums can either be modelled as strings or not.. this is an Float that's output as a String.
	parsed, err := Load("testdata/", "constants_floats_as_strings.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['favouriteTable'].ConstantReference should be 'TableNumber' but was %q", *favouriteTableField.ConstantReference)
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

func TestParseConstantsFloatsInlinedAsFloats(t *testing.T) {
	// Enums can either be modelled as strings or not.. this is an Float that's output as a Float.
	parsed, err := Load("testdata/", "constants_floats_as_floats_inlined.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['FavouriteTable'].ConstantReference should be 'TableNumber' but was %q", *favouriteTableField.ConstantReference)
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
	// Enums can either be modelled as strings or not.. this is an Float that's output as a String.
	parsed, err := Load("testdata/", "constants_floats_as_strings_inlined.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if favouriteTableField.ConstantReference == nil {
		t.Fatal("animal.Fields['FavouriteTable'] had a nil ConstantReference")
	}
	if *favouriteTableField.ConstantReference != "TableNumber" {
		t.Fatalf("animal.Fields['favouriteTable'].ConstantReference should be 'TableNumber' but was %q", *favouriteTableField.ConstantReference)
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

func TestParseConstantsStringsTopLevel(t *testing.T) {
	parsed, err := Load("testdata/", "constants_strings.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if animalTypeField.ConstantReference == nil {
		t.Fatal("animal.Fields['Type'] had a nil ConstantReference")
	}
	if *animalTypeField.ConstantReference != "AnimalType" {
		t.Fatalf("animal.Fields['Type'] should be 'AnimalType' but was %q", *animalTypeField.ConstantReference)
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
	parsed, err := Load("testdata/", "constants_strings_as_non_strings.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if animalTypeField.ConstantReference == nil {
		t.Fatal("animal.Fields['Type'] had a nil ConstantReference")
	}
	if *animalTypeField.ConstantReference != "AnimalType" {
		t.Fatalf("animal.Fields['Type'] should be 'AnimalType' but was %q", *animalTypeField.ConstantReference)
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
	parsed, err := Load("testdata/", "constants_strings_inlined.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if animalTypeField.ConstantReference == nil {
		t.Fatal("animal.Fields['Type'] had a nil ConstantReference")
	}
	if *animalTypeField.ConstantReference != "AnimalType" {
		t.Fatalf("animal.Fields['Type'] should be 'AnimalType' but was %q", *animalTypeField.ConstantReference)
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
	parsed, err := Load("testdata/", "constants_strings_inlined_as_non_strings.json", true)
	if err != nil {
		t.Fatalf("loading: %+v", err)
	}

	result, err := parsed.Parse("Example", "2020-01-01")
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
	if animalTypeField.ConstantReference == nil {
		t.Fatal("animal.Fields['Type'] had a nil ConstantReference")
	}
	if *animalTypeField.ConstantReference != "AnimalType" {
		t.Fatalf("animal.Fields['Type'] should be 'AnimalType' but was %q", *animalTypeField.ConstantReference)
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
