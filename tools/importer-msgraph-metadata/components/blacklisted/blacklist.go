package blacklisted

import (
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"strings"
)

func Resource(resource *parser.Resource) bool {
	if resource.Service == "Groups" {

		// GroupSiteTermStore resources have repeating ID segments which are not supported at this time
		if strings.Contains(resource.Name, "TermStore") {
			return true
		}

		// Onenote resources have repeating ID segments which are not supported at this time
		if strings.Contains(resource.Name, "Onenote") {
			return true
		}

	}

	return false
}
