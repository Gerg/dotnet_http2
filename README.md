Copied from
https://github.com/cloudfoundry/dotnet-core-buildpack/tree/539f9ea5cfc0272ae5a3df36b820578effd01d64/fixtures/source_apps/simple
with a dash of
https://github.com/cloudfoundry/dotnet-core-buildpack/tree/539f9ea5cfc0272ae5a3df36b820578effd01d64/fixtures/source_apps/source_6.0
and hacked to serve HTTP/2 over cleartext with prior knowledge.

### Running Locally

1. Install .NET Core 6.0 CLI: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
2. Make sure you see 6.0 when running: `dotnet --list-runtimes`
3. Run the app: `dotnet run`
4. Curl it via HTTP/2: `curl localhost:8080 --http2-prior-knowledge -v`

### Running on Cloud Foundry

1. `cf push dotnet --var domain=<insert domain here>`
2. `curl dotnet_http2.<insert domain here>`
