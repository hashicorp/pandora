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
	// index maps an ARM resource type (e.g. "Microsoft.Compute/AvailabilitySets")
	// to a map of API versions to GeneratedResource.
	index map[string]map[string]generator.GeneratedResource

	// flat contains all generated resources
	flat []generator.GeneratedResource
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

	apiDir, err := resolveApiDefinitionsDir(logger, dirFlag, refFlag, forceUpdateFlag)
	if err != nil {
		return fmt.Errorf("resolving api-definitions: %w", err)
	}

	logger.Info("Loading API Definitions into memory...", "dir", apiDir)
	opts := generator.GenerateOptions{
		APIDefinitionsDirectory: apiDir,
		SourceDataType:          models.ResourceManagerSourceDataType,
		Logger:                  logger,
	}

	results, err := generator.Generate(opts)
	if err != nil {
		return fmt.Errorf("generating docs: %v", err)
	}

	srv := &PandoraServer{
		index: make(map[string]map[string]generator.GeneratedResource),
		flat:  make([]generator.GeneratedResource, 0, len(results)),
	}

	for _, res := range results {
		srv.flat = append(srv.flat, res)
		
		armType := fmt.Sprintf("%s/%s", res.Provider, res.Resource)
		
		if srv.index[armType] == nil {
			srv.index[armType] = make(map[string]generator.GeneratedResource)
		}
		srv.index[armType][res.Version] = res
	}
	logger.Info("Data loaded successfully", "total_resources", len(srv.flat))

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
	return server.Serve()
}

// ---- list_available_resources ----

type ListAvailableResourcesArgs struct {
	ServiceName string `json:"service_name,omitempty" jsonschema:"description=Optional. Filter by a specific service name (e.g., Compute, Storage)."`
}

func (s *PandoraServer) listAvailableResources(ctx context.Context, args ListAvailableResourcesArgs) (*mcp.ToolResponse, error) {
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

	// Assume main model name usually matches Resource Name or similar,
	// but we can just use the resource name directly or find a likely candidate.
	mainModelName := res.Resource
	if _, ok := apiRes.Models[mainModelName]; !ok {
		// Fallback to first available model if it doesn't match
		for k := range apiRes.Models {
			mainModelName = k
			break
		}
	}

	code := generateGoSchemaForModel(apiRes, mainModelName, 1)

	output := fmt.Sprintf("### Proposed Terraform Schema Skeleton: %s\n> [!NOTE]\n> This is an algorithmically generated starting point. Review against provider patterns.\n\n```go\n%s\n```", targetArmType, code)
	return mcp.NewToolResponse(mcp.NewTextContent(output)), nil
}

func generateGoSchemaForModel(apiRes *models.APIResource, modelName string, indentLevel int) string {
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
		case models.DictionarySDKObjectDefinitionType:
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
			buf.WriteString(generateGoSchemaForModel(apiRes, *field.ObjectDefinition.ReferenceName, indentLevel+3))
			buf.WriteString(fmt.Sprintf("%s\t\t},\n", indent))
			buf.WriteString(fmt.Sprintf("%s\t},\n", indent))
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
