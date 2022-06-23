package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func switchOutCommonResourceIDsAsNeeded(namesToUris map[string]models.ParsedResourceId) map[string]models.ParsedResourceId {
	if !featureflags.EnableCommonResourceIDs {
		return namesToUris
	}

	output := make(map[string]models.ParsedResourceId)

	for name, value := range namesToUris {
		for _, commonId := range commonIdTypes {
			if commonId.isMatch(value) {
				commonAlias := commonId.name()
				value.CommonAlias = &commonAlias
				break
			}
		}

		output[name] = value
	}

	return output
}
