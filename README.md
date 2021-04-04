# Simple Account Book

## 🌈 Overview

5월 소득신고를 위해 간편장부를 작성합니다.


## 🔨 EF migration

```powershell
$ cd src/SimpleAccountBook.Data
$ dotnet ef migrations add "<Migration name here>" --context ApplicationDbContext --startup-project ../SimpleAccountBook.App --project ../SimpleAccountBook.Data.SqlServer --output-dir Migrations
```

아래와 같은 메시지가 출력되면 `dotnet-ef` 도구를 업데이트해야 합니다.

```
The Entity Framework tools version '5.0.3' is older than that of the runtime '5.0.4'. Update the tools for the latest features and bug fixes.
``` 

아래 명령으로 `dotnet-ef` 도구를 업데이트할 수 있습니다.

```powershell
$ dotnet tool update --global dotnet-ef
```

