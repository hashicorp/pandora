#!/bin/bash
# Copyright IBM Corp. 2023, 2026
# SPDX-License-Identifier: MPL-2.0

set -euo pipefail

if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
  git add --all
  git commit -m "$1"
  if [[ -n "${BUNDLE_PATH:-}" ]]; then
    echo "Creating git bundle at ${BUNDLE_PATH}.."
    git bundle create "${BUNDLE_PATH}" "origin/main..HEAD"
  fi
  if [[ -n "${GITHUB_OUTPUT:-}" ]]; then
    echo "has_changes_to_push=true" >> "$GITHUB_OUTPUT"
  fi
else
  if [[ -n "${GITHUB_OUTPUT:-}" ]]; then
    echo "has_changes_to_push=false" >> "$GITHUB_OUTPUT"
  fi
fi
