package generator

import "fmt"

func definitionForResource(input ResourceInput) string {
	// TODO: outputting a `ResourceWithUpdate` if this is an Update too (by the update func?)
	// TODO: tests
	return fmt.Sprintf(`
// TODO: enable down the road
//var _ sdk.Resource = %[1]sResource{}

type %[1]sResource struct {}
`, input.ResourceTypeName)
}
