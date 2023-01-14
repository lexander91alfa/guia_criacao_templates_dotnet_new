# Guia criação templates dotnet new

Guia para Criação de templates no cli do dotnet.

## Criação do Template para dotnet new

### Criação do template.json

- Na pasta principal do template criar uma pasta chamada **.template.config**
- Criar um arquivo chamado **template.json** dentro da pasta criada anteriomente

#### pasta e arquivo depois de criado

```shell
.
└── exemplo_templates
   └── .template.config
       └── template.json
```

### Criação do conteudo do template.json

#### Exemplo template.json

```json
{
    "$schema": "http://json.schemastore.org/template",
    "author": "Alexandre J. santos",
    "classifications": [
        "Alfa",
        "Console"
    ],
    "identity": "Alfa.ConsoleAlfaTemplate.CSharp",
    "name": "Template alfa tec",
    "shortName": "alfaconsole",
    "sourceName": "alfa",
    "tags": {
        "language": "C#",
        "type": "project"
    },
    "symbols": {
        "autor": {
            "type": "parameter",
            "description": "autor do projeto",
            "defaultValue": "Alexandre",
            "replaces": "nome",
            "datatype": "text"
        },
        "preto": {
            "type": "parameter",
            "datatype": "bool",
            "defaultValue": "false"
        }
    }
}
```

### Campos

- [Definição dos campos microsoft](https://github.com/dotnet/templating/wiki/Reference-for-template.json)

#### Identity

- **Nome**: *identity*
- **Descrição**: Indentificador único do template
- **predefinição**: :x:
- **obrigatório**: :heavy_check_mark:

Exemplo:

```json
"identity": "MeuProjeto.Exemplo.CSharp"
```

#### Author

- **Nome**: *author*
- **Descrição**: Nome do autor do template
- **predefinição**: :x:
- **obrigatório**: :x:

Exemplo:

```json
"author": "Alexandre J. Santos"
```

#### Classifications

- **Nome**: *classifications*
- **Descrição**: Lista de Características do template. Será mostrado no campo **Tags** dos templates quando usar o comando dotnet new -l
- **predefinição**: :x:
- **obrigatório**: :x:

Exemplo:

```json
"classifications": [ "Console", "Alfa"]
```

Comando:

```shell
dotnet new -l
```

Saída:

```shell
Template Name                                 Short Name      Language    Tags                      
--------------------------------------------  --------------  ----------  --------------------------
Template alfa tec                             alfaconsole     [C#]        > Alfa/Console <
```

#### Name

- **Nome**: *name*
- **Descrição**: Nome completo do template, será mostrado no campo **Template Name** quando utilizar o comando dotnet new -l
- **predefinição**: :x:
- **obrigatório**: :heavy_check_mark:

Exemplo:

```json
"name": "Template alfa tec"
```

Comando:

```shell
dotnet new -l
```

Saída:

```shell
Template Name                                 Short Name      Language    Tags                      
--------------------------------------------  --------------  ----------  --------------------------
> Template alfa tec <                         alfaconsole     [C#]        Alfa/Console
```

#### ShortName

- **Nome**: *shortName*
- **Descrição**: Nome abrevidado do template, será mostrado no campo **Short Name** quando utilizar o comando dotnet new -l
- **predefinição**: :x:
- **obrigatório**: :heavy_check_mark:

Exemplo:

```json
"name": "Template alfa tec"
```

Comando:

```shell
dotnet new -l
```

Saída:

```shell
Template Name                                 Short Name      Language    Tags                      
--------------------------------------------  --------------  ----------  --------------------------
Template alfa tec                             > alfaconsole < [C#]        Alfa/Console
```

#### SourceName

- **Nome**: *sourceName*
- **Descrição**: Subistitui todos os nome alfa do templates pelo que você definiu no comando dotnet new alfaconsole **(-n ou --name) [nome do projeto]**
- **predefinição**: :x:
- **obrigatório**: :x:

Exemplo:

```json
"sourceName": "alfa"
```

Comando:

```shell
dotnet new alfaconsole -n Teste
```

Saída:

```shell
No template: 
.
├── alfa.csproj
├── Program.cs
└── .template.config
    └── template.json

No projeto criado:
.
├── Teste.csproj
└── Program.cs
```

```C#
No template:

namespace alfa;

class Program
{
    public static void Main()
        => Console.WriteLine("O programa alfa foi criado");
}

No projeto criado:

namespace Teste;

class Program
{
    public static void Main()
        => Console.WriteLine("O programa Teste foi criado");
}
```

#### Tags

- **Nome**: *tags*
- **Descrição**: Metadados do projeto
- **predefinição**: :x:
- **obrigatório**: :x:

Exemplo:

```json
"tags": {
        "language": "C#",
        "type": "project"
    },
```

#### Schema

- **Nome**: *$schema*
- **Descrição**: JSON esquema do template, para ser usado no IntelliSense de editores como VS Code.
- **predefinição**: :x:
- **obrigatório**: :x:

Exemplo:

```json
"$schema": "http://json.schemastore.org/template"
```

#### symbols

- **Nome**: *symbols*
- **Descrição**: Define variaveis e seus valores.
- **predefinição**: :x:
- **obrigatório**: :x:

Exemplo1 - alterando nome dentro do Program.cs:

```json
"symbols": {
        "autor": {
            "type": "parameter",
            "description": "autor do projeto",
            "defaultValue": "Alexandre",
            "replaces": "nome",
            "datatype": "text"
        }
    }
```

Comando:

```shell
dotnet new alfaconsole -h
```

Saída:

```shell
Template alfa tec (C#)
Author: Alexandre Jose dos santos
Options:                         
  -au|--autor  autor do projeto  
               text - Optional   
               Default: Alexandre
```

Comando:

```shell
dotnet new alfaconsole -n Teste -au "Alexandre Santos"
```

Saída:

```C#
No template

namespace alfa;

class Program
{
    public static void Main()
    {
        Console.WriteLine("O programa alfa foi criado");
        Console.WriteLine("Autor: nome");
    }
}

No projeto criado

namespace Teste;

class Program
{
    public static void Main()
    {
        Console.WriteLine("O programa alfa foi criado");
        Console.WriteLine("Autor: Alexandre Santos");
    }
}
```

Exemplo2 - incluindo codigo no Program.cs:

```json
"symbols": {
        "preto": {
            "type": "parameter",
            "datatype": "bool",
            "defaultValue": "false"
        }
    }
```

Comando:

```shell
dotnet new alfaconsole -n Teste -p true
```

Saída:

```C#
No template

namespace alfa;

class Program
{
    public static void Main()
    {
        Console.WriteLine("O programa alfa foi criado");
        Console.WriteLine("Autor: nome");
    #if (preto)
        Console.WriteLine("escolheu a cor preta");
    #endif
    }
}

No projeto criado

Com -p false

namespace Teste;

class Program
{
    public static void Main()
    {
        Console.WriteLine("O programa alfa foi criado");
        Console.WriteLine("Autor: Alexandre");
    }
}


Com -p true

namespace Teste;

class Program
{
	public static void Main()
	{
		Console.WriteLine("O programa testeoi foi criado");
		Console.WriteLine("Autor: Alexandre");
		Console.WriteLine("escolheu a cor preta");
	}
}
```

## Referência

- [Wiki dotnet templates](https://github.com/dotnet/templating/wiki)
