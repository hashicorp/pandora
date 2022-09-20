package helpers

import (
	"sort"
	"strings"
	"unicode"
)

func ConvertToSnakeCase(input string) string {
	if v, ok := schemaFieldNameOverrides[strings.ToLower(input)]; ok {
		return v
	}

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

var schemaFieldNameOverrides = map[string]string{
	"etag": "etag",
	"ip":   "ip_address",
}
