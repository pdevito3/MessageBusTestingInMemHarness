# MessageBusTestingInMemHarness

This project was created with [Craftsman](https://github.com/pdevito3/craftsman).

## Get Started

Go to your solution directory:

```shell
cd MessageBusTestingInMemHarness
```

Run your solution:

```shell
dotnet run --project YourBoundedContextName
```

## Running Integration Tests
To run integration tests:

1. Ensure that you have docker installed.
2. Go to your src directory for the bounded context that you want to test.
3. Confirm that you have migrations in your infrastructure project. If you need to add them, see the [instructions below](#running-migrations).
4. Run the tests

> ⏳ If you don't have the database image pulled down to your machine, they will take some time on the first run.

### Troubleshooting
-If you have trouble with your tests, try removing the container and volume marked for your integration tests.
- If your entity has foreign keys, you'll likely need to adjust some of your tests after scaffolding to accomodate them.

## Running Migrations

To create a new migration, make sure your environment is *not* set to `Development`:

### Powershell
```powershell
$Env:ASPNETCORE_ENVIRONMENT = "anything"
```

### Bash
```bash
export ASPNETCORE_ENVIRONMENT=anything
```

Then run the following:

```shell
cd YourBoundedContextName/src/YourBoundedContextName
dotnet ef migrations add "your-description-here"
```

To apply your migrations to your local db, run the following:

```bash
cd YourBoundedContextName/src
dotnet ef database update --project YourBoundedContextName
```
