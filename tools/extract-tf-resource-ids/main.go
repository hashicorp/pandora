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
	pr, _, _ := client.PullRequests.Get(ctx, r.Owner, r.Name, id)
	//if err != nil {
	//	return nil, err
	//}

	l, _, err := client.PullRequests.List(ctx, r.Owner, r.Name, nil)
	if err != nil {
		return nil, err
	}
	log.Printf("%+v", l)

	return pr, nil
}

func newGitHubClient(token string) (*github.Client, context.Context) {
	ctx := context.Background()
	ts := oauth2.StaticTokenSource(
		&oauth2.Token{AccessToken: token},
	)
	t := oauth2.Endpoint{}
	tc := oauth2.NewClient(ctx, ts)
	return github.NewClient(tc), ctx
}

func run() error {
	token := os.Getenv("GITHUB_TOKEN")
	log.Printf("token: %s", token)
	os.Setenv("GITHUB_REPOSITORY", "hashicorp/pandora")
	os.Setenv("PR_NUMBER", "1017")
	log.Printf("github_repository: %s", os.Getenv("GITHUB_REPOSITORY"))
	log.Printf("pr_number: %s", os.Getenv("PR_NUMBER"))

	owner := strings.Split(os.Getenv("GITHUB_REPOSITORY"), "/")[0]
	name := strings.Split(os.Getenv("GITHUB_REPOSITORY"), "/")[1]
	prId, err := strconv.Atoi(os.Getenv("PR_NUMBER"))
	if err != nil {
		return fmt.Errorf("parsing pr number: %+v", err)
	}

	repo := Repo{owner, name}
	client, ctx := newGitHubClient(token)

	_, err = repo.getPullRequest(client, ctx, prId)
	if err != nil {
		return err
	}

	//log.Printf("diff url: %s", *pr.DiffURL)

	return nil
}

func main() {
	if err := run(); err != nil {
		log.Fatal(err)
	}
	os.Exit(0)
}
