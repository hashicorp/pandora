package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

type parseResult struct {
	constants map[string]models.ConstantDetails
	models map[string]models.ModelDetails
}

func (r *parseResult) append(other parseResult) {
	// TODO: implement this
}