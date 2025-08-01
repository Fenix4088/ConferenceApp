```bash
dotnet ef migrations add Speakers_Module_Init --startup-project ../../../Bootstraper/Confab.Bootstraper --context SpeakersDbContext -o ./DAL/Migrations

dotnet ef database update --startup-project ../../../Bootstraper/Confab.Bootstraper --context SpeakersDbContext



# Go into Core of your module and run
dotnet ef migrations add [Migration name] --startup-project ../../../Bootstraper/Confab.Bootstraper --context [DbContext name] -o ./DAL/Migrations

dotnet ef database update --startup-project ../../../Bootstraper/Confab.Bootstraper --context [DbContext name]

```