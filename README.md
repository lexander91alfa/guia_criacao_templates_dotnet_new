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
    "author": "Alexandre Jose dos santos",
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
- **Descrição**: Subistitui todos os nome alfa do templates pelo que você definiu no comando dotnet new alfaconsole **(-n ou --name) Teste**
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
No template: alfa.csproj

No projeto criado: Teste.csproj
```

```C#
No template:

namespace alfa;

class Program
{
    public static void Main()
    {
        Console.WriteLine("O programa alfa foi criado");
    }
}

No projeto criado:

namespace Teste;

class Program
{
    public static void Main()
    {
        Console.WriteLine("O programa Teste foi criado");
    }
}
```

## Referência

- [Wiki dotnet templates](https://github.com/dotnet/templating/wiki)
