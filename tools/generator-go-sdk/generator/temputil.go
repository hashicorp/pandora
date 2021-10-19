package generator

const utilString = `package %s

import (
	"fmt"
	"regexp"
	"strings"
)

type AzureParserConfig struct {
	MinLength int
	Separator string
}

type AzureParser struct {
	MinLength int
	NumParts  int
	Parts     []string
	Separator string
	idx       int
}

func NewAzureParser(config AzureParserConfig, id string) (*AzureParser, error) {
	ap := &AzureParser{
		MinLength: config.MinLength,
		Separator: config.Separator,
		idx:       0,
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

	parts := strings.Split(id, ap.Separator)

	ap.NumParts = len(parts)
	if ap.NumParts < ap.MinLength {
		return nil, fmt.Errorf("invalid length for id: %%q, expected to find at least %%d parts, found %%d", id, ap.MinLength, ap.NumParts)
	} else if ap.NumParts == 1 && parts[0] == "" {
		return nil, fmt.Errorf("empty url found")
	}
	ap.Parts = parts

	return ap, nil
}

func (a AzureParser) GetIdx(total, idx int, reverse bool) int {
	if reverse {
		return total - 1 - idx
	}
	return idx
}`
