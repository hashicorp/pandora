package main

import (
	"context"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"

	"github.com/google/go-github/github"
	"golang.org/x/oauth2"
)

type Repo struct {
	Owner string
	Name  string
}

func (r Repo) getPullRequest(client *github.Client, ctx context.Context, id int) (*github.PullRequest, error) {
	pr, _, err := client.PullRequests.Get(ctx, r.Owner, r.Name, id)
	if err != nil {
		return nil, err
	}

	return pr, nil
}

func (r Repo) getPullRequestDiff(client *github.Client, ctx context.Context, id int) (string, error) {
	opts := github.RawOptions{
		Type: github.Diff,
	}

	pr, _, err := client.PullRequests.GetRaw(ctx, r.Owner, r.Name, id, opts)
	if err != nil {
		return "", err
	}

	return pr, nil
}

func (r Repo) updatePullRequestBody(client *github.Client, ctx context.Context, id int, body *string) error {
	updateBody := github.PullRequest{
		Body: body,
	}

	if _, _, err := client.PullRequests.Edit(ctx, r.Owner, r.Name, id, &updateBody); err != nil {
		return err
	}

	return nil
}

func newGitHubClient(token string) (*github.Client, context.Context) {
	ctx := context.Background()
	ts := oauth2.StaticTokenSource(
		&oauth2.Token{AccessToken: token},
	)
	tc := oauth2.NewClient(ctx, ts)
	return github.NewClient(tc), ctx
}

func shortenFileName(file string) string {
	fileSplit := strings.Split(file, "/")
	for i, v := range fileSplit {
		if strings.HasSuffix(v, "ResourceManager") {
			return ".../" + strings.Join(fileSplit[i+1:], "/")
		}
	}
	return file
}

func run() error {
	token := os.Getenv("GITHUB_TOKEN")
	owner := strings.Split(os.Getenv("GITHUB_REPOSITORY"), "/")[0]
	name := strings.Split(os.Getenv("GITHUB_REPOSITORY"), "/")[1]
	prId, err := strconv.Atoi(os.Getenv("PR_NUMBER"))
	if err != nil {
		return fmt.Errorf("parsing pr number: %+v", err)
	}

	repo := Repo{owner, name}
	client, ctx := newGitHubClient(token)

	prDiff, err := repo.getPullRequestDiff(client, ctx, prId)
	if err != nil {
		return err
	}

	resourceIds := make(map[string]string, 0)

	files := strings.Split(prDiff, "+++")

	for _, file := range files {
		lines := strings.Split(file, "\n")
		if strings.Contains(lines[0], "ResourceId-") {
			filePath := shortenFileName(lines[0])
			log.Printf("%s", strings.TrimSpace(lines[0]))
			for _, line := range lines {
				if strings.Contains(line, "public string ID") {
					resourceIds[filePath] = line[strings.Index(line, "\"")+1 : strings.LastIndex(line, "\"")]
					continue
				}
			}
		}
	}

	comment := fmt.Sprintf("\n\n%d Resource IDs found:\n\n", len(resourceIds))
	for file, id := range resourceIds {
		comment += fmt.Sprintf("```%s => %s```\n", file, id)
	}

	pr, err := repo.getPullRequest(client, ctx, prId)

	body := ""
	if v := pr.Body; v != nil {
		body = *v
	}
	body += comment

	if err := repo.updatePullRequestBody(client, ctx, prId, &body); err != nil {
		return err
	}

	return nil
}

func main() {
	if err := run(); err != nil {
		log.Fatal(err)
	}
	os.Exit(0)
}
