# Elfo.ExtensionMethods

## How to add an extension method

- Every extended type has it's own project 

  i.e: 
  
  - `string` -> `Elfo.ExtensionMethods.String`
  
  - `Boolean` -> `Elfo.ExtensionMethods.Boolean`

- If the project related to your type doesn't exist, then create it (type is .NET Standard Library)

  ![Imgur](https://i.imgur.com/Bf9Sxiv.png)

  and replace the content of the `.csproj` with this:
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
      <TargetFrameworks>net40;net452;net471;netstandard2.0</TargetFrameworks>
      <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    </PropertyGroup>
    <PropertyGroup Condition=" '$(TargetFramework)' == 'net40' ">
      <DefineConstants>NET40</DefineConstants>
    </PropertyGroup>
    <PropertyGroup Condition=" '$(TargetFramework)' == 'net452' ">
      <DefineConstants>NET452</DefineConstants>
    </PropertyGroup>
    <PropertyGroup Condition=" '$(TargetFramework)' == 'net471' ">
      <DefineConstants>NET471</DefineConstants>
    </PropertyGroup>
    <PropertyGroup Condition=" '$(TargetFramework)' == 'netstandard2.0' ">
      <DefineConstants>NETSTD20</DefineConstants>
    </PropertyGroup>
  </Project>
  ```
  
  - Add a new `partial static` class with this naming convention: `*Extended type*ExtensionMethods` 
  
    i.e: `String` -> `StringExtensionMethods`
  
  - Add a new folder at the same level and with the same name of the class created above
  
  - Inside the folder, create one `.cs` file for each extension method you want to add.
  
    Name it like the method you want to create, inside the `.cs` file extend the partial class created in the step above. 
  
    Inside the class add as many overloads as you want.
  
    ![Imgur](https://i.imgur.com/tSYwJ3O.png)
