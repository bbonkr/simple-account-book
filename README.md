# Simple Account Book

## π Overview

5μ μλμ κ³ λ₯Ό μν΄ κ°νΈμ₯λΆλ₯Ό μμ±ν©λλ€.


## π¨ EF migration

```powershell
$ cd src/SimpleAccountBook.Data
$ dotnet ef migrations add "<Migration name here>" --context ApplicationDbContext --startup-project ../SimpleAccountBook.App --project ../SimpleAccountBook.Data.SqlServer --output-dir Migrations
```

μλμ κ°μ λ©μμ§κ° μΆλ ₯λλ©΄ `dotnet-ef` λκ΅¬λ₯Ό μλ°μ΄νΈν΄μΌ ν©λλ€.

```
The Entity Framework tools version '5.0.3' is older than that of the runtime '5.0.4'. Update the tools for the latest features and bug fixes.
``` 

μλ λͺλ ΉμΌλ‘ `dotnet-ef` λκ΅¬λ₯Ό μλ°μ΄νΈν  μ μμ΅λλ€.

```powershell
$ dotnet tool update --global dotnet-ef
```

