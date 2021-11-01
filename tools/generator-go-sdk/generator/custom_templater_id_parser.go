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
	stringMethods := r.getResourceMethods()

	out := fmt.Sprintf("%s\n%s", parserData, stringMethods)

	return &out, nil
}

func (r *resourceId) getSegmentBatches() (map[int]string, *[]SegmentBatch, error) {
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

	return scopePositions, &out, nil
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

	if segmentBatches == nil {
		return "", nil
	}
	batches := *segmentBatches

	for position, batch := range batches {
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
			idxStr = fmt.Sprintf(`idx = ap.GetIdx(ap.NumParts, %d, %t)`, x, batch.Reverse)
			snippet, err := r.processNonScopeSegment(segments[segmentIdx])
			if err != nil {
				return "", fmt.Errorf("while generating segment: %+v", err)
			}
			snippets[segmentIdx] = fmt.Sprintf("%s\n%s\n", idxStr, snippet)
		}

		if batch.StartIdx > 0 {
			positionIdx := batch.StartIdx - 1
			if _, ok := scopePositions[positionIdx]; ok {
				scopePositions[positionIdx] = fmt.Sprintf(`%d:len(ap.Parts) - 1 - %d`, positionIdx, endIdx)
			}
		}
	}

	for scopePosition, scIdx := range scopePositions {
		batch := batches[scopePosition]
		startIdx := batch.StartIdx
		endIdx := batch.EndIdx

		if scIdx == ":" {
			scIdx = "idx:1"
		}
		for x := startIdx; x <= endIdx; x++ {
			segmentIdx := getSegmentIdx(x, batch, len(segments))
			snippets[x] = fmt.Sprintf(`output.%s = strings.Join(ap.Parts[%s], ap.Separator)`, strings.Title(segments[segmentIdx].Name), scIdx)
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
	case resourcemanager.UserSpecifiedSegment:
		snippet = fmt.Sprintf(`output.%s = ap.Parts[idx]`, strings.Title(segment.Name))
	default:
		return "", fmt.Errorf("unknown segment type encountered: %+v", segment.Type)
	}
	return snippet, nil
}

func (r *resourceId) generateStructMemberMap() map[string]string {
	structMemberMap := make(map[string]string, 0)

	for _, segment := range r.resource.Segments {
		segmentType := string(resourcemanager.StringConstant)
		switch segment.Type {
		case resourcemanager.StaticSegment:
			fallthrough
		case resourcemanager.ResourceProviderSegment:
			continue
		case resourcemanager.ConstantSegment:
			if constant, ok := r.constantDetails[*segment.ConstantReference]; ok {
				segmentType = string(constant.Type)
			}
		}
		structMemberMap[strings.Title(segment.Name)] = segmentType
	}
	return structMemberMap
}

func (r *resourceId) generateStruct() string {
	structMemberMap := r.generateStructMemberMap()
	structMembers := make([]string, 0)
	for member, memberType := range structMemberMap {
		structMembers = append(structMembers, fmt.Sprintf("%s %s", member, memberType))
	}
	return fmt.Sprintf(`{
		ResourceProvidersUsed []string
		%s
	}`, strings.Join(structMembers, "\n"))
}

func (r *resourceId) generateNewFunction() string {
	re, _ := regexp.Compile("Id$")
	IDname := re.ReplaceAllString(strings.Title(r.name), "ID")
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
			k := strings.Title(segment.Name)
			if v, ok := structMemberMap[k]; ok {
				names = append(names, fmt.Sprintf("%s %s", segment.Name, v))
				out = append(out, fmt.Sprintf("%s: %s,", k, segment.Name))
			}
		}
	}

	out = append(out, "}\n}")
	out = append([]string{
		fmt.Sprintf(`func New%[1]s(%[2]s) %[3]s {`, IDname, strings.Join(names, ","), strings.Title(r.name)),
		fmt.Sprintf("return %s {", strings.Title(r.name)),
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
    output := &%[2]s{}
	apConfig := AzureParserConfig{
		MinLength: %[4]d,
		Separator: %[5]q,
	}
	ap, err := NewAzureParser(apConfig, id)
	if err != nil {
		return nil, fmt.Errorf("while initialising AzureParser: %%+v", err)
	}
	idx := 0

    %[6]s

    return output, nil
}

%[8]s
`, packageName, r.name, r.generateStruct(), minLength, separator, segments, scopedIdxSnippet, r.generateNewFunction())

	return o, nil
}

func (r *resourceId) getResourceMethods() string {
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
		case resourcemanager.UserSpecifiedSegment:
			snippetWorthy = true
			output[idx] = "%s"
			vars = append(vars, fmt.Sprintf(" r.%s", strings.Title(segment.Name)))
		}
		if snippetWorthy {
			tmpStr := fmt.Sprintf(`fmt.Sprintf("%%s %%q", ExtractNameFromTitleCase(r.%[1]s), r.%[1]s),`, strings.Title(segment.Name))
			snippets = append(snippets, tmpStr)
		}
	}

	snippets = append(snippets, fmt.Sprintf(`}
	segmentsStr := strings.Join(segments, " / ")
	return fmt.Sprintf("%%q: (%%s)", ExtractNameFromTitleCase(%q), segmentsStr)`, r.name))

	strRepresentation := strings.Join(snippets, "\n")

	strFunc := fmt.Sprintf(`func (r %s) String() string {
    %s    
}`, r.name, strRepresentation)

	url := fmt.Sprintf("/%s", strings.Join(output, "/"))
	idMethodStr := fmt.Sprintf(`output := fmt.Sprintf("%[1]s", %[2]s)
    re, err := regexp.Compile("/+")
    if err != nil {
        return output
    }
	output = re.ReplaceAllString(output, "/")
	return output`, url, strings.Join(vars, ","))
	idFunc := fmt.Sprintf(`func (r %s) ID() string {
    %s    
}`, r.name, idMethodStr)

	final := fmt.Sprintf("%s\n\n%s", idFunc, strFunc)
	return final
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

func handleStaticSegment(segment resourcemanager.ResourceIdSegment, name string) (string, error) {
	if segment.FixedValue == nil {
		return "", fmt.Errorf("encountered an empty fixed value while processing a static segment. resource: %s, segment: %+v", name, segment)
	}

	comparisonString := getComparisonString(*segment.FixedValue, false)
	return fmt.Sprintf(`
    if %s {
        return nil, fmt.Errorf("expected '%s' got %%q", ap.Parts[idx])
    }`, comparisonString, *segment.FixedValue), nil
}

func handleProviderSegment(segment resourcemanager.ResourceIdSegment, name string) (string, error) {
	provSnippet := "output.ResourceProvidersUsed = append(output.ResourceProvidersUsed, ap.Parts[idx])"
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
    num, err := strconv.ParseInt(ap.Parts[idx], 10, 64)
    if err != nil {
        return nil, fmt.Errorf("failed to parse %%q as integer: %%+v", ap.Parts[idx], err)
    }
    output.%s = num`, strings.Title(segment.Name))
		}
	case resourcemanager.FloatConstant:
		{
			valueSnippet = fmt.Sprintf(`
    num, err := strconv.ParseFloat(ap.Parts[idx], 64)
    if err != nil {
        return nil, fmt.Errorf("failed to parse %%q as float: %%+v", ap.Parts[idx], err)
    }
    output.%s = num`, strings.Title(segment.Name))
		}
	case resourcemanager.StringConstant:
		valueSnippet = fmt.Sprintf("output.%s = ap.Parts[idx]", strings.Title(segment.Name))
	default:
		return "", fmt.Errorf("unsupported constant field type: %+v", resourceConstant.Type)
	}
	comparisonString := getComparisonString("enum", true)

	out := fmt.Sprintf(`
    found := false
    enums := []string{%s}
    for _, enum := range(enums) {
        if %s {
            found = true
            break
        }
    }
    if !found {
        return nil, fmt.Errorf("%%q is not a valid %%q value, it can be one of %%q", ap.Parts[idx], ap.Parts[idx-1], strings.Join(enums, ","))
    }
    %s`, strings.Join(enums, ","), comparisonString, valueSnippet)
	return out, nil
}

func getComparisonString(compareTo string, expectedEqual bool) string {
	var comparisonString string
	if featureflags.CaseSensitiveComparisons {
		operator := "=="
		if !expectedEqual {
			operator = "!="
		}
		comparisonString = fmt.Sprintf(`ap.Parts[idx] %s %q`, operator, compareTo)
	} else {
		operator := ""
		if !expectedEqual {
			operator = "!"
		}
		comparisonString = fmt.Sprintf(`%sstrings.EqualFold(ap.Parts[idx], %q)`, operator, compareTo)
	}
	return comparisonString
}
