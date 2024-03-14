# ICT2112 P3 - Module 3

## Project Structure

- Domain Layer
- Data Source Layer
- Presentation Layer

## Edits Made

1. Database changed MedicalPlan
2. appsettings.json changed logger level

## FAQ / Errors

### Creating xxxController at PresentationLayer, error when using the IxxxTDG (interface TDG).

Error here (dependency injection)
```
private readonly IMedicalPlanTDG _medicalPlanTDG;
```

1) Edit ```Program.cs```
2) Add line: 
 ```
 builder.Services.AddScoped<IxxxTDG, xxxTDG>();
 ```

### After rebuild/clean/build, no CSS found

1. Edit PresentationLayer -> ```Presentation.csproj```

2. Add this code

   ```
     <ItemGroup>
       <Folder Include="wwwroot\assets\images\" />
       <Folder Include="wwwroot\Custom" />   <!-- ADD THIS LINE -->
     </ItemGroup>
   ```