package generator

import (
	"fmt"
	"slices"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/featureflags"
)

// TODO: add unit tests covering this

var _ templaterForResource = &resourceIdTemplater{}

type resourceIdTemplater struct {
	name            string
	resource        models.ResourceID
	constantDetails map[string]models.SDKConstant
}

func (r *resourceIdTemplater) template(data GeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	if data.sourceType == models.DataPlaneSourceDataType {
		r.resource.Segments = slices.Insert(r.resource.Segments, 0, models.ResourceIDSegment{
			ExampleValue: "https://endpoint-url.example.com",
			Type:         models.DataPlaneBaseURLResourceIDSegmentType,
			Name:         "baseURI",
		})
	}

	structBody, err := r.structBody()
	if err != nil {
		return nil, fmt.Errorf("generating struct body: %+v", err)
	}
	methods, err := r.methods(data.sourceType)
	if err != nil {
		return nil, fmt.Errorf("generating methods: %+v", err)
	}

	registerId := ""
	if !data.isDataPlane {
		registerId = r.registerId()
	}

	out := fmt.Sprintf(`package %[1]s
import (
    "fmt"
    "regexp"	
    "strconv"
    "strings"

    "github.com/hashicorp/go-azure-helpers/resourcemanager/recaser"
    "github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

%[2]s
%[3]s
%[4]s
%[5]s
`, data.packageName, *copyrightLines, registerId, *structBody, *methods)
	return &out, nil
}

func (r *resourceIdTemplater) structBody() (*string, error) {
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		segmentType := "string"
		switch segment.Type {
		case models.StaticResourceIDSegmentType:
			continue
		case models.ResourceProviderResourceIDSegmentType:
			continue
		case models.ConstantResourceIDSegmentType:
			if segment.ConstantReference == nil {
				return nil, fmt.Errorf("segment %q is a constant with no reference", segment.Name)
			}

			segmentType = *segment.ConstantReference
		}

		lines = append(lines, fmt.Sprintf("%s %s", strings.Title(segment.Name), segmentType))
	}

	wordifiedName := wordifyString(r.name)
	out := fmt.Sprintf(`
var _ resourceids.ResourceId = &%[1]s{}

// %[1]s is a struct representing the Resource ID for a %[3]s
type %[1]s struct {
%[2]s
}
`, r.name, strings.Join(lines, "\n"), wordifiedName)
	return &out, nil
}

func (r *resourceIdTemplater) registerId() string {
	wordifiedName := wordifyString(r.name)
	return fmt.Sprintf(`
	func init() {
		recaser.RegisterResourceId(&%[2]s{})
	}
`, wordifiedName, r.name)
}

func (r *resourceIdTemplater) methods(sourceType models.SourceDataType) (*string, error) {
	nameWithoutSuffix := strings.TrimSuffix(r.name, "Id")

	// NOTE: ordering is useful here for skimming the code, we do Public -> Private
	//	e.g. Struct -> NewStruct -> Parse -> Validate -> other Methods

	methods := make([]string, 0)

	// New{ID} function
	functionBody, err := r.newFunction(nameWithoutSuffix)
	if err != nil {
		return nil, fmt.Errorf("generating the New function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// case-sensitive parse function
	functionBody, err = r.parseFunction(nameWithoutSuffix, true)
	if err != nil {
		return nil, fmt.Errorf("generating the case-sensitive function: %+v", err)
	}
	methods = append(methods, *functionBody)

	if featureflags.GenerateCaseInsensitiveFunctions {
		// case-insensitive parse function
		functionBody, err := r.parseFunction(nameWithoutSuffix, false)
		if err != nil {
			return nil, fmt.Errorf("generating the case-insensitive function: %+v", err)
		}

		methods = append(methods, *functionBody)
	}

	functionBody, err = r.fromParseResultFunction(r.resource.Segments)
	if err != nil {
		return nil, fmt.Errorf("generating the fromParseResult function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// Validate function
	methods = append(methods, r.validateFunction(nameWithoutSuffix))

	// Id function
	functionBody, err = r.idFunction(sourceType)
	if err != nil {
		return nil, fmt.Errorf("generating ID function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// Data Plane Path function
	if sourceType == models.DataPlaneSourceDataType {
		functionBody, err = r.pathFunction()
		if err != nil {
			return nil, fmt.Errorf("generating Path function: %+v", err)
		}
		methods = append(methods, *functionBody)
		functionBody, err = r.pathElementsFunction()
		if err != nil {
			return nil, fmt.Errorf("generating PathElements function: %+v", err)
		}
		methods = append(methods, *functionBody)
	}

	// Segments function
	functionBody, err = r.segmentsFunction()
	if err != nil {
		return nil, fmt.Errorf("generating Segments function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// String function
	functionBody, err = r.stringFunction()
	if err != nil {
		return nil, fmt.Errorf("generating String function: %+v", err)
	}
	methods = append(methods, *functionBody)

	out := strings.Join(methods, "\n\n")
	return &out, nil
}

func (r *resourceIdTemplater) idFunction(sourceType models.SourceDataType) (*string, error) {
	fmtSegments := make([]string, 0)      // %s
	segmentArguments := make([]string, 0) // id.Foo
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case models.ResourceProviderResourceIDSegmentType, models.StaticResourceIDSegmentType:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("segment %q should have a static value but didn't get one", segment.Name)
				}
				fmtSegments = append(fmtSegments, *segment.FixedValue)
				continue
			}

		case models.ConstantResourceIDSegmentType:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("the constant segment %q has no reference", segment.Name)
				}

				// get the segment and determine the type
				constant, ok := r.constantDetails[*segment.ConstantReference]
				if !ok {
					return nil, fmt.Errorf("the constant %q was not found in the data for segment %q", *segment.ConstantReference, segment.Name)
				}

				fmtVals := map[models.SDKConstantType]string{
					models.FloatSDKConstantType:   "%f",
					models.IntegerSDKConstantType: "%d",
					models.StringSDKConstantType:  "%s",
				}
				fmtVal, ok := fmtVals[constant.Type]
				if !ok {
					return nil, fmt.Errorf("constant type %q has no fmtVals mapping", string(constant.Type))
				}
				fmtSegments = append(fmtSegments, fmtVal)

				segmentType, err := golangTypeNameForConstantType(constant.Type)
				if err != nil {
					return nil, fmt.Errorf("determining golang type name for constant type %q: %+v", constant.Type, err)
				}
				segmentArguments = append(segmentArguments, fmt.Sprintf("%s(id.%s)", *segmentType, strings.Title(segment.Name)))
			}

		case models.ScopeResourceIDSegmentType:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("strings.TrimPrefix(id.%s, \"/\")", strings.Title(segment.Name)))
			}

		case models.DataPlaneBaseURLResourceIDSegmentType:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("strings.TrimSuffix(id.%s, \"/\")", strings.Title(segment.Name)))
			}

		default:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("id.%s", strings.Title(segment.Name)))
			}
		}
	}

	// intentionally doing this and not using strings.Join to handle Scopes which are full Resource ID's
	fmtString := urlFromSegments(fmtSegments, sourceType == models.DataPlaneSourceDataType)
	segmentsString := strings.Join(segmentArguments, ", ")
	wordifiedName := wordifyString(r.name)

	out := fmt.Sprintf(`
// ID returns the formatted %[4]s ID
func (id %[1]s) ID() string {
	fmtString := %[2]q
	return fmt.Sprintf(fmtString, %[3]s)
}
`, r.name, fmtString, segmentsString, wordifiedName)
	return &out, nil
}

func (r *resourceIdTemplater) pathFunction() (*string, error) {
	fmtSegments := make([]string, 0)      // %s
	segmentArguments := make([]string, 0) // id.Foo
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case models.ResourceProviderResourceIDSegmentType, models.StaticResourceIDSegmentType:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("segment %q should have a static value but didn't get one", segment.Name)
				}
				fmtSegments = append(fmtSegments, *segment.FixedValue)
				continue
			}

		case models.ConstantResourceIDSegmentType:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("the constant segment %q has no reference", segment.Name)
				}

				// get the segment and determine the type
				constant, ok := r.constantDetails[*segment.ConstantReference]
				if !ok {
					return nil, fmt.Errorf("the constant %q was not found in the data for segment %q", *segment.ConstantReference, segment.Name)
				}

				fmtVals := map[models.SDKConstantType]string{
					models.FloatSDKConstantType:   "%f",
					models.IntegerSDKConstantType: "%d",
					models.StringSDKConstantType:  "%s",
				}
				fmtVal, ok := fmtVals[constant.Type]
				if !ok {
					return nil, fmt.Errorf("constant type %q has no fmtVals mapping", string(constant.Type))
				}
				fmtSegments = append(fmtSegments, fmtVal)

				segmentType, err := golangTypeNameForConstantType(constant.Type)
				if err != nil {
					return nil, fmt.Errorf("determining golang type name for constant type %q: %+v", constant.Type, err)
				}
				segmentArguments = append(segmentArguments, fmt.Sprintf("%s(id.%s)", *segmentType, strings.Title(segment.Name)))
			}

		case models.ScopeResourceIDSegmentType:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("strings.TrimPrefix(id.%s, \"/\")", strings.Title(segment.Name)))
			}

		case models.DataPlaneBaseURLResourceIDSegmentType:

		default:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("id.%s", strings.Title(segment.Name)))
			}
		}
	}

	// intentionally doing this and not using strings.Join to handle Scopes which are full Resource ID's
	fmtString := urlFromSegments(fmtSegments, false)
	segmentsString := strings.Join(segmentArguments, ", ")
	wordifiedName := wordifyString(r.name)

	out := fmt.Sprintf(`
// Path returns the formatted %[4]s ID without the BaseURI
func (id %[1]s) Path() string {
	fmtString := %[2]q
	return fmt.Sprintf(fmtString, %[3]s)
}
`, r.name, fmtString, segmentsString, wordifiedName)
	return &out, nil
}

func (r *resourceIdTemplater) pathElementsFunction() (*string, error) {
	fmtSegments := make([]string, 0)      // %s
	segmentArguments := make([]string, 0) // id.Foo
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case models.ResourceProviderResourceIDSegmentType, models.StaticResourceIDSegmentType:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("segment %q should have a static value but didn't get one", segment.Name)
				}
				fmtSegments = append(fmtSegments, *segment.FixedValue)
				continue
			}

		case models.ConstantResourceIDSegmentType:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("the constant segment %q has no reference", segment.Name)
				}

				// get the segment and determine the type
				constant, ok := r.constantDetails[*segment.ConstantReference]
				if !ok {
					return nil, fmt.Errorf("the constant %q was not found in the data for segment %q", *segment.ConstantReference, segment.Name)
				}

				fmtVals := map[models.SDKConstantType]string{
					models.FloatSDKConstantType:   "%f",
					models.IntegerSDKConstantType: "%d",
					models.StringSDKConstantType:  "%s",
				}
				fmtVal, ok := fmtVals[constant.Type]
				if !ok {
					return nil, fmt.Errorf("constant type %q has no fmtVals mapping", string(constant.Type))
				}
				fmtSegments = append(fmtSegments, fmtVal)

				segmentType, err := golangTypeNameForConstantType(constant.Type)
				if err != nil {
					return nil, fmt.Errorf("determining golang type name for constant type %q: %+v", constant.Type, err)
				}
				segmentArguments = append(segmentArguments, fmt.Sprintf("%s(id.%s)", *segmentType, strings.Title(segment.Name)))
			}

		case models.ScopeResourceIDSegmentType:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("strings.TrimPrefix(id.%s, \"/\")", strings.Title(segment.Name)))
			}

		case models.DataPlaneBaseURLResourceIDSegmentType:

		default:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("id.%s", strings.Title(segment.Name)))
			}
		}
	}

	// intentionally doing this and not using strings.Join to handle Scopes which are full Resource ID's
	// segmentsString := strings.Join(segmentArguments, ", ")
	wordifiedName := wordifyString(r.name)

	out := fmt.Sprintf(`
// PathElements returns the values of %[3]s ID Segments without the BaseURI
func (id %[1]s) PathElements() []any {
	return []any{%3s}
}
`, r.name, strings.Join(segmentArguments, ", "), wordifiedName)
	return &out, nil
}

func (r *resourceIdTemplater) newFunction(nameWithoutSuffix string) (*string, error) {
	arguments := make([]string, 0)
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case models.StaticResourceIDSegmentType:
			fallthrough
		case models.ResourceProviderResourceIDSegmentType:
			continue

		case models.ConstantResourceIDSegmentType:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("segment %q is a constant without a reference", segment.Name)
				}

				arguments = append(arguments, fmt.Sprintf("%s %s", segment.Name, *segment.ConstantReference))
				lines = append(lines, fmt.Sprintf("%s: %s,", strings.Title(segment.Name), segment.Name))
			}

		case models.ResourceGroupResourceIDSegmentType, models.ScopeResourceIDSegmentType, models.SubscriptionIDResourceIDSegmentType, models.UserSpecifiedResourceIDSegmentType:
			{
				arguments = append(arguments, fmt.Sprintf("%s string", segment.Name))
				lines = append(lines, fmt.Sprintf("%s: %s,", strings.Title(segment.Name), segment.Name))
			}

		case models.DataPlaneBaseURLResourceIDSegmentType:
			{
				arguments = append(arguments, fmt.Sprintf("%s string", segment.Name))
				lines = append(lines, fmt.Sprintf("%s: %s,", strings.Title(segment.Name), fmt.Sprintf(`strings.TrimSuffix(%s, "/")`, segment.Name)))
			}

		default:
			return nil, fmt.Errorf("unsupported segment type %q", string(segment.Type))
		}
	}

	out := fmt.Sprintf(`
// New%[1]sID returns a new %[2]s struct 
func New%[1]sID(%[3]s) %[2]s {
	return %[1]sId{
		%[4]s
	}
}`, nameWithoutSuffix, r.name, strings.Join(arguments, ", "), strings.Join(lines, "\n"))
	return &out, nil
}

func (r *resourceIdTemplater) parseFunction(nameWithoutSuffix string, caseSensitive bool) (*string, error) {
	functionName := fmt.Sprintf("Parse%[1]sID", nameWithoutSuffix)
	if !caseSensitive {
		functionName += "Insensitively"
	}

	description := fmt.Sprintf("// %[1]s parses 'input' into a %[2]s", functionName, r.name)
	if !caseSensitive {
		description = fmt.Sprintf(`
// %[1]s parses 'input' case-insensitively into a %[2]s
// note: this method should only be used for API response data and not user input`, functionName, r.name)
	}

	out := fmt.Sprintf(`%[4]s
func %[1]s(input string) (*%[2]s, error) {
	parser := resourceids.NewParserFromResourceIdType(&%[2]s{})
	parsed, err := parser.Parse(input, %[3]t)
	if err != nil {
		return nil, fmt.Errorf("parsing %%q: %%+v", input, err)
	}

	id := %[2]s{}
	if err = id.FromParseResult(*parsed); err != nil {
			return nil, err
	}

	return &id, nil
}`, functionName, r.name, !caseSensitive, description)
	return &out, nil
}

func (r *resourceIdTemplater) fromParseResultFunction(segments []models.ResourceIDSegment) (*string, error) {

	lines := make([]string, 0)
	varDeclaration := ""
	for _, segment := range segments {
		switch segment.Type {
		case models.ConstantResourceIDSegmentType:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("constant segment %q has no reference", segment.Name)
				}

				lines = append(lines, fmt.Sprintf(`

	if v, ok := input.Parsed[%[1]q]; true {
		if !ok {
			return resourceids.NewSegmentNotSpecifiedError(id, %[1]q, input)
		}

		%[1]s, err := parse%[3]s(v)
		if err != nil {
			return fmt.Errorf("parsing %%q: %%+v", v, err)
		}
		id.%[2]s = *%[1]s
	}
`, segment.Name, strings.Title(segment.Name), *segment.ConstantReference))
				continue
			}

		case models.ResourceGroupResourceIDSegmentType, models.ScopeResourceIDSegmentType, models.SubscriptionIDResourceIDSegmentType, models.UserSpecifiedResourceIDSegmentType, models.DataPlaneBaseURLResourceIDSegmentType:
			{
				lines = append(lines, fmt.Sprintf(`
	if id.%[2]s, ok = input.Parsed[%[1]q]; !ok {
		return resourceids.NewSegmentNotSpecifiedError(id, %[1]q, input)
	}
`, segment.Name, strings.Title(segment.Name)))

				varDeclaration = "var ok bool"

				continue
			}

		default:
			continue
		}
	}
	out := fmt.Sprintf(`func (id *%[1]s) FromParseResult(input resourceids.ParseResult) error {
    %[2]s

	%[3]s
    return nil
}`, r.name, varDeclaration, strings.Join(lines, "\n"))

	return &out, nil
}

func (r *resourceIdTemplater) segmentsFunction() (*string, error) {
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case models.ConstantResourceIDSegmentType:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("constant segment %q had no reference", segment.Name)
				}
				lines = append(lines, fmt.Sprintf("resourceids.ConstantSegment(%q, PossibleValuesFor%[2]s(), %q),", segment.Name, *segment.ConstantReference, segment.ExampleValue))
				continue
			}
		case models.ResourceGroupResourceIDSegmentType:
			{
				lines = append(lines, fmt.Sprintf("resourceids.ResourceGroupSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case models.ResourceProviderResourceIDSegmentType:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("resource provider segment %q had no value", segment.Name)
				}

				lines = append(lines, fmt.Sprintf("resourceids.ResourceProviderSegment(%q, %q, %q),", segment.Name, *segment.FixedValue, segment.ExampleValue))
				continue
			}
		case models.ScopeResourceIDSegmentType:
			{
				lines = append(lines, fmt.Sprintf("resourceids.ScopeSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case models.DataPlaneBaseURLResourceIDSegmentType:
			{
				lines = append(lines, fmt.Sprintf("resourceids.DataPlaneBaseURISegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case models.StaticResourceIDSegmentType:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("static segment %q had no value", segment.Name)
				}

				lines = append(lines, fmt.Sprintf("resourceids.StaticSegment(%q, %q, %q),", segment.Name, *segment.FixedValue, segment.ExampleValue))
				continue
			}
		case models.SubscriptionIDResourceIDSegmentType:
			{
				lines = append(lines, fmt.Sprintf("resourceids.SubscriptionIdSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case models.UserSpecifiedResourceIDSegmentType:
			{
				lines = append(lines, fmt.Sprintf("resourceids.UserSpecifiedSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}

		default:
			return nil, fmt.Errorf("unimplemented segment type %q", string(segment.Type))
		}
	}

	wordifiedName := wordifyString(r.name)
	out := fmt.Sprintf(`
// Segments returns a slice of Resource ID Segments which comprise this %[3]s ID
func (id %[1]s) Segments() []resourceids.Segment {
	return []resourceids.Segment{
		%[2]s
	}
}
`, r.name, strings.Join(lines, "\n"), wordifiedName)
	return &out, nil
}

func (r *resourceIdTemplater) stringFunction() (*string, error) {
	componentsLines := make([]string, 0)
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case models.ResourceProviderResourceIDSegmentType, models.StaticResourceIDSegmentType:
			continue

		case models.ConstantResourceIDSegmentType:
			if segment.ConstantReference == nil {
				return nil, fmt.Errorf("segment %q is a constant without a reference", segment.Name)
			}
			constant, ok := r.constantDetails[*segment.ConstantReference]
			if !ok {
				return nil, fmt.Errorf("the constant %q for segment %q was not found in the data", *segment.ConstantReference, segment.Name)
			}

			typeName, err := golangTypeNameForConstantType(constant.Type)
			if err != nil {
				return nil, fmt.Errorf("for constant %q: %+v", segment.Name, err)
			}
			// e.g.
			// components = append(components, fmt.Sprintf("SomeVal: string(%s)", id.SomeVal)
			componentsLines = append(componentsLines, fmt.Sprintf(`fmt.Sprintf("%[1]s: %%q", %[2]s(id.%[3]s)),`, wordifyString(segment.Name), *typeName, strings.Title(segment.Name)))

		default:
			// e.g.
			// components = append(components, fmt.Sprintf("SomeVal: %q", id.SomeVal)
			componentsLines = append(componentsLines, fmt.Sprintf(`fmt.Sprintf("%[1]s: %%q", id.%[2]s),`, wordifyString(segment.Name), strings.Title(segment.Name)))
		}
	}

	wordifiedName := wordifyString(r.name)
	out := fmt.Sprintf(`
// String returns a human-readable description of this %[3]s ID
func (id %[1]s) String() string {
	components := []string{
		%[2]s
	}
	return fmt.Sprintf("%[3]s (%%s)", strings.Join(components, "\n"))  
}`, r.name, strings.Join(componentsLines, "\n"), wordifiedName)
	return &out, nil
}

func (r *resourceIdTemplater) validateFunction(nameWithoutSuffix string) string {
	wordifiedName := wordifyString(r.name)
	return fmt.Sprintf(`
// Validate%[1]sID checks that 'input' can be parsed as a %[2]s ID
func Validate%[1]sID(input interface{}, key string) (warnings []string, errors []error) {
	v, ok := input.(string)
	if !ok {
		errors = append(errors, fmt.Errorf("expected %%q to be a string", key))
		return
	}

	if _, err := Parse%[1]sID(v); err != nil {
		errors = append(errors, err)
	}

	return
}
`, nameWithoutSuffix, wordifiedName)
}
