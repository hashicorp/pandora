// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"context"
	"fmt"
	"io"
	"log"
	"os"
	"sort"
	"strconv"
	"strings"

	"github.com/google/go-github/v56/github"
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

func (r Repo) getPullRequestDiff(client *github.Client, organisation, repository string, pullRequestId int) (string, error) {
	// Whilst the GitHub API supports pagination for the files within a PR
	// we don't need to access the files individually, we just want the diff
	// so we can just pull that directly here, using the authorized client
	prDiffUri := fmt.Sprintf("https://github.com/%s/%s/pull/%d.diff", organisation, repository, pullRequestId)
	diffResp, err := client.Client().Get(prDiffUri)
	if err != nil {
		return "", fmt.Errorf("retrieving diff for PR from %q: %+v", prDiffUri, err)
	}

	result, err := io.ReadAll(diffResp.Body)
	if err != nil {
		return "", fmt.Errorf("reading diff from %q: %+v", prDiffUri, err)
	}

	return string(result), nil
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
	token := os.Getenv("GITHUB_TOKEN")
	owner := strings.Split(os.Getenv("GITHUB_REPOSITORY"), "/")[0]
	name := strings.Split(os.Getenv("GITHUB_REPOSITORY"), "/")[1]
	prId, err := strconv.Atoi(os.Getenv("PR_NUMBER"))
	if err != nil {
		return fmt.Errorf("parsing pr number: %+v", err)
	}

	repo := Repo{owner, name}
	client := newGitHubClient(ctx, token)

	prDiff, err := repo.getPullRequestDiff(client, owner, name, prId)
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
