package parsingcontext

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func (c *Context) doesModelImplement(modelName string, value spec.Schema, parentName string) (*bool, error) {
	implementsParent := false
	if !strings.EqualFold(modelName, parentName) {
		// does it implement (AllOf) the base class
		for _, parent := range value.AllOf {
			fragmentName := fragmentNameFromReference(parent.Ref)
			if fragmentName == nil {
				continue
			}

			if strings.EqualFold(*fragmentName, parentName) {
				implementsParent = true
				break
			}

			// otherwise does this model inherit from a model which does?
			item, err := c.findTopLevelObject(*fragmentName)
			if err != nil {
				return nil, fmt.Errorf("loading Parent %q: %+v", *fragmentName, err)
			}
			if len(item.AllOf) > 0 {
				inheritsFromParent, err := c.doesModelImplement(*fragmentName, *item, parentName)
				if err != nil {
					return nil, fmt.Errorf("determining if model %q implements %q: %+v", *fragmentName, parentName, err)
				}
				if *inheritsFromParent {
					implementsParent = true
					break
				}
			}
		}
	}

	return &implementsParent, nil
}

func (c *Context) findModelNamesWhichImplement(parentName string) (*[]string, error) {
	modelNames := make([]string, 0)

	for childName, value := range c.SwaggerSpecExtendedRaw.Definitions {
		implementsParent, err := c.doesModelImplement(childName, value, parentName)
		if err != nil {
			return nil, fmt.Errorf("determining if model %q implements %q: %+v", childName, parentName, err)
		}
		if !*implementsParent {
			continue
		}

		logging.Tracef("Found %q implements %q", childName, parentName)
		modelNames = append(modelNames, childName)
	}

	return &modelNames, nil
}
