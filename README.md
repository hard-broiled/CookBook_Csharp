
Target Framework: net8.0

Contribution Guide (For Demos):
- directory structure guidance
    - feature flavor (best practice vs language feature etc.)
    - feature name (records vs structs etc)
    - mkdir <feature-flavor>/<feature-name>
    - echo "namespace Cookbook.<FeatureFlavor>.<FeatureName>;" > <feature-flavor>/<feature-name>/Demo.cs
- Make the new dotnet project for this feature/topic
    - dotnet new <project-type> -n "FeatureName" -o <feature-flavor>/<feature-name>
- Make related test project
    - mkdir -p tests/<feature-name>.tests
    - dotnet new xunit -n <FeatureName>.Tests -o tests/<feature-name>.tests
- Add new project to the sln 
    - dotnet sln add <feature-flavor>/<feature-name> #/<Feature>.csproj
- Link new tests to new project
    - dotnet add tests/<Feature>.tests/<Feature>.Tests.csproj reference <feature-flavor>/<feature-name>/<Feature>.csproj
- Test build & run for new project
    - cd <feature-flavor>/<feature-name>
    - dotnet run --project <feature-flavor>/<feature-name> # /<Feature>.csproj


- Insert script guidance for the above process Create script to scaffold new feature-flavor/feature-name project directory path, create relevant project type at that path, create related test project, add new proj to the sln, link new tests to new proj, then fire a test build and run of the hello world new project


Package Guide:
- cd <project-root> // not solution root
- dotnet add package <package-name>
- dotnet run --project \.<project-name>.csproj


High Level Directory Guide:

├── best-practices/             # Clean code, architecture, testing
│   ├── solid-principles/
│   ├── dependency-injection/
│   ├── error-handling/
│   ├── logging-structured/
│   └── unit-testing-xunit/
│
├── design-patterns/            # Commonly used design patterns
│   ├── creational/
│   │   ├── singleton/
│   │   ├── factory-method/
│   │   └── abstract-factory/
│   ├── structural/
│   │   ├── adapter/
│   │   ├── facade/
│   │   └── decorator/
│   └── behavioral/
│       ├── observer/
│       ├── strategy/
│       └── command/
│
├── contextual-examples/        # Patterns, practices, and platform context where .NET is applied. Shaping apps in real-world settings.
│   ├── cloud-platforms/            # Azure, AWX, GCP, etc.
│   ├── distributed-systems/
│   ├── container-oriented/
│   ├── microservices-arch/         # EDA, (SOA?) etc.
│   ├── SOA
│   ├── resil-observ/
│   ├── secur-ident/
│   └── enterprise/
│
├── dotnet-usage/               # Practical .NET usage
│   ├── minimal-api/
│   ├── ef-core/
│   ├── background-services/
│   ├── grpc/
│   ├── web-sockets/
│   ├── LINQ/
│   └── config-options/
│
├── integration-examples/       # How .NET apps talk to external systems & services. These examples should be self-contained “hello world” integrations with minimal dependencies, showing idiomatic usage.
│   ├── mssgQ-evntStr/              # RabbitMQ, Kafka etc.
│   ├── redis                       # separate topic flavor for redis; caching, pub-sub etc.
│   ├── datastores/
│   ├── databases/                  # (sql/nosql engines + connections as relevant) relational , non-relational, data-lakes (patterns: Delta Lake) (evolve separation between this and datastores)
│   ├── bigdata-analytics/          # Spark, Flink etc.
│   ├── search-analytics/
│   ├── cloud-services/
│   └── blockchain/
│
├── language-features/          # Modern C# syntax & constructs
│   ├── records/                # Immutable data types
│   ├── pattern-matching/       # Switch expressions, relational, type patterns
│   ├── async-streams/
│   ├── nullable-reference-types/
│   ├── file-scoped-namespaces/
│   └── source-generators/
│
├── performance-tips/           # Perf-oriented practices
│   ├── span-memory/
│   ├── value-task/
│   ├── parallel-linq/
│   └── benchmarking/
│
└── tests/