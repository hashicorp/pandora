package models

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/combine"
)

// SupplementaryData contains information about any Constants and Models which are Supplementary.
// These Constants and Models aren't directly used in either Operations or Resource IDs, but are
// typically used in Discriminator Implementations for Models which are, and so need to be included
// and considered when identifying Discriminator Implementations.
type SupplementaryData struct {
	// Constants specifies a map of Constant Name (key, valid as an identifier) to SDKConstant (value).
	Constants map[string]sdkModels.SDKConstant

	// Models specifies a map of Model Name (key, valid as an identifier) to SDKModel (value).
	Models map[string]sdkModels.SDKModel
}

func (d *SupplementaryData) AppendConstant(name string, value sdkModels.SDKConstant) error {
	constants := map[string]sdkModels.SDKConstant{
		name: value,
	}

	combinedConstants, err := combine.Constants(d.Constants, constants)
	if err != nil {
		return fmt.Errorf("combining Constants: %+v", err)
	}
	d.Constants = *combinedConstants

	return nil
}

func (d *SupplementaryData) AppendParseResult(other ParseResult) error {
	combinedConstants, err := combine.Constants(d.Constants, other.Constants)
	if err != nil {
		return fmt.Errorf("combining Constants: %+v", err)
	}
	d.Constants = *combinedConstants

	combinedModels, err := combine.Models(d.Models, other.Models)
	if err != nil {
		return fmt.Errorf("combining Models: %+v", err)
	}
	d.Models = *combinedModels

	return nil
}
