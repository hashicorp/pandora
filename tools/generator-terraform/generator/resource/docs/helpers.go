package docs

import (
	"fmt"
	"regexp"
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

func beginsWithVowel(word string) (bool, error) {

	if len(word) == 0 {
		return false, fmt.Errorf("cannot check if an empty string begins with a vowel")
	}

	switch strings.ToLower(word[0:1]) {
	case "a", "e", "i", "o", "u":
		return true, nil
	default:
		return false, nil
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

func sortStringStringMapKeys(m map[string]string) []string {
	keys := make([]string, 0, len(m))
	for k := range m {
		keys = append(keys, k)
	}
	sort.Strings(keys)
	return keys
}

func stringPointer(in string) *string {
	return &in
}

func wordifyPossibleValues[T any](in []T) string {
	if len(in) == 1 {
		return fmt.Sprintf("The only possible value is `%+v`.", in[0])
	}

	out := make([]string, 0)
	for _, v := range in {
		out = append(out, fmt.Sprintf("`%+v`", v))
	}

	output := fmt.Sprintf("Possible values are %s and %s.", strings.Join(out[0:len(out)-1], ", "), out[len(out)-1])
	return output
}

func removeExtraSpaces(line string) string {
	re := regexp.MustCompile(`\s+`)
	return re.ReplaceAllString(line, " ")
}
