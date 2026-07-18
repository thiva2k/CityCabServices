# AGENTS.md

## Cursor Cloud specific instructions

### Project overview
CityCab Services is a single .NET 9 console application (an in-memory cab
management system) plus an NUnit test project. There is no server, database, or
GUI — it is an interactive terminal menu app.

- `CityCabServices/` — the console app (`Program.cs`, `MenuHandler.cs`, domain
  classes). Entry point runs an interactive menu loop reading from stdin.
- `CityCabServices.Tests/` — NUnit tests for the domain classes.
- `CityCabServices.sln` — ties both projects together.

### Toolchain
- The .NET 9 SDK is installed at `~/.dotnet` and is on `PATH` via `~/.bashrc`
  (`DOTNET_ROOT=~/.dotnet`). If `dotnet` is not found in a non-login shell, run
  `export PATH="$HOME/.dotnet:$PATH"` or invoke `~/.dotnet/dotnet` directly.

### Common commands (run from repo root)
- Restore: `dotnet restore`
- Build: `dotnet build`
- Test: `dotnet test` (33 NUnit tests)
- Lint: `dotnet format --verify-no-changes` (use `dotnet format` to auto-fix).
  Note: the checked-in test files currently have some whitespace-style
  violations, so the verify command reports findings and exits non-zero — this is
  pre-existing, not caused by a build break.
- Run the app: `dotnet run --project CityCabServices`

### Running the app non-interactively
The app blocks on `Console.ReadLine()`. To drive it end-to-end in an automated
way, pipe menu input via stdin, e.g.:
`printf '1\nD1\nAlice\nLIC-1\n8\n' | dotnet run --project CityCabServices`
Menu option `8` exits the loop (otherwise the process runs forever waiting for
input).
