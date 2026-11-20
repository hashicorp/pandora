#!/bin/bash
# Copyright IBM Corp. 2023, 2026
# SPDX-License-Identifier: MPL-2.0

set -euo pipefail

REPO_ROOT="$(cd "$(dirname "$0")/.." && pwd)"
PASS_COUNT=0

pass() {
  echo "PASS: $1"
  PASS_COUNT=$((PASS_COUNT + 1))
}

fail() {
  echo "FAIL: $1" >&2
  exit 1
}

echo "==> 1. Static workflow security & policy checks (pandora)"

# Every uses: must be pinned to a 40-char commit SHA
unpinned=$(grep -rnE '^\s*-?\s*uses:\s*' "${REPO_ROOT}/.github/workflows/" | grep -Ev '@[0-9a-f]{40}(\s|#|$)' || true)
if [[ -n "$unpinned" ]]; then
  fail "Unpinned GitHub Actions found:\n$unpinned"
fi
pass "All GitHub Actions uses: references are pinned to 40-char SHAs"

# Disallowed patterns
disallowed_patterns=$(grep -rnE 'StrictHostKeyChecking=accept-new|persist-credentials:\s*true|::set-output|SERVICE_ACCOUNT_PANDORA_TOKEN|TERRAFORM_AZURERM_PUBLIC_DEPLOYMENT_WRITE_KEY' "${REPO_ROOT}/.github/workflows/" "${REPO_ROOT}/scripts/" | grep -v 'scripts/test-workflows.sh' || true)
if [[ -n "$disallowed_patterns" ]]; then
  fail "Disallowed legacy/insecure pattern found:\n$disallowed_patterns"
fi
pass "No disallowed patterns (accept-new, persist-credentials: true, ::set-output, legacy secrets)"

# Every actions/checkout must specify persist-credentials: false
checkout_missing_persist=$(awk '
  /uses: actions\/checkout@/ { in_co=1; found=0; file=FILENAME; line=FNR; next }
  in_co && /persist-credentials: false/ { found=1 }
  in_co && /^[[:space:]]*-[[:space:]]/ { if (!found) print file ":" line; in_co=0 }
  in_co && /^[[:space:]]*[a-zA-Z0-9_-]+:[[:space:]]*$/ && !/with:/ { if (!found) print file ":" line; in_co=0 }
  END { if (in_co && !found) print file ":" line }
' "${REPO_ROOT}"/.github/workflows/*.yaml)
if [[ -n "$checkout_missing_persist" ]]; then
  fail "actions/checkout missing persist-credentials: false:\n$checkout_missing_persist"
fi
pass "Every actions/checkout sets persist-credentials: false"

# No single job may hold both contents: write and pull-requests: write
dual_write=$(awk '
  /^  [a-zA-Z0-9_-]+:$/ { job=$1; cw=0; prw=0; next }
  /contents:[[:space:]]*write/ { cw=1 }
  /pull-requests:[[:space:]]*write/ { prw=1 }
  cw && prw { print FILENAME " job " job; cw=0; prw=0 }
' "${REPO_ROOT}"/.github/workflows/*.yaml)
if [[ -n "$dual_write" ]]; then
  fail "Job holds both contents: write and pull-requests: write:\n$dual_write"
fi
pass "No job holds both contents: write and pull-requests: write"

echo "==> 2. Hermetic shallow-clone bundle & 3-dot merge-base path gate tests"

tmp_dir=$(mktemp -d /tmp/pandora-workflow-test.XXXXXX)
trap 'rm -rf "$tmp_dir"' EXIT
export GIT_CONFIG_NOSYSTEM=1
export HOME="$tmp_dir"

git init --bare -b main "$tmp_dir/remote.git" >/dev/null
git clone "$tmp_dir/remote.git" "$tmp_dir/seed" >/dev/null 2>&1
cd "$tmp_dir/seed"
git config user.name "test"
git config user.email "test@example.com"
echo "v1" > README.md
git add README.md && git commit -m "c1" >/dev/null
echo "v2" > README.md
git add README.md && git commit -m "c2" >/dev/null
git push origin HEAD:refs/heads/main >/dev/null 2>&1

# Test conditionally-commit-codegen-changes.sh from a shallow (fetch-depth: 1) checkout
git clone --depth 1 "file://$tmp_dir/remote.git" "$tmp_dir/shallow" >/dev/null 2>&1
cd "$tmp_dir/shallow"
git config user.name "test"
git config user.email "test@example.com"
branch="data/regeneration-from-0123456789abcdef0123456789abcdef01234567-rest-api-specs"
git checkout -b "$branch" >/dev/null 2>&1
mkdir -p api-definitions/resource-manager/Compute
echo "{}" > api-definitions/resource-manager/Compute/api.json

BUNDLE_PATH="$tmp_dir/importer.bundle" GITHUB_OUTPUT="$tmp_dir/out" \
  "${REPO_ROOT}/scripts/conditionally-commit-codegen-changes.sh" "data: test" >/dev/null

grep -qx "has_changes_to_push=true" "$tmp_dir/out" || fail "Expected has_changes_to_push=true"

# Advance remote main with an unrelated .github/workflows/ commit while bundle is in flight
cd "$tmp_dir/seed"
mkdir -p .github/workflows
echo "name: test" > .github/workflows/other.yaml
git add --all && git commit -m "unrelated workflow change on main" >/dev/null
git push origin HEAD:refs/heads/main >/dev/null 2>&1

# Verify --no-checkout --filter=blob:none clone can verify, fetch, and pass 3-dot allowlist gate
git clone --no-checkout --filter=blob:none "file://$tmp_dir/remote.git" "$tmp_dir/push-job" >/dev/null 2>&1
cd "$tmp_dir/push-job"
git bundle verify "$tmp_dir/importer.bundle" >/dev/null
git fetch "$tmp_dir/importer.bundle" "refs/heads/${branch}:refs/heads/${branch}" >/dev/null 2>&1
disallowed=$(git diff --name-only "origin/main...refs/heads/${branch}" | grep -Ev '^api-definitions/(resource-manager|data-plane)/' || true)
if [[ -n "$disallowed" ]]; then
  fail "3-dot gate rejected valid api-definitions change after main advanced: $disallowed"
fi
pass "Shallow-clone bundle + --filter=blob:none fetch + 3-dot allowlist gate passed"

# Verify 3-dot gate rejects forbidden paths (.github/workflows/ or sdk/)
cd "$tmp_dir/shallow"
mkdir -p sdk/auth
echo "package auth" > sdk/auth/bad.go
git add --all && git commit -m "forbidden change" >/dev/null
git bundle create "$tmp_dir/bad.bundle" "origin/main..refs/heads/${branch}" >/dev/null 2>&1

cd "$tmp_dir/push-job"
git fetch "$tmp_dir/bad.bundle" "+refs/heads/${branch}:refs/heads/${branch}" >/dev/null 2>&1
disallowed=$(git diff --name-only "origin/main...refs/heads/${branch}" | grep -Ev '^(data-plane|microsoft-graph|resource-manager)/' || true)
if [[ "$disallowed" != *"sdk/auth/bad.go"* ]]; then
  fail "3-dot gate failed to reject sdk/auth/bad.go"
fi
pass "3-dot allowlist gate rejected forbidden sdk/ modification"

# Verify branch name regexes
valid_branch="auto-pr/1a2b3c4"
bad_branch="auto-pr/../../main"
[[ "$valid_branch" =~ ^auto-pr/[0-9a-f]{7,40}$ ]] || fail "Valid auto-pr branch rejected"
if [[ "$bad_branch" =~ ^auto-pr/[0-9a-f]{7,40}$ ]]; then
  fail "Malformed auto-pr branch accepted"
fi
pass "Branch name validation regexes verified"

echo "==> All ${PASS_COUNT} pandora workflow checks passed!"
