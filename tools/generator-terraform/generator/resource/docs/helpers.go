package docs

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// wordifySegmentName takes an input PascalCased string and converts it to a more human-friendly variant
// e.g. `applicationGroupName` -> `Application Group`
func wordifySegmentName(input string) string {
	val := strings.Title(input)
	val = strings.TrimSuffix(val, "Name")
	output := ""

	for _, c := range val {
		character := string(c)
		if strings.ToUpper(character) == character {
			output += " "
		}
		output += character
	}

	return strings.TrimPrefix(output, " ")
}

func wordifyTimeout(inMinutes int) string {
	hours := inMinutes / 60
	if hours > 0 {
		var hoursText string
		if hours > 1 {
			hoursText = fmt.Sprintf("%d hours", hours)
		} else {
			hoursText = "1 hour"
		}

		minutesRemaining := inMinutes % 60
		if minutesRemaining == 0 {
			return hoursText
		}

		var minutesText string
		if minutesRemaining > 1 {
			minutesText = fmt.Sprintf("%d minutes", minutesRemaining)
		} else {
			minutesText = "1 minute"
		}

		return fmt.Sprintf("%s and %s", hoursText, minutesText)
	}

	if inMinutes > 1 {
		return fmt.Sprintf("%d minutes", inMinutes)
	}

	return "1 minute"
}

func beginsWithVowel(word string) bool {
	switch strings.ToLower(word[0:1]) {
	case "a", "e", "i", "o", "u":
		return true
	default:
		return false
	}
}

func sortFieldNamesAlphabetically(model resourcemanager.TerraformSchemaModelDefinition) []string {
	fieldNames := make([]string, 0, len(model.Fields))
	for k := range model.Fields {
		fieldNames = append(fieldNames, k)
	}
	sort.Strings(fieldNames)
	return fieldNames
}

func stringPointer(in string) *string {
	return &in
}
