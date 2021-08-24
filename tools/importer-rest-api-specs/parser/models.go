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
	r.appendConstants(other.constants)

	if r.models == nil {
		r.models = make(map[string]models.ModelDetails)
	}
	r.appendModels(other.models)
}

func (r *parseResult) appendConstants(other map[string]models.ConstantDetails) {
	for k, v := range other {
		// TODO: merging of values
		r.constants[k] = v
	}
}

func (r *parseResult) appendModels(other map[string]models.ModelDetails) {
	for k, v := range other {
		r.models[k] = v
	}
}
