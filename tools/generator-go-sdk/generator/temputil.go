package generator

const utilString = `package %s

import (
	"fmt"
	"regexp"
	"strings"
)

type AzureParserConfig struct {
	RequiredSegments int
	Separator string
}

type AzureParser struct {
	RequiredSegments int
	Parts     []string
	Separator string
}

func NewAzureParser(config AzureParserConfig, id string) (*AzureParser, error) {
	ap := &AzureParser{
		RequiredSegments: config.RequiredSegments,
		Separator: 		  config.Separator,
	}

	// Remove duplicate separators
	re, err := regexp.Compile(ap.Separator)
	if err != nil {
		return nil, fmt.Errorf("while compiling regexp %%q: %%+v", ap.Separator, err)
	}
	id = re.ReplaceAllString(id, ap.Separator)
	if id[0] == '/' {
		id = id[1:]
	}

	ap.Parts = strings.Split(id, ap.Separator)
	if len(ap.Parts) != ap.RequiredSegments {
		return nil, fmt.Errorf("expected the ID %%q to have %%d segments but got %%d", id, ap.RequiredSegments, len(ap.Parts))
	}

	return ap, nil
}

func (a AzureParser) GetIndex(index int, reverse bool) int {
	if reverse {
		return a.RequiredSegments - 1 - index
	}
	return index
}

func ExtractNameFromTitleCase(input string) string {
    input = strings.Title(input)
	re := regexp.MustCompile("[A-Z][^A-Z]*")
	res := re.FindAllString(input, -1)
	if res == nil {
		return input
	}
	return strings.Join(res, " ")
}

`
