package main

import (
	"context"
	"flag"
	"fmt"
	"log"
	"os"
	"os/exec"
	"path/filepath"
	"sort"
	"strings"
	"sync"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-agent-docs/generator"
	"github.com/hexops/gotextdiff"
	"github.com/hexops/gotextdiff/myers"
	"github.com/hexops/gotextdiff/span"
	mcp "github.com/metoro-io/mcp-golang"
	"github.com/metoro-io/mcp-golang/transport/stdio"
)

type PandoraServer struct {
	logger hclog.Logger

	// data
	index map[string]map[string]generator.GeneratedResource
	flat  []generator.GeneratedResource

	// lazy load state
	loadOnce sync.Once
	loadErr  error

	// configuration
	dirFlag         string
	refFlag         string
	forceUpdateFlag bool
}

func (s *PandoraServer) ensureLoaded() error {
	s.loadOnce.Do(func() {
		apiDir, err := resolveApiDefinitionsDir(s.logger, s.dirFlag, s.refFlag, s.forceUpdateFlag)
		if err != nil {
			s.loadErr = fmt.Errorf("resolving api-definitions: %w", err)
			return
		}

		s.logger.Info("Loading API Definitions into memory...", "dir", apiDir)
		opts := generator.GenerateOptions{
			APIDefinitionsDirectory: apiDir,
			SourceDataType:          models.ResourceManagerSourceDataType,
			Logger:                  s.logger,
		}

		results, err := generator.Generate(opts)
		if err != nil {
			s.loadErr = fmt.Errorf("generating docs: %v", err)
			return
		}

		s.index = make(map[string]map[string]generator.GeneratedResource)
		s.flat = make([]generator.GeneratedResource, 0, len(results))

		for _, res := range results {
			s.flat = append(s.flat, res)

			armType := fmt.Sprintf("%s/%s", res.Provider, res.Resource)

			if s.index[armType] == nil {
				s.index[armType] = make(map[string]generator.GeneratedResource)
			}
			s.index[armType][res.Version] = res
		}
		s.logger.Info("Data loaded successfully", "total_resources", len(s.flat))
	})
	return s.loadErr
}

func main() {
	if err := run(); err != nil {
		log.Fatalf("Fatal error: %v", err)
	}
}

func run() error {
	var (
		dirFlag         string
		refFlag         string
		forceUpdateFlag bool
	)

	// Flag parsing must happen manually since this might be run via `go run`
	// or inside an MCP client where args are passed via the command.
	flag.StringVar(&dirFlag, "dir", "", "Path to a local api-definitions directory")
	flag.StringVar(&refFlag, "ref", "main", "GitHub ref (branch/tag/commit) to download if local dir is not found")
	flag.BoolVar(&forceUpdateFlag, "force-update", false, "Force a fresh sparse-checkout of the git repository cache")
	flag.Parse()

	logger := hclog.New(&hclog.LoggerOptions{
		Name:  "mcp-pandora",
		Level: hclog.Info,
	})

	srv := &PandoraServer{
		logger:          logger,
		dirFlag:         dirFlag,
		refFlag:         refFlag,
		forceUpdateFlag: forceUpdateFlag,
	}

	transport := stdio.NewStdioServerTransport()
	server := mcp.NewServer(transport, mcp.WithName("pandora"), mcp.WithVersion("1.0.0"))

	// Register Tools
	if err := server.RegisterTool("list_available_resources", "Returns a list of all ARM resource types (e.g., Microsoft.Compute/VirtualMachines) available in the IR.", srv.listAvailableResources); err != nil {
		return err
	}
	if err := server.RegisterTool("get_resource_markdown", "Returns the Markdown documentation for a specific resource.", srv.getResourceMarkdown); err != nil {
		return err
	}
	if err := server.RegisterTool("find_resource_by_property", "Searches the IR to find which resource(s) contain a specific property.", srv.findResourceByProperty); err != nil {
		return err
	}
	if err := server.RegisterTool("get_api_version_comparison", "Returns a Markdown diff of what changed between two API versions for a resource.", srv.getApiVersionComparison); err != nil {
		return err
	}
	if err := server.RegisterTool("propose_terraform_schema", "Generates a skeletal Terraform schema mapping based on the ARM API definitions.", srv.proposeTerraformSchema); err != nil {
		return err
	}

	logger.Info("Starting MCP Server over stdio")
	if err := server.Serve(); err != nil {
		return err
	}

	// Block forever. The process will be terminated by the MCP client when it closes the stdin pipe.
	select {}
}

// ---- list_available_resources ----

type ListAvailableResourcesArgs struct {
	ServiceName string `json:"service_name,omitempty" jsonschema:"description=Optional. Filter by a specific service name (e.g., Compute, Storage)."`
}

func (s *PandoraServer) listAvailableResources(ctx context.Context, args ListAvailableResourcesArgs) (*mcp.ToolResponse, error) {
	if err := s.ensureLoaded(); err != nil {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("Failed to load data: %v", err))), nil
	}

	seen := make(map[string]bool)
	var list []string

	for _, res := range s.flat {
		if args.ServiceName != "" && !strings.EqualFold(res.Service, args.ServiceName) {
			continue
		}
		
		armType := fmt.Sprintf("%s/%s", res.Provider, res.Resource)
		if !seen[armType] {
			seen[armType] = true
			list = append(list, armType)
		}
	}

	sort.Strings(list)
	
	var buf strings.Builder
	buf.WriteString("### Available ARM Resource Types\n")
	for _, item := range list {
		buf.WriteString(fmt.Sprintf("* `%s`\n", item))
	}

	return mcp.NewToolResponse(mcp.NewTextContent(buf.String())), nil
}

// ---- get_resource_markdown ----

type GetResourceMarkdownArgs struct {
	ArmResourceType string `json:"arm_resource_type" jsonschema:"description=The ARM resource type (e.g., Microsoft.Compute/VirtualMachines)."`
	ApiVersion      string `json:"api_version,omitempty" jsonschema:"description=Optional. The specific API version. Defaults to the latest available."`
}

func (s *PandoraServer) getResourceMarkdown(ctx context.Context, args GetResourceMarkdownArgs) (*mcp.ToolResponse, error) {
	if err := s.ensureLoaded(); err != nil {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("Failed to load data: %v", err))), nil
	}

	// Case-insensitive lookup
	var targetArmType string
	for k := range s.index {
		if strings.EqualFold(k, args.ArmResourceType) {
			targetArmType = k
			break
		}
	}

	if targetArmType == "" {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("Resource type not found: %s", args.ArmResourceType))), nil
	}

	versionsMap := s.index[targetArmType]
	versionToUse := args.ApiVersion

	if versionToUse == "" {
		var versions []string
		for v := range versionsMap {
			versions = append(versions, v)
		}
		sort.Strings(versions)
		versionToUse = versions[len(versions)-1] // Pick latest date
	}

	res, ok := versionsMap[versionToUse]
	if !ok {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("API version %s not found for resource type %s", args.ApiVersion, args.ArmResourceType))), nil
	}

	return mcp.NewToolResponse(mcp.NewTextContent(res.Markdown)), nil
}

// ---- find_resource_by_property ----

type FindResourceByPropertyArgs struct {
	PropertyName string `json:"property_name" jsonschema:"description=The exact property name to search for (e.g. EnableHttpsTrafficOnly)."`
}

func (s *PandoraServer) findResourceByProperty(ctx context.Context, args FindResourceByPropertyArgs) (*mcp.ToolResponse, error) {
	if err := s.ensureLoaded(); err != nil {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("Failed to load data: %v", err))), nil
	}

	// We look for "`PropertyName`" in the markdown
	searchStr := fmt.Sprintf("`%s`", args.PropertyName)
	
	// Track matches: ArmType -> List of Versions
	matches := make(map[string][]string)
	
	for _, res := range s.flat {
		// Simple case-insensitive search or exact search? Let's do exact since it's backticked.
		// Actually let's do case-insensitive containing for flexibility.
		if strings.Contains(strings.ToLower(res.Markdown), strings.ToLower(searchStr)) {
			armType := fmt.Sprintf("%s/%s", res.Provider, res.Resource)
			matches[armType] = append(matches[armType], res.Version)
		}
	}

	if len(matches) == 0 {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("No resources found containing property `%s`.", args.PropertyName))), nil
	}

	var buf strings.Builder
	buf.WriteString(fmt.Sprintf("### Resources containing `%s`\n", args.PropertyName))
	
	// Sort results
	var armTypes []string
	for k := range matches {
		armTypes = append(armTypes, k)
	}
	sort.Strings(armTypes)

	for _, armType := range armTypes {
		versions := matches[armType]
		sort.Strings(versions)
		
		// Deduplicate versions just in case
		vmap := make(map[string]bool)
		var uniqueV []string
		for _, v := range versions {
			if !vmap[v] {
				vmap[v] = true
				uniqueV = append(uniqueV, v)
			}
		}

		buf.WriteString(fmt.Sprintf("* **%s** (Versions: %s)\n", armType, strings.Join(uniqueV, ", ")))
	}

	return mcp.NewToolResponse(mcp.NewTextContent(buf.String())), nil
}

// ---- get_api_version_comparison ----

type GetApiVersionComparisonArgs struct {
	ArmResourceType string `json:"arm_resource_type" jsonschema:"description=The ARM resource type (e.g., Microsoft.Compute/VirtualMachines)."`
	V1              string `json:"v1" jsonschema:"description=The older API version."`
	V2              string `json:"v2" jsonschema:"description=The newer API version."`
}

func (s *PandoraServer) getApiVersionComparison(ctx context.Context, args GetApiVersionComparisonArgs) (*mcp.ToolResponse, error) {
	if err := s.ensureLoaded(); err != nil {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("Failed to load data: %v", err))), nil
	}

	var targetArmType string
	for k := range s.index {
		if strings.EqualFold(k, args.ArmResourceType) {
			targetArmType = k
			break
		}
	}

	if targetArmType == "" {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("Resource type not found: %s", args.ArmResourceType))), nil
	}

	versionsMap := s.index[targetArmType]
	res1, ok1 := versionsMap[args.V1]
	res2, ok2 := versionsMap[args.V2]

	if !ok1 {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("API version %s not found", args.V1))), nil
	}
	if !ok2 {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("API version %s not found", args.V2))), nil
	}

	// Generate diff
	edits := myers.ComputeEdits(span.URIFromPath("v1"), res1.Markdown, res2.Markdown)
	diff := fmt.Sprint(gotextdiff.ToUnified("v1", "v2", res1.Markdown, edits))

	output := fmt.Sprintf("### Schema Diff: %s (%s -> %s)\n```diff\n%s\n```", targetArmType, args.V1, args.V2, diff)
	return mcp.NewToolResponse(mcp.NewTextContent(output)), nil
}

// ---- propose_terraform_schema ----

type ProposeTerraformSchemaArgs struct {
	ArmResourceType string `json:"arm_resource_type" jsonschema:"description=The ARM resource type (e.g., Microsoft.Compute/VirtualMachines)."`
	ApiVersion      string `json:"api_version,omitempty" jsonschema:"description=Optional. The specific API version. Defaults to the latest available."`
}

func (s *PandoraServer) proposeTerraformSchema(ctx context.Context, args ProposeTerraformSchemaArgs) (*mcp.ToolResponse, error) {
	if err := s.ensureLoaded(); err != nil {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("Failed to load data: %v", err))), nil
	}

	var targetArmType string
	for k := range s.index {
		if strings.EqualFold(k, args.ArmResourceType) {
			targetArmType = k
			break
		}
	}

	if targetArmType == "" {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("Resource type not found: %s", args.ArmResourceType))), nil
	}

	versionsMap := s.index[targetArmType]
	versionToUse := args.ApiVersion

	if versionToUse == "" {
		var versions []string
		for v := range versionsMap {
			versions = append(versions, v)
		}
		sort.Strings(versions)
		versionToUse = versions[len(versions)-1] // Pick latest date
	}

	res, ok := versionsMap[versionToUse]
	if !ok {
		return mcp.NewToolResponse(mcp.NewTextContent(fmt.Sprintf("API version %s not found", args.ApiVersion))), nil
	}

	apiRes := res.APIResource
	if apiRes == nil || len(apiRes.Models) == 0 {
		return mcp.NewToolResponse(mcp.NewTextContent("No models found for this resource.")), nil
	}

	// Smart Root Model Resolution
	candidate := res.Resource
	if strings.HasSuffix(candidate, "ies") {
		candidate = strings.TrimSuffix(candidate, "ies") + "y"
	} else if strings.HasSuffix(candidate, "es") && !strings.HasSuffix(candidate, "ates") {
		candidate = strings.TrimSuffix(candidate, "es")
	} else if strings.HasSuffix(candidate, "s") && !strings.HasSuffix(candidate, "ss") {
		candidate = strings.TrimSuffix(candidate, "s")
	}

	mainModelName := res.Resource
	if _, ok := apiRes.Models[mainModelName]; !ok {
		if _, ok := apiRes.Models[candidate]; ok {
			mainModelName = candidate
		} else {
			// Search for a model that contains the candidate name and has a 'properties' field
			for k, m := range apiRes.Models {
				if _, hasProps := m.Fields["properties"]; hasProps {
					if strings.Contains(strings.ToLower(k), strings.ToLower(candidate)) {
						mainModelName = k
						break
					}
				}
			}
			// Absolute fallback
			if _, ok := apiRes.Models[mainModelName]; !ok {
				for k := range apiRes.Models {
					mainModelName = k
					break
				}
			}
		}
	}

	code := generateGoSchemaForModel(apiRes, mainModelName, 1, make(map[string]bool), true)

	output := fmt.Sprintf("### Proposed Terraform Schema Skeleton: %s\n> [!NOTE]\n> This is an algorithmically generated starting point. Review against provider patterns.\n\n```go\n%s\n```", targetArmType, code)
	return mcp.NewToolResponse(mcp.NewTextContent(output)), nil
}

func generateGoSchemaForModel(apiRes *models.APIResource, modelName string, indentLevel int, visited map[string]bool, isRoot bool) string {
	if visited[modelName] {
		return "" // Prevent infinite recursion
	}
	visited[modelName] = true
	defer func() { visited[modelName] = false }()

	model, ok := apiRes.Models[modelName]
	if !ok {
		return ""
	}

	var buf strings.Builder
	indent := strings.Repeat("\t", indentLevel)

	// Sort fields for deterministic output
	var fieldNames []string
	for k := range model.Fields {
		fieldNames = append(fieldNames, k)
	}
	sort.Strings(fieldNames)

	for _, fieldName := range fieldNames {
		field := model.Fields[fieldName]
		tfName := toSnakeCase(fieldName)
		
		// Inline properties if isRoot
		if isRoot && fieldName == "properties" && field.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType && field.ObjectDefinition.ReferenceName != nil {
			buf.WriteString(generateGoSchemaForModel(apiRes, *field.ObjectDefinition.ReferenceName, indentLevel, visited, false))
			continue
		}

		buf.WriteString(fmt.Sprintf("%s\"%s\": {\n", indent, tfName))
		
		// Determine type
		schemaType := "schema.TypeString"
		switch field.ObjectDefinition.Type {
		case models.IntegerSDKObjectDefinitionType:
			schemaType = "schema.TypeInt"
		case models.FloatSDKObjectDefinitionType:
			schemaType = "schema.TypeFloat"
		case models.BooleanSDKObjectDefinitionType:
			schemaType = "schema.TypeBool"
		case models.ListSDKObjectDefinitionType:
			schemaType = "schema.TypeList"
		case models.DictionarySDKObjectDefinitionType, models.TagsSDKObjectDefinitionType:
			schemaType = "schema.TypeMap"
		case models.ReferenceSDKObjectDefinitionType:
			schemaType = "schema.TypeList" // Default to List for blocks
		}

		buf.WriteString(fmt.Sprintf("%s\tType: %s,\n", indent, schemaType))
		
		if field.Required {
			buf.WriteString(fmt.Sprintf("%s\tRequired: true,\n", indent))
		} else {
			buf.WriteString(fmt.Sprintf("%s\tOptional: true,\n", indent))
		}
		
		if field.ReadOnly {
			buf.WriteString(fmt.Sprintf("%s\tComputed: true,\n", indent))
		}
		
		if field.Sensitive {
			buf.WriteString(fmt.Sprintf("%s\tSensitive: true,\n", indent))
		}

		if field.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType && field.ObjectDefinition.ReferenceName != nil {
			buf.WriteString(fmt.Sprintf("%s\tMaxItems: 1,\n", indent))
			buf.WriteString(fmt.Sprintf("%s\tElem: &schema.Resource{\n", indent))
			buf.WriteString(fmt.Sprintf("%s\t\tSchema: map[string]*schema.Schema{\n", indent))
			buf.WriteString(generateGoSchemaForModel(apiRes, *field.ObjectDefinition.ReferenceName, indentLevel+3, visited, false))
			buf.WriteString(fmt.Sprintf("%s\t\t},\n", indent))
			buf.WriteString(fmt.Sprintf("%s\t},\n", indent))
		} else if field.ObjectDefinition.Type == models.ListSDKObjectDefinitionType && field.ObjectDefinition.NestedItem != nil {
			if field.ObjectDefinition.NestedItem.Type == models.ReferenceSDKObjectDefinitionType && field.ObjectDefinition.NestedItem.ReferenceName != nil {
				buf.WriteString(fmt.Sprintf("%s\tElem: &schema.Resource{\n", indent))
				buf.WriteString(fmt.Sprintf("%s\t\tSchema: map[string]*schema.Schema{\n", indent))
				buf.WriteString(generateGoSchemaForModel(apiRes, *field.ObjectDefinition.NestedItem.ReferenceName, indentLevel+3, visited, false))
				buf.WriteString(fmt.Sprintf("%s\t\t},\n", indent))
				buf.WriteString(fmt.Sprintf("%s\t},\n", indent))
			} else {
				elemType := "schema.TypeString"
				switch field.ObjectDefinition.NestedItem.Type {
				case models.IntegerSDKObjectDefinitionType:
					elemType = "schema.TypeInt"
				case models.FloatSDKObjectDefinitionType:
					elemType = "schema.TypeFloat"
				case models.BooleanSDKObjectDefinitionType:
					elemType = "schema.TypeBool"
				}
				buf.WriteString(fmt.Sprintf("%s\tElem: &schema.Schema{\n", indent))
				buf.WriteString(fmt.Sprintf("%s\t\tType: %s,\n", indent, elemType))
				buf.WriteString(fmt.Sprintf("%s\t},\n", indent))
			}
		}

		buf.WriteString(fmt.Sprintf("%s},\n", indent))
	}

	return buf.String()
}

func toSnakeCase(s string) string {
	var res strings.Builder
	for i, r := range s {
		if r >= 'A' && r <= 'Z' {
			if i > 0 {
				res.WriteRune('_')
			}
			res.WriteRune(r + ('a' - 'A'))
		} else {
			res.WriteRune(r)
		}
	}
	return res.String()
}

func resolveApiDefinitionsDir(logger hclog.Logger, dirFlag, refFlag string, forceUpdate bool) (string, error) {
	// 1. Explicit CLI Flag
	if dirFlag != "" {
		if _, err := os.Stat(dirFlag); err == nil {
			return dirFlag, nil
		} else {
			return "", fmt.Errorf("provided -dir %s does not exist", dirFlag)
		}
	}

	// 2. Local fallback (for developers working inside the Pandora repo)
	localFallback := "../../api-definitions"
	if _, err := os.Stat(localFallback); err == nil {
		logger.Info("Found local api-definitions, using it", "path", localFallback)
		return localFallback, nil
	}

	// 3. Remote fallback via sparse-checkout into CacheDir
	cacheBase, err := os.UserCacheDir()
	if err != nil {
		return "", fmt.Errorf("getting user cache dir: %v", err)
	}

	cacheDir := filepath.Join(cacheBase, "mcp-pandora", refFlag)
	apiDefinitionsCache := filepath.Join(cacheDir, "api-definitions")

	if forceUpdate {
		logger.Info("Force updating cache", "dir", cacheDir)
		os.RemoveAll(cacheDir)
	} else if _, err := os.Stat(apiDefinitionsCache); err == nil {
		logger.Info("Using cached remote api-definitions", "path", apiDefinitionsCache, "ref", refFlag)
		return apiDefinitionsCache, nil
	}

	logger.Info("Local api-definitions not found. Fetching from GitHub via sparse-checkout...", "ref", refFlag, "dest", cacheDir)

	if err := os.MkdirAll(cacheDir, 0755); err != nil {
		return "", fmt.Errorf("creating cache dir: %v", err)
	}

	// Init empty repo
	cmd := exec.Command("git", "init")
	cmd.Dir = cacheDir
	if err := cmd.Run(); err != nil {
		return "", fmt.Errorf("git init failed: %v", err)
	}

	// Add remote
	cmd = exec.Command("git", "remote", "add", "origin", "https://github.com/hashicorp/pandora.git")
	cmd.Dir = cacheDir
	if err := cmd.Run(); err != nil {
		return "", fmt.Errorf("git remote add failed: %v", err)
	}

	// Setup sparse-checkout
	cmd = exec.Command("git", "sparse-checkout", "init")
	cmd.Dir = cacheDir
	if err := cmd.Run(); err != nil {
		return "", fmt.Errorf("git sparse-checkout init failed: %v", err)
	}

	cmd = exec.Command("git", "sparse-checkout", "set", "api-definitions")
	cmd.Dir = cacheDir
	if err := cmd.Run(); err != nil {
		return "", fmt.Errorf("git sparse-checkout set failed: %v", err)
	}

	// Fetch only the specific ref
	logger.Info("Downloading api-definitions blobs from GitHub...")
	cmd = exec.Command("git", "fetch", "--depth", "1", "origin", refFlag)
	cmd.Dir = cacheDir
	if err := cmd.Run(); err != nil {
		return "", fmt.Errorf("git fetch failed (does the ref %s exist?): %v", refFlag, err)
	}

	// Checkout
	cmd = exec.Command("git", "checkout", "FETCH_HEAD")
	cmd.Dir = cacheDir
	if err := cmd.Run(); err != nil {
		return "", fmt.Errorf("git checkout failed: %v", err)
	}

	logger.Info("Successfully cached api-definitions", "path", apiDefinitionsCache)
	return apiDefinitionsCache, nil
}
