package processors

import "fmt"

var _ FieldNameProcessor = fieldNameExists{}

type fieldNameExists struct{}

func (fieldNameExists) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	_, ok := metadata.Model.Fields[fieldName]
	if !ok {
		return nil, fmt.Errorf("%s was not found in %+v", fieldName, metadata.Model.Fields)
	}
	return nil, nil
}
