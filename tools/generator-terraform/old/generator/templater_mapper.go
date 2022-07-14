package generator

import "fmt"

type mappingData struct {
	typeAlias  string
	typeName   string
	methodName string
	modelName  string

	// originModelName is the model where this should be mapped from
	originModelName *string

	// TODO: mapping definitions from A -> B
}

// TODO: the other way too

func (d mappingData) schemaToModelCode(onlyWhenHasChanges bool) (*string, error) {
	// TODO: mappings and things
	code := fmt.Sprintf(`
func (%[1]s %[2]s) %[3]s(schema interface{}, model *sdk.%[4]s) error {
	// TODO: return the actual object type we're expecting
	// TODO: also this likely wants building out elsewhere?
	return fmt.Errorf("Not implemented..")
}
`, d.typeAlias, d.typeName, d.methodName, d.modelName)
	return &code, nil
}

func (d mappingData) modelToSchemaCode() (*string, error) {
	// TODO: mappings and things
	code := fmt.Sprintf(`
func (%[1]s %[2]s) %[3]s(model *sdk.%[4]s, schema *sdk.%[2]sModel) error {
	// TODO: return the actual object type we're expecting
	// TODO: also this likely wants building out elsewhere?
	return fmt.Errorf("Not implemented..")
}
`, d.typeAlias, d.typeName, d.methodName, d.modelName)
	return &code, nil
}

func (d mappingData) modelToModelCode() (*string, error) {
	if d.originModelName == nil {
		return nil, fmt.Errorf("originModelName needs to be specified")
	}

	// TODO: mappings and things
	code := fmt.Sprintf(`
func (%[1]s %[2]s) %[3]s(from sdk.%[4]s, to *sdk.%[5]s) error {
	// TODO: mappings
	return fmt.Errorf("Not implemented..")
}
`, d.typeAlias, d.typeName, d.methodName, *d.originModelName, d.modelName)
	return &code, nil
}
