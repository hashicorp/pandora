package generator

import "fmt"

func packageTestDefinitionForResource(input ResourceInput) string {
	return fmt.Sprintf("package %s_test", input.ServicePackageName)
}
