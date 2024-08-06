// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

func (p pipeline) cleanupModels() error {
	// First delete all invalid models (i.e. those without fields)
	modelsToDelete := make([]string, 0)
	for modelName, model := range p.models {
		if !model.IsValid() {
			modelsToDelete = append(modelsToDelete, modelName)
		}
	}

	for _, modelName := range modelsToDelete {
		delete(p.models, modelName)
	}

	// Look for invalid references due to deleted models, and remove them
	for _, model := range p.models {
		for _, field := range model.Fields {
			if field.ModelName != nil {
				if !p.models.Found(*field.ModelName) {
					field.ModelName = nil
				}
			}
		}
	}

	return nil
}
