package resource

import "fmt"

func packageDefinitionForResource(input ResourceInput) string {
	return fmt.Sprintf("package %s", input.ServicePackageName)
}
