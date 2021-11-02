package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-go-sdk/featureflags"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ templater = resourceId{}

type resourceId struct {
	name            string
	resource        resourcemanager.ResourceIdDefinition
	constantDetails map[string]resourcemanager.ConstantDetails
}

func (r resourceId) template(data ServiceGeneratorData) (*string, error) {
	structBody, err := r.structBody()
	if err != nil {
		return nil, fmt.Errorf("generating struct body: %+v", err)
	}
	methods, err := r.methods(data)
	if err != nil {
		return nil, fmt.Errorf("generating methods: %+v", err)
	}

	out := fmt.Sprintf(`package %[1]s
import (
    "fmt"
    "regexp"	
    "strconv"
    "strings"

    "github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

%[2]s
%[3]s
`, data.packageName, *structBody, *methods)
	return &out, nil
}

func (r resourceId) structBody() (*string, error) {
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		segmentType := string(resourcemanager.StringConstant)
		switch segment.Type {
		case resourcemanager.StaticSegment:
			continue
		case resourcemanager.ResourceProviderSegment:
			continue
		case resourcemanager.ConstantSegment:
			if segment.ConstantReference == nil {
				return nil, fmt.Errorf("segment %q is a constant with no reference", segment.Name)
			}

			segmentType = *segment.ConstantReference
		}

		lines = append(lines, fmt.Sprintf("%s %s", strings.Title(segment.Name), segmentType))
	}

	out := fmt.Sprintf(`
var _ resourceids.ResourceId = %[1]s{}

type %[1]s struct {
%[2]s
}
`, r.name, strings.Join(lines, "\n"))
	return &out, nil
}

func (r resourceId) methods(data ServiceGeneratorData) (*string, error) {
	nameWithoutSuffix := strings.TrimSuffix(r.name, "Id")

	// NOTE: ordering is useful here for skimming the code, we do NewStruct -> Parse -> other Methods

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

	// Id function
	functionBody, err = r.idFunction(data)
	if err != nil {
		return nil, fmt.Errorf("generating ID function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// Segments function
	functionBody, err = r.segmentsFunction()
	if err != nil {
		return nil, fmt.Errorf("generating Segments function: %+v", err)
	}
	methods = append(methods, *functionBody)

	// String function
	functionBody, err = r.stringFunction(data)
	if err != nil {
		return nil, fmt.Errorf("generating String function: %+v", err)
	}
	methods = append(methods, *functionBody)

	out := strings.Join(methods, "\n\n")
	return &out, nil
}

func (r resourceId) idFunction(data ServiceGeneratorData) (*string, error) {
	fmtSegments := make([]string, 0)      // %s
	segmentArguments := make([]string, 0) // id.Foo
	for _, segment := range r.resource.Segments {

		switch segment.Type {
		case resourcemanager.ResourceProviderSegment, resourcemanager.StaticSegment:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("segment %q should have a static value but didn't get one", segment.Name)
				}
				fmtSegments = append(fmtSegments, *segment.FixedValue)
				continue
			}

		case resourcemanager.ConstantSegment:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("the constant segment %q has no reference", segment.Name)
				}

				// get the segment and determine the type
				constant, ok := data.constants[*segment.ConstantReference]
				if !ok {
					return nil, fmt.Errorf("the constant %q was not found in the data for segment %q", *segment.ConstantReference, segment.Name)
				}

				fmtVals := map[resourcemanager.ConstantType]string{
					resourcemanager.IntegerConstant: "%d",
					resourcemanager.FloatConstant:   "%f",
					resourcemanager.StringConstant:  "%s",
				}
				fmtVal, ok := fmtVals[constant.Type]
				if !ok {
					return nil, fmt.Errorf("constant type %q has no fmtVals mapping", string(constant.Type))
				}
				fmtSegments = append(fmtSegments, fmtVal)

				segmentType, err := golangTypeNameForConstantType(constant.Type)
				if err != nil {
					return nil, fmt.Errorf("for constant %q: %+v", err, err)
				}
				segmentArguments = append(segmentArguments, fmt.Sprintf("%s(id.%s)", *segmentType, strings.Title(segment.Name)))
			}

		default:
			{
				fmtSegments = append(fmtSegments, "%s")
				segmentArguments = append(segmentArguments, fmt.Sprintf("id.%s", strings.Title(segment.Name)))
			}
		}
	}

	// intentionally doing this and not using strings.Join to handle Scopes which are full Resource ID's
	fmtString := ""
	for _, v := range fmtSegments {
		if !strings.HasPrefix(v, "/") {
			fmtString += "/"
		}
		fmtString += v
	}

	segmentsString := strings.Join(segmentArguments, ", ")

	out := fmt.Sprintf(`
func (id %[1]s) ID() string {
	fmtString := %[2]q
	return fmt.Sprintf(fmtString, %[3]s)
}
`, r.name, fmtString, segmentsString)
	return &out, nil
}

func (r resourceId) newFunction(nameWithoutSuffix string) (*string, error) {
	arguments := make([]string, 0)
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.StaticSegment:
			fallthrough
		case resourcemanager.ResourceProviderSegment:
			continue

		case resourcemanager.ConstantSegment:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("segment %q is a constant without a reference", segment.Name)
				}

				arguments = append(arguments, fmt.Sprintf("%s %s", segment.Name, *segment.ConstantReference))
				lines = append(lines, fmt.Sprintf("%s: %s,", strings.Title(segment.Name), segment.Name))
			}

		case resourcemanager.ResourceGroupSegment, resourcemanager.ScopeSegment, resourcemanager.SubscriptionIdSegment, resourcemanager.UserSpecifiedSegment:
			{
				arguments = append(arguments, fmt.Sprintf("%s string", segment.Name))
				lines = append(lines, fmt.Sprintf("%s: %s,", strings.Title(segment.Name), segment.Name))
			}

		default:
			return nil, fmt.Errorf("unsupported segment type %q", string(segment.Type))
		}
	}

	out := fmt.Sprintf(`func New%[1]sID(%[3]s) %[2]s {
	return %[1]sId{
		%[4]s
	}
}`, nameWithoutSuffix, r.name, strings.Join(arguments, ", "), strings.Join(lines, "\n"))
	return &out, nil
}

func (r resourceId) parseFunction(nameWithoutSuffix string, caseSensitive bool) (*string, error) {
	functionName := fmt.Sprintf("Parse%[1]sID", nameWithoutSuffix)
	if !caseSensitive {
		functionName += "Insensitively"
	}

	lines := make([]string, 0)
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.ConstantSegment:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("constant segment %q has no reference", segment.Name)
				}

				lines = append(lines, fmt.Sprintf(`
	

	if v, constFound := parsed.Parsed[%[1]q]; true {
		if !constFound {
			return nil, fmt.Errorf("the segment '%[1]s' was not found in the resource id %%q", input)
		}

		%[1]s, err := parse%[3]s(v)
		if err != nil {
			return nil, fmt.Errorf("parsing %%q: %%+v", v, err)
		}
		id.%[2]s = *%[1]s
	}
`, segment.Name, strings.Title(segment.Name), *segment.ConstantReference))
				continue
			}

		case resourcemanager.ResourceGroupSegment, resourcemanager.ScopeSegment, resourcemanager.SubscriptionIdSegment, resourcemanager.UserSpecifiedSegment:
			{
				lines = append(lines, fmt.Sprintf(`
	if id.%[2]s, ok = parsed.Parsed[%[1]q]; !ok {
		return nil, fmt.Errorf("the segment '%[1]s' was not found in the resource id %%q", input)
	}
`, segment.Name, strings.Title(segment.Name)))
				continue
			}

		default:
			continue
		}
	}

	out := fmt.Sprintf(`func %[1]s(input string) (*%[2]s, error) {
	parser := resourceids.NewParserFromResourceIdType(%[2]s{})
	parsed, err := parser.Parse(input, %[3]t)
	if err != nil {
		return nil, fmt.Errorf("parsing %%q: %%+v", input, err)
	}

	var ok bool
	id := %[2]s{}

	%[4]s

	return &id, nil
}`, functionName, r.name, !caseSensitive, strings.Join(lines, "\n"))
	return &out, nil
}

func (r resourceId) segmentsFunction() (*string, error) {
	lines := make([]string, 0)

	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.ConstantSegment:
			{
				if segment.ConstantReference == nil {
					return nil, fmt.Errorf("constant segment %q had no reference", segment.Name)
				}
				lines = append(lines, fmt.Sprintf("resourceids.ConstantSegment(%q, PossibleValuesFor%[2]s(), %q),", segment.Name, *segment.ConstantReference, segment.ExampleValue))
				continue
			}
		case resourcemanager.ResourceGroupSegment:
			{
				lines = append(lines, fmt.Sprintf("resourceids.ResourceGroupSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case resourcemanager.ResourceProviderSegment:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("resource provider segment %q had no value", segment.Name)
				}

				lines = append(lines, fmt.Sprintf("resourceids.ResourceProviderSegment(%q, %q, %q),", segment.Name, *segment.FixedValue, segment.ExampleValue))
				continue
			}
		case resourcemanager.ScopeSegment:
			{
				lines = append(lines, fmt.Sprintf("resourceids.ScopeSegment(%q),", segment.Name))
				continue
			}
		case resourcemanager.StaticSegment:
			{
				if segment.FixedValue == nil {
					return nil, fmt.Errorf("static segment %q had no value", segment.Name)
				}

				lines = append(lines, fmt.Sprintf("resourceids.StaticSegment(%q, %q, %q),", segment.Name, *segment.FixedValue, segment.ExampleValue))
				continue
			}
		case resourcemanager.SubscriptionIdSegment:
			{
				lines = append(lines, fmt.Sprintf("resourceids.SubscriptionIdSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}
		case resourcemanager.UserSpecifiedSegment:
			{
				lines = append(lines, fmt.Sprintf("resourceids.UserSpecifiedSegment(%q, %q),", segment.Name, segment.ExampleValue))
				continue
			}

		default:
			return nil, fmt.Errorf("unimplemented segment type %q", string(segment.Type))
		}
	}

	out := fmt.Sprintf(`
func (id %[1]s) Segments() []resourceids.Segment {
	return []resourceids.Segment{
		%[2]s
	}
}
`, r.name, strings.Join(lines, "\n"))
	return &out, nil
}

func (r resourceId) stringFunction(data ServiceGeneratorData) (*string, error) {
	componentsLines := make([]string, 0)
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.ResourceProviderSegment, resourcemanager.StaticSegment:
			continue

		case resourcemanager.ConstantSegment:
			if segment.ConstantReference == nil {
				return nil, fmt.Errorf("segment %q is a constant without a reference", segment.Name)
			}
			constant, ok := data.constants[*segment.ConstantReference]
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
	out := fmt.Sprintf(`func (id %[1]s) String() string {
	components := []string{
		%[2]s
	}
	return fmt.Sprintf("%[3]s (%%s)", strings.Join(components, "\n"))  
}`, r.name, strings.Join(componentsLines, "\n"), wordifiedName)
	return &out, nil
}

func golangTypeNameForConstantType(input resourcemanager.ConstantType) (*string, error) {
	segmentTypes := map[resourcemanager.ConstantType]string{
		resourcemanager.IntegerConstant: "int64",
		resourcemanager.FloatConstant:   "float64",
		resourcemanager.StringConstant:  "string",
	}
	segmentType, ok := segmentTypes[input]
	if !ok {
		return nil, fmt.Errorf("constant type %q has no segmentTypes mapping", string(input))
	}
	return &segmentType, nil
}

// wordifyString takes an input PascalCased string and converts it to a more human-friendly variant
// e.g. `ApplicationGroupId` -> `Application Group`
func wordifyString(input string) string {
	val := strings.Title(input)
	val = strings.TrimSuffix(val, "Id")
	output := ""

	for _, c := range val {
		character := string(c)
		if strings.ToUpper(character) == character {
			output += " "
		}
		output += character
	}

	return strings.TrimPrefix(output, " ")
}
