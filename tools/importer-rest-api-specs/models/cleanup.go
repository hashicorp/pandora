package models

func (r *AzureApiResource) RemoveUnusedModelsAndConstants() {
	unusedModels := r.findUnusedModels()
	for len(unusedModels) > 0 {
		// remove those models
		for _, modelName := range unusedModels {
			delete(r.Models, modelName)
		}

		// then go around again
		unusedModels = r.findUnusedModels()
	}

	unusedConstants := r.findUnusedConstants()
	for len(unusedConstants) > 0 {
		// remove those constants
		for _, constantName := range unusedConstants {
			delete(r.Constants, constantName)
		}

		// then go around again
		unusedConstants = r.findUnusedConstants()
	}

	// TODO: presumably we should check for Resource ID's here in the future when implementing #13
}

func (r *AzureApiResource) findUnusedConstants() []string {
	unusedConstants := make([]string, 0)
	for constantName := range r.Constants {
		// constants are either housed inside a Model
		usedInAModel := false
		for _, model := range r.Models {
			for _, field := range model.Fields {
				if field.ConstantReference == nil {
					continue
				}

				if *field.ConstantReference == constantName {
					usedInAModel = true
					break
				}
			}

			if usedInAModel {
				break
			}
		}
		if usedInAModel {
			continue
		}

		usedInAnOperation := false
		for _, operation := range r.Operations {
			if operation.RequestObjectName != nil && *operation.RequestObjectName == constantName {
				usedInAnOperation = true
				break
			}

			if operation.ResponseObjectName != nil && *operation.ResponseObjectName == constantName {
				usedInAnOperation = true
				break
			}

			// TODO: these could also be in the Options in future (see #19) - but this isn't implemented yet
		}
		if usedInAnOperation {
			continue
		}

		unusedConstants = append(unusedConstants, constantName)
	}

	return unusedConstants
}

func (r *AzureApiResource) findUnusedModels() []string {
	unusedModels := make([]string, 0)
	for modelName, _ := range r.Models {
		if modelName == "ResourceIdentity" {
			modelName = "ResourceIdentity"
		}
		// models are either referenced by operations
		usedInAnOperation := false
		for _, operation := range r.Operations {
			if operation.RequestObjectName != nil && *operation.RequestObjectName == modelName {
				usedInAnOperation = true
				break
			}
			if operation.ResponseObjectName != nil && *operation.ResponseObjectName == modelName {
				usedInAnOperation = true
				break
			}
			// TODO: can these be in Options in the future too? confirm as a part of #19
		}
		if usedInAnOperation {
			continue
		}

		// or on other models
		usedInAModel := false
		for thisModelName, model := range r.Models {
			if thisModelName == modelName {
				continue
			}

			for _, field := range model.Fields {
				if field.ModelReference != nil && *field.ModelReference == modelName {
					usedInAModel = true
					break
				}
			}
		}
		if usedInAModel {
			continue
		}

		unusedModels = append(unusedModels, modelName)
	}
	return unusedModels
}
