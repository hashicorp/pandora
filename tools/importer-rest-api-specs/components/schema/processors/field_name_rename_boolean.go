package processors

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ FieldNameProcessor = fieldNameRenameBoolean{}

type fieldNameRenameBoolean struct{}

func (fieldNameRenameBoolean) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if metadata.Model.Fields[fieldName].ObjectDefinition.Type == resourcemanager.BooleanApiObjectDefinitionType {
		if strings.HasPrefix(strings.ToLower(fieldName), "enabled") {
			updated := fmt.Sprintf("%sEnabled", fieldName[7:])
			return &updated, nil
		}
		if strings.HasPrefix(strings.ToLower(fieldName), "disabled") {
			updated := fmt.Sprintf("%sDisabled", fieldName[7:])
			return &updated, nil
		}
		// flip `enable_X` / `disable_X` prefix
		if strings.HasPrefix(strings.ToLower(fieldName), "enable") {
			updated := fmt.Sprintf("%sEnabled", fieldName[6:])
			return &updated, nil
		}
		if strings.HasPrefix(strings.ToLower(fieldName), "disable") {
			updated := fmt.Sprintf("%sDisabled", fieldName[7:])
			return &updated, nil
		}
		// change `allow_X` prefix -> `X_enabled`
		if strings.HasPrefix(strings.ToLower(fieldName), "allow") {
			updated := fmt.Sprintf("%sEnabled", fieldName[5:])
			return &updated, nil
		}
		// change `allowed_X` prefix -> `X_enabled`
		if strings.HasPrefix(strings.ToLower(fieldName), "allowed") {
			updated := fmt.Sprintf("%sEnabled", fieldName[7:])
			return &updated, nil
		}
	}
	return nil, nil
}
