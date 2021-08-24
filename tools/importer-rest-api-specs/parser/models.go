package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

type parseResult struct {
	constants map[string]models.ConstantDetails
	models    map[string]models.ModelDetails
}

func (r *parseResult) append(other parseResult) {
	if r.constants == nil {
		r.constants = make(map[string]models.ConstantDetails)
	}
	for k, v := range other.constants {
		// TODO: merging of values
		r.constants[k] = v
	}

	if r.models == nil {
		r.models = make(map[string]models.ModelDetails)
	}
	for k, v := range other.models {
		r.models[k] = v
	}
}
