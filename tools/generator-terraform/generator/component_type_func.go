package generator

import "fmt"

func typeFuncForResource(input ResourceInput) string {
	// TODO: tests
	return fmt.Sprintf(`
func (r %[1]sResource) ResourceType() string {
	return "%[2]s_%[3]s"
}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel)
}
