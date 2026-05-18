# GraphQLBooks

GraphQLBooks is a lightweight .NET web application that exposes book and magazine data through a GraphQL API. It is built with HotChocolate and uses in-memory JSON-backed data sources to provide a simple schema for querying reading materials.

## Repository Overview

- `Program.cs`
  - Bootstraps the ASP.NET Core application.
  - Configures a GraphQL server with `Query` as the root query type.
  - Maps the GraphQL endpoint alongside a basic root health check.

- `GraphQL/Query.cs`
  - Defines query fields for `Books`, `Magazines`, `ReadingMaterials`, and `Things`.
  - Reads JSON files from the `Database/` folder and deserializes them into model objects.
  - Combines books and magazines into shared interface-based collections.

- `Models/`
  - `Book`, `Magazine`, `Author`, and `BookReview` define the domain model.
  - `IReadingMaterials` models shared fields for both books and magazines.
  - `IThings` is marked with `UnionType("Things")` for GraphQL union support.

- `Database/`
  - Contains sample JSON payloads for `books.json` and `magazines.json`.
  - The data is loaded at runtime by the GraphQL query resolvers.

## GraphQL Schema Highlights

- `Books` returns a list of `Book` objects.
- `Magazines` returns a list of `Magazine` objects.
- `ReadingMaterials` returns a mixed collection of `Book` and `Magazine` items through the `IReadingMaterials` interface.
- `Things` serves as a GraphQL union-like entry point for both books and magazines via `IThings`.

## Key Dependencies

- `HotChocolate.AspNetCore` — GraphQL server integration for ASP.NET Core.
- `HotChocolate.AspNetCore.PlayGround` — GraphQL playground UI support.
- `Microsoft.EntityFrameworkCore.InMemory` — included as an in-memory provider dependency, though data is currently driven from JSON files.

## Notes

- This repository is oriented for learning purposes around GraphQL query modeling rather than persistent database storage.
- The JSON files in `Database/` are the primary data source for the sample queries.
