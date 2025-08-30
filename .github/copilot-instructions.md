# Purview Telemetry Source Generator

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

## Working Effectively

### Prerequisites and Installation
**CRITICAL**: This project requires specific versions of tools. Install them in this exact order:

1. **Install .NET SDK 9.0.200 and Runtime 9.0.0**:
   ```bash
   # Install SDK
   curl -fsSL https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh | bash -s -- --version 9.0.200
   
   # Install Runtime  
   curl -fsSL https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh | bash -s -- --runtime dotnet --version 9.0.0
   
   # Set environment variables
   export PATH="$HOME/.dotnet:$PATH"
   export DOTNET_ROOT="$HOME/.dotnet"
   ```

2. **Install bun**:
   ```bash
   curl -fsSL https://bun.sh/install | bash
   export PATH="$HOME/.bun/bin:$PATH"
   ```

3. **Always verify installations**:
   ```bash
   dotnet --version  # Should show 9.0.200
   dotnet --list-runtimes  # Should show Microsoft.NETCore.App 9.0.0
   bun --version
   ```

### Build Commands
**NEVER CANCEL BUILDS OR TESTS** - Set appropriate timeouts and wait for completion:

- **Build the project** -- takes 30 seconds. NEVER CANCEL. Set timeout to 120+ seconds:
  ```bash
  export PATH="$HOME/.bun/bin:$HOME/.dotnet:$PATH" && export DOTNET_ROOT="$HOME/.dotnet"
  make build
  ```

- **Run tests** -- takes 45 seconds. NEVER CANCEL. Set timeout to 180+ seconds:
  ```bash
  export PATH="$HOME/.bun/bin:$HOME/.dotnet:$PATH" && export DOTNET_ROOT="$HOME/.dotnet"
  make test
  ```

- **Format code** -- takes 20 seconds. Set timeout to 60+ seconds:
  ```bash
  export PATH="$HOME/.bun/bin:$HOME/.dotnet:$PATH" && export DOTNET_ROOT="$HOME/.dotnet"
  make format
  ```

### Alternative Commands (if Make fails)
Use these direct dotnet commands with the same environment setup:

```bash
# Build
dotnet build ./src/Purview.Telemetry.SourceGenerator.slnx --configuration Release

# Test  
dotnet test ./src/Purview.Telemetry.SourceGenerator.slnx --configuration Release

# Format
dotnet format ./src/
```

## Validation

### Build and Test Validation
**ALWAYS** run these validation steps after making any changes:

1. **Build validation**: Must complete without errors in under 30 seconds
2. **Test validation**: 282 tests must all pass. Takes ~40 seconds. Look for "Test summary: total: 282, failed: 0, succeeded: 282"
3. **Format validation**: Run `make format` to ensure code follows project standards

### Sample Application Testing
**CRITICAL**: Always test actual functionality using the sample application:

1. **Build sample app** -- takes 20 seconds:
   ```bash
   cd samples/SampleApp
   export PATH="$HOME/.bun/bin:$HOME/.dotnet:$PATH" && export DOTNET_ROOT="$HOME/.dotnet"
   dotnet build --configuration Release
   ```

2. **Run sample app** to verify generated code works:
   ```bash
   cd samples/SampleApp
   export PATH="$HOME/.bun/bin:$HOME/.dotnet:$PATH" && export DOTNET_ROOT="$HOME/.dotnet"
   # Run with timeout since it's a web application
   timeout 10s dotnet run --project SampleApp.AppHost --configuration Release
   ```
   - Should start successfully and show "Now listening on: http://localhost:15289"
   - Ignore Kubernetes/DCP connection errors - these are normal in this environment

### Generated Code Validation
**MANDATORY**: After any changes to the source generator, verify that code generation still works:

1. **Check integration tests pass** - These test actual code generation scenarios
2. **Build sample application** - Uses the source generator to generate telemetry code
3. **Look for generated files** in sample app build output (EmitCompilerGeneratedFiles is enabled)

## Project Structure

### Key Directories
- `src/Purview.Telemetry.SourceGenerator/` - Main source generator implementation
- `src/Purview.Telemetry.SourceGenerator.IntegrationTests/` - Tests that validate code generation
- `samples/SampleApp/` - .NET Aspire sample application demonstrating usage
- `.github/workflows/ci.yml` - CI pipeline configuration

### Important Files
- `Makefile` - Build automation (requires bun for version commands)
- `src/Purview.Telemetry.SourceGenerator.slnx` - Main solution file
- `samples/SampleApp/SampleApp.slnx` - Sample application solution
- `global.json` - Specifies .NET SDK version requirement (9.0.200)
- `package.json` - Node.js dependencies for release management

### Generated Output
This source generator creates:
- `ActivitySource` implementations for distributed tracing
- `ILogger` implementations for structured logging  
- `Metrics` implementations for telemetry collection
- Dependency injection helper methods

## Common Tasks

### Version Management
- Check current version: `make version`
- The project uses semantic versioning managed via bun/npm scripts

### Code Style
- Uses `.editorconfig` for consistent formatting
- Always run `make format` before committing
- Tab indentation, PascalCase for public members, camelCase with _ prefix for private fields

### CI Requirements
The GitHub Actions CI pipeline (.github/workflows/ci.yml) runs:
1. `dotnet restore` 
2. `dotnet build --no-restore --configuration Release`
3. `dotnet test --no-build --verbosity normal --configuration Release`

**Always ensure your changes pass these steps locally before committing.**

### Environment Variables
Always set these environment variables when working with the project:
```bash
export PATH="$HOME/.bun/bin:$HOME/.dotnet:$PATH"
export DOTNET_ROOT="$HOME/.dotnet"
```

## Architecture Notes

This is a .NET C# source generator that:
- Analyzes interface definitions at compile time
- Generates telemetry implementation classes
- Supports multi-target generation (Activity, Logging, Metrics from single interface)
- Uses Roslyn source generators API
- Includes comprehensive integration tests using compilation verification

The integration tests are particularly important - they compile test scenarios and verify the generated output matches expected results. These tests take longer because they involve full compilation cycles but are essential for ensuring the generator works correctly.