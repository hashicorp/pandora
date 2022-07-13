package main

import (
	"context"
	"fmt"
	"log"
	"os"
	"sort"
	"strconv"
	"strings"

	"github.com/google/go-github/github"
	"golang.org/x/oauth2"
)

type Repo struct {
	Owner string
	Name  string
}

func (r Repo) getPullRequest(ctx context.Context, client *github.Client, id int) (*github.PullRequest, error) {
	pr, _, err := client.PullRequests.Get(ctx, r.Owner, r.Name, id)
	if err != nil {
		return nil, err
	}

	return pr, nil
}

func (r Repo) getPullRequestDiff(ctx context.Context, client *github.Client, id int) (string, error) {
	opts := github.RawOptions{
		Type: github.Diff,
	}

	pr, _, err := client.PullRequests.GetRaw(ctx, r.Owner, r.Name, id, opts)
	if err != nil {
		return "", err
	}

	return pr, nil
}

func (r Repo) createCommentOnPullRequest(ctx context.Context, client *github.Client, id int, body *string) error {
	comment := github.IssueComment{
		Body: body,
	}

	if _, _, err := client.Issues.CreateComment(ctx, r.Owner, r.Name, id, &comment); err != nil {
		return err
	}

	return nil
}

func newGitHubClient(ctx context.Context, token string) *github.Client {
	ts := oauth2.StaticTokenSource(
		&oauth2.Token{AccessToken: token},
	)
	tc := oauth2.NewClient(ctx, ts)
	return github.NewClient(tc)
}

func shortenFileName(file string) string {
	fileSplit := strings.Split(file, "/")
	for i, v := range fileSplit {
		if strings.HasSuffix(v, "ResourceManager") {
			return ".../" + strings.Join(fileSplit[i+1:], "/")
		}
	}

	return ".../" + file
}

func reverseMap(files []map[string]string) map[string][]string {
	r := make(map[string][]string, 0)
	for _, file := range files {
		for k, v := range file {
			r[v] = append(r[v], k)
		}
	}

	return r
}

func formatPaths(paths []string) []string {
	f := make([]string, 0)
	for _, p := range paths {
		f = append(f, fmt.Sprintf("`%s`", p))
	}

	return f
}

func run(ctx context.Context) error {
	token := os.Getenv("PANDORA_TOKEN")
	owner := strings.Split(os.Getenv("GITHUB_REPOSITORY"), "/")[0]
	name := strings.Split(os.Getenv("GITHUB_REPOSITORY"), "/")[1]
	prId, err := strconv.Atoi(os.Getenv("PR_NUMBER"))
	if err != nil {
		return fmt.Errorf("parsing pr number: %+v", err)
	}

	repo := Repo{owner, name}
	client := newGitHubClient(ctx, token)

	prDiff, err := repo.getPullRequestDiff(ctx, client, prId)
	if err != nil {
		return err
	}

	files := strings.Split(prDiff, "+++")
	services := make(map[string][]map[string]string, 0)

	for _, file := range files {
		lines := strings.Split(file, "\n")
		if strings.Contains(lines[0], "ResourceId-") {
			filePath := shortenFileName(lines[0])
			service := strings.Split(filePath, "/")[1]
			for _, line := range lines {
				// only take the new IDs if it existed previously and has been updated
				if strings.Contains(line, "+") && strings.Contains(line, "public string ID") {
					id := line[strings.Index(line, "\"")+1 : strings.LastIndex(line, "\"")]
					services[service] = append(services[service], map[string]string{filePath: id})
					continue
				}
			}
		}
	}

	servicesReversed := make(map[string]map[string][]string, 0)
	sortedKeys := make([]string, 0)

	// need to map from ID => file occurrences
	for k, v := range services {
		servicesReversed[k] = reverseMap(v)
		sortedKeys = append(sortedKeys, k)
	}

	sort.Strings(sortedKeys)

	comment := ""

	for _, k := range sortedKeys {
		comment += fmt.Sprintf("%d Resource ID(s) found for `%s`:\nID | File\n---|---\n", len(servicesReversed[k]), k)
		for id, p := range servicesReversed[k] {
			formatted := formatPaths(p)
			comment += fmt.Sprintf("`%s`|%s\n", id, strings.Join(formatted, "<br>"))
		}
		comment += "\n"
	}

	if len(servicesReversed) == 0 {
		comment = "No new resource IDs found."
	}

	if err := repo.createCommentOnPullRequest(ctx, client, prId, &comment); err != nil {
		return err
	}

	return nil
}

func main() {
	if err := run(context.Background()); err != nil {
		log.Fatal(err)
	}
	os.Exit(0)
}
