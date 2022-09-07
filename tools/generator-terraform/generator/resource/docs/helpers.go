package docs

import (
	"fmt"
	"sort"
	"strings"
	"unicode"
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

func convertToSnakeCase(input string) string {

	splitIdxMap := map[int]struct{}{}
	var lastChar rune
	for idx, char := range input {
		switch {
		case idx == 0:
			splitIdxMap[idx] = struct{}{}
		case unicode.IsUpper(lastChar) == unicode.IsUpper(char):
		case unicode.IsUpper(lastChar):
			splitIdxMap[idx-1] = struct{}{}
		case unicode.IsUpper(char):
			splitIdxMap[idx] = struct{}{}
		}
		lastChar = char
	}
	splitIdx := make([]int, 0, len(splitIdxMap))
	for idx := range splitIdxMap {
		splitIdx = append(splitIdx, idx)
	}
	sort.Ints(splitIdx)

	inputRunes := []rune(input)
	out := make([]string, len(splitIdx))
	for i := range splitIdx {
		if i == len(splitIdx)-1 {
			out[i] = strings.ToLower(string(inputRunes[splitIdx[i]:]))
			continue
		}
		out[i] = strings.ToLower(string(inputRunes[splitIdx[i]:splitIdx[i+1]]))
	}
	return strings.Join(out, "_")
}
