package constants

import (
	"fmt"
	"regexp"
	"strconv"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
)

func keyValueForFloat(input float64) string {
	stringified := stringValueForFloat(input)
	return stringifyNumberInput(stringified)
}

func keyValueForInteger(input int64) string {
	s := fmt.Sprintf("%d", input)
	vals := map[int32]string{
		'-': "Negative",
		'0': "Zero",
		'1': "One",
		'2': "Two",
		'3': "Three",
		'4': "Four",
		'5': "Five",
		'6': "Six",
		'7': "Seven",
		'8': "Eight",
		'9': "Nine",
	}
	out := ""
	for _, c := range s {
		v, ok := vals[c]
		if !ok {
			panic(fmt.Sprintf("missing mapping for %q", string(c)))
		}
		out += v
	}

	return out
}

func normalizeConstantKey(input string) string {
	output := input
	output = stringifyNumberInput(output)
	if !strings.Contains(output, "Point") {
		output = renameMultiplesOfZero(output)
	}

	output = strings.ReplaceAll(output, "*", "Any")
	output = cleanup.NormalizeName(output)
	return output
}

func renameMultiplesOfZero(input string) string {
	if strings.HasPrefix(input, "Zero") && !strings.HasSuffix(input, "Zero") {
		return input
	}

	re := regexp.MustCompile("(?:Zero)")
	zeros := re.FindAllStringIndex(input, -1)
	z := len(zeros)

	if z < 2 {
		return input
	}

	vals := map[int]string{
		2: "Hundred",
		3: "Thousand",
		4: "Thousand",
		5: "HundredThousand",
		6: "Million",
	}

	if v, ok := vals[z]; ok {
		switch z {
		case 4:
			return strings.Replace(input, strings.Repeat("Zero", z), "Zero"+v, 1)
		default:
			return strings.Replace(input, strings.Repeat("Zero", z), v, 1)
		}
	}

	return input
}

func stringValueForFloat(input float64) string {
	return strconv.FormatFloat(input, 'f', -1, 64)
}

func stringifyNumberInput(input string) string {
	vals := map[int32]string{
		'.': "Point",
		'+': "Positive",
		'-': "Negative",
		'0': "Zero",
		'1': "One",
		'2': "Two",
		'3': "Three",
		'4': "Four",
		'5': "Five",
		'6': "Six",
		'7': "Seven",
		'8': "Eight",
		'9': "Nine",
	}
	output := ""
	for _, c := range input {
		v, ok := vals[c]
		if !ok {
			output += string(c)
			continue
		}
		output += v
	}
	return output
}
