package generator

import (
	"fmt"
	"regexp"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-go-sdk/featureflags"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ templater = resourceId{}

type SegmentBatch struct {
	StartIdx int
	EndIdx   int
	Reverse  bool
}

type resourceId struct {
	name            string
	resource        resourcemanager.ResourceIdDefinition
	constantDetails map[string]resourcemanager.ConstantDetails
}

func (r resourceId) template(data ServiceGeneratorData) (*string, error) {
	parserData, err := r.generateParser(data.packageName)
	if err != nil {
		return nil, fmt.Errorf("while generating parser: %+v", err)
	}
	stringMethods, err := r.generateResourceStrings()
	if err != nil {
		return nil, fmt.Errorf("while generating code for %q/%q: %+v ", data.packageName, r.name, err)
	}
	out := fmt.Sprintf("%s\n%s", parserData, stringMethods)

	return &out, nil
}

func (r *resourceId) getSegmentBatches() (map[int]string, []SegmentBatch, error) {
	out := make([]SegmentBatch, 0)
	scopePositions := make(map[int]string, 0)
	prevIdx := -1

	segments := r.resource.Segments
	lastSegment := len(segments) - 1

	for idx, segment := range segments {
		if segment.Type != resourcemanager.ScopeSegment {
			continue
		}
		scopePositions[idx] = ":"
		var startIdx int
		startIdx = prevIdx
		if prevIdx == -1 {
			startIdx = 0
		}
		x := SegmentBatch{
			StartIdx: startIdx,
			EndIdx:   idx,
			Reverse:  prevIdx == 0,
		}
		if prevIdx > 0 && idx != lastSegment && len(out) > 1 {
			// the previous scope segment found was not at the beginning
			// the current scope segment is not at the end and,
			// we already found another scope segment in the middle of the Resource ID
			return nil, nil, fmt.Errorf("cannot handle multiple scope segments in the middle of the Id")
		}
		prevIdx = idx
		out = append(out, x)
	}

	if prevIdx < lastSegment {
		final := SegmentBatch{
			EndIdx:  lastSegment,
			Reverse: true,
		}
		final.StartIdx = prevIdx + 1
		if prevIdx == -1 {
			final.StartIdx = 0
		}
		out = append(out, final)
	}

	return scopePositions, out, nil
}

func (r *resourceId) generateSegments() (string, error) {
	// This is a fun one. Scope Segments have undefined size, so we need to infer their
	// size based on the positions of anything else.
	//
	// In order to do this we create "batches" of segments. Each batch is a slice of
	// ResourceIdSegment structs and the last item of each slice is a Scope segment.
	// Exceptions to the above are:
	//		- Scope segments that appear on the begginning of the slice
	//		- ???
	//
	// First we go over each segment that does not have a scope, figure out where every other segment sits,
	// and then we go over the scoped segments and assume the "gaps" between segments correspond to a
	// scoped segment.

	segments := r.resource.Segments
	snippets := make([]string, len(segments))
	scopePositions, segmentBatches, err := r.getSegmentBatches()
	if err != nil {
		return "", fmt.Errorf("while extracting segment batches: %+v", err)
	}

	for position, batch := range segmentBatches {
		if _, ok := scopePositions[position]; ok {
			// first we process the non scope batches
			// because we need to figure out their range
			continue
		}

		endIdx := batch.EndIdx - batch.StartIdx
		for x := 0; x <= endIdx; x++ {
			var segmentIdx int
			var idxStr string
			if batch.Reverse {
				segmentIdx = len(segments) - 1 - x
			} else {
				segmentIdx = x
			}
			idxStr = fmt.Sprintf(`idx = output.getIdx(numParts, %d, %t)`, x, batch.Reverse)
			snippet, err := r.processNonScopeSegment(segments[segmentIdx])
			if err != nil {
				return "", fmt.Errorf("while generating segment: %+v", err)
			}
			snippets[segmentIdx] = fmt.Sprintf("%s\n%s", idxStr, snippet)
		}

		if batch.StartIdx > 0 {
			positionIdx := batch.StartIdx - 1
			if _, ok := scopePositions[positionIdx]; ok {
				scopePositions[positionIdx] = fmt.Sprintf(`%d:len(parts) - 1 - %d`, positionIdx, endIdx)
			}
		}
	}

	for scopePosition, scIdx := range scopePositions {
		batch := segmentBatches[scopePosition]
		startIdx := batch.StartIdx
		endIdx := batch.EndIdx

		if scIdx == ":" {
			scIdx = "idx:1"
		}
		for x := startIdx; x <= endIdx; x++ {
			segmentIdx := getSegmentIdx(x, batch, len(segments))
			snippets[x] = fmt.Sprintf(`output.%s = strings.Join(parts[%s], separator)`, titleCase(segments[segmentIdx].Name), scIdx)
		}
	}
	return strings.Join(snippets, "\n"), nil
}

func (r *resourceId) processNonScopeSegment(segment resourcemanager.ResourceIdSegment) (string, error) {
	var snippet string
	var err error

	switch segment.Type {
	case resourcemanager.ResourceProviderSegment:
		snippet, err = handleProviderSegment(segment, r.name)
		if err != nil {
			return "", err
		}
	case resourcemanager.StaticSegment:
		snippet, err = handleStaticSegment(segment, r.name)
		if err != nil {
			return "", err
		}
	case resourcemanager.ConstantSegment:
		resourceConstant := r.constantDetails[*segment.ConstantReference]
		snippet, err = handleConstantSegment(segment, resourceConstant)
		if err != nil {
			return "", err
		}
	case resourcemanager.ResourceGroupSegment:
		fallthrough
	case resourcemanager.SubscriptionIdSegment:
		fallthrough
	case resourcemanager.UserSpecifiableSegment:
		snippet = fmt.Sprintf(`output.%s = parts[idx]`, titleCase(segment.Name))
	default:
		return "", fmt.Errorf("unknown segment type encountered: %+v", segment.Type)
	}
	return snippet, nil
}

func (r *resourceId) generateStructMemberMap() map[string]string {
	structMemberMap := make(map[string]string, 0)

	for _, segment := range r.resource.Segments {
		memberType := "string"
		switch segment.Type {
		case resourcemanager.ConstantSegment:
			if constant, ok := r.constantDetails[*segment.ConstantReference]; ok {
				if constant.Type == resourcemanager.IntegerConstant {
					memberType = "int64"
				} else if constant.Type == resourcemanager.FloatConstant {
					memberType = "float64"
				}
			}
			fallthrough
		case resourcemanager.ScopeSegment:
			fallthrough
		case resourcemanager.ResourceGroupSegment:
			fallthrough
		case resourcemanager.SubscriptionIdSegment:
			fallthrough
		case resourcemanager.UserSpecifiableSegment:
			structMemberMap[titleCase(segment.Name)] = memberType
		}
	}
	return structMemberMap
}

func (r *resourceId) generateStruct() string {
	structMemberMap := r.generateStructMemberMap()
	out := []string{"{"}
	for member, memberType := range structMemberMap {
		out = append(out, fmt.Sprintf("%s %s", member, memberType))
	}
	out = append(out, fmt.Sprintf("ResourceProvidersUsed []string"))
	out = append(out, "}")
	return strings.Join(out, "\n")
}

func (r *resourceId) generateNewFunction() string {
	re, _ := regexp.Compile("Id$")
	IDname := re.ReplaceAllString(titleCase(r.name), "ID")
	structMemberMap := r.generateStructMemberMap()
	out := make([]string, 0)
	names := make([]string, 0)

	// We need to preserve order, so we'll walk the segment list and pull the necessary keys/values from structMemberMap
	for _, segment := range r.resource.Segments {
		switch segment.Type {
		case resourcemanager.StaticSegment:
			fallthrough
		case resourcemanager.ResourceProviderSegment:
			continue
		default:
			k := titleCase(segment.Name)
			if v, ok := structMemberMap[k]; ok {
				names = append(names, fmt.Sprintf("%s %s", strings.ToLower(k), v))
				out = append(out, fmt.Sprintf("%s: %s,", k, strings.ToLower(k)))
			}
		}
	}

	out = append(out, "}\n}")
	out = append([]string{
		fmt.Sprintf(`func New%[1]s(%[2]s) %[3]s {`, IDname, strings.Join(names, ","), titleCase(r.name)),
		fmt.Sprintf("return %s {", titleCase(r.name)),
	}, out...)
	return strings.Join(out, "\n")
}

func (r *resourceId) generateParser(packageName string) (string, error) {
	re, _ := regexp.Compile("Id$")
	IDname := re.ReplaceAllString(r.name, "ID")
	minLength := len(r.resource.Segments)
	separator := "/"
	segments, err := r.generateSegments()
	if err != nil {
		return "", fmt.Errorf("while generating segments: %+v", err)
	}

	var scopedIdxSnippet string
	scopedIdxSnippet = fmt.Sprintf(`
func %[1]s(id string) (*%[2]s, error) {`, IDname, r.name)

	o := fmt.Sprintf(`
package %[1]s

import (
    "fmt"
    "regexp"	
    "strconv"
    "strings"

    "github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

var _ resourceids.Id = %[2]s{}

type %[2]s struct %[3]s

%[7]s
    // inputs
    minLength := %[4]d
    separator := %[5]q
    output := &%[2]s{}
    separatorRe := fmt.Sprintf("%%s+", separator)
    idx := 0


	// Remove duplicate separators
    re, err := regexp.Compile(separatorRe)
    if err != nil {
        return nil, fmt.Errorf("while compiling regexp %%q: %%+v", separatorRe, err)
    }
	id = re.ReplaceAllString(id, separator)
	if id[0] == '/' {
		id = id[1:]
	}

    parts := strings.Split(id, separator)


    numParts := len(parts)
    if numParts < minLength {
        return nil, fmt.Errorf("invalid length for id: %%q, expected to find at least %%d parts, found %%d", id, minLength, numParts)
    } else if numParts == 1 && parts[0] == "" {
		return nil, fmt.Errorf("empty url found")
    }

    %[6]s

    return output, nil
}

%[8]s
%[9]s
`, packageName, r.name, r.generateStruct(), minLength, separator, segments, scopedIdxSnippet, idxFunc(r.name), r.generateNewFunction())

	return o, nil
}

func (r *resourceId) getResourceMethods() (string, string, error) {
	output := make([]string, len(r.resource.Segments))
	vars := make([]string, 0)
	snippets := []string{
		`segments := []string {`,
	}

	for idx, segment := range r.resource.Segments {
		var snippetWorthy bool
		switch segment.Type {
		case resourcemanager.StaticSegment:
			fallthrough
		case resourcemanager.ResourceProviderSegment:
			output[idx] = *segment.FixedValue
		case resourcemanager.ResourceGroupSegment:
			fallthrough
		case resourcemanager.SubscriptionIdSegment:
			fallthrough
		case resourcemanager.ConstantSegment:
			fallthrough
		case resourcemanager.ScopeSegment:
			fallthrough
		case resourcemanager.UserSpecifiableSegment:
			snippetWorthy = true
			output[idx] = "%s"
			vars = append(vars, fmt.Sprintf(" r.%s", titleCase(segment.Name)))
		}
		if snippetWorthy {
			tmpStr := fmt.Sprintf(`
		fmt.Sprintf("%[1]s %%q", r.%[1]s),
`, titleCase(segment.Name))
			snippets = append(snippets, tmpStr)

		}
	}

	snippets = append(snippets, fmt.Sprintf(`}
	segmentsStr := strings.Join(segments, " / ")
	return fmt.Sprintf("%%q: (%%s)", %q, segmentsStr)`, r.name))

	url := fmt.Sprintf("/%s", strings.Join(output, "/"))

	strRepresentation := strings.Join(snippets, "\n")

	idMethodStr := fmt.Sprintf(`
	output := fmt.Sprintf("%[1]s", %[2]s)
    re, err := regexp.Compile("/+")
    if err != nil {
        return output
    }
	output = re.ReplaceAllString(output, "/")
	return output`, url, strings.Join(vars, ","))
	return idMethodStr, strRepresentation, nil
}

func (r *resourceId) generateResourceStrings() (string, error) {
	url, strRepr, err := r.getResourceMethods()
	if err != nil {
		return "", fmt.Errorf("while generating resource string methods")
	}
	return fmt.Sprintf(`
func (r %s) ID() string {
    %s    
}

func (r %s) String() string {
    %s
}

`, r.name, url, r.name, strRepr), nil
}

func titleCase(input string) string {
	if len(input) == 1 {
		return strings.ToUpper(input)
	}

	return fmt.Sprintf("%s%s", strings.ToUpper(input[:1]), input[1:])
}

func getSegmentIdx(curIdx int, batch SegmentBatch, totalSegments int) int {
	var segmentIdx int
	if batch.Reverse {
		segmentIdx = totalSegments - 1 - curIdx
	} else {
		segmentIdx = curIdx
	}
	return segmentIdx
}

func idxFunc(typeName string) string {
	return fmt.Sprintf(`
func (r %s) getIdx(total, idx int, reverse bool) int {
	if reverse {
		return total - 1 - idx
	}
	return idx
}
`, typeName)
}

func handleStaticSegment(segment resourcemanager.ResourceIdSegment, name string) (string, error) {
	if segment.FixedValue == nil {
		return "", fmt.Errorf("encountered an empty fixed value while processing a static segment. resource: %s, segment: %+v", name, segment)
	}

	var comparisonString string
	if featureflags.CaseSensitiveComparisons {
		comparisonString = fmt.Sprintf(`parts[idx] == %q`, *segment.FixedValue)
	} else {
		comparisonString = fmt.Sprintf(`!strings.EqualFold(parts[idx], %q)`, *segment.FixedValue)
	}
	return fmt.Sprintf(`
    if %s {
        return nil, fmt.Errorf("expected '%s' got %%q", parts[idx])
    }`, comparisonString, *segment.FixedValue), nil
}

func handleProviderSegment(segment resourcemanager.ResourceIdSegment, name string) (string, error) {
	provSnippet := "output.ResourceProvidersUsed = append(output.ResourceProvidersUsed, parts[idx])"
	snippet, err := handleStaticSegment(segment, name)
	if err != nil {
		return "", err
	}
	out := fmt.Sprintf("%s\n%s", snippet, provSnippet)
	return out, nil
}

func handleConstantSegment(segment resourcemanager.ResourceIdSegment, resourceConstant resourcemanager.ConstantDetails) (string, error) {
	enums := make([]string, 0)
	for k := range resourceConstant.Values {
		enums = append(enums, fmt.Sprintf("%q", k))
	}

	var valueSnippet string
	switch resourceConstant.Type {
	case resourcemanager.IntegerConstant:
		{
			valueSnippet = fmt.Sprintf(`
    num, err := strconv.ParseInt(parts[idx], 10, 64)
    if err != nil {
        return nil, fmt.Errorf("failed to parse %%q as integer: %%+v", parts[idx], err)
    }
    output.%s = num`, titleCase(segment.Name))
		}
	case resourcemanager.FloatConstant:
		{
			valueSnippet = fmt.Sprintf(`
    num, err := strconv.ParseFloat(parts[idx], 64)
    if err != nil {
        return nil, fmt.Errorf("failed to parse %%q as float: %%+v", parts[idx], err)
    }
    output.%s = num`, titleCase(segment.Name))
		}
	case resourcemanager.StringConstant:
		valueSnippet = fmt.Sprintf("output.%s = parts[idx]", titleCase(segment.Name))
	default:
		return "", fmt.Errorf("unsupported constant field type: %+v", resourceConstant.Type)
	}

	out := fmt.Sprintf(`
    found := false
    enums := []string{%s}
    for _, enum := range(enums) {
        if parts[idx] == enum {
            found = true
            break
        }
    }
    if !found {
        return nil, fmt.Errorf("%%q is not a valid %%q value, it can be one of %%q", parts[idx], parts[idx-1], strings.Join(enums, ","))
    }
    %s`, strings.Join(enums, ","), valueSnippet)
	return out, nil
}
