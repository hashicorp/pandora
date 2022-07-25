package services

import (
	"fmt"

	"github.com/hashicorp/hcl/v2/hclsimple"
)

// LoadFromFile loads the given Config from the specified filePath
func LoadFromFile(filePath string) (*Config, error) {
	var config Config
	err := hclsimple.DecodeFile(filePath, nil, &config)
	if err != nil {
		return nil, fmt.Errorf("parsing: %+v", err)
	}

	return &config, nil
}
