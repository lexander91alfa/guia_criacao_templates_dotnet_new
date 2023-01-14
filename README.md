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

----

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

----

#### Campos

- [Definição dos campos microsoft](https://github.com/dotnet/templating/wiki/Reference-for-template.json)

##### Identity

- **Nome**: *identity*
- **Descrição**: Indentificador único do template
- **predefinição**: :x:
- **obrigatório**: :heavy_check_mark:

**Exemplo:**

```json
{
    "identity": "MeuProjeto.Exemplo.CSharp"
}
```

##### Author

- **Nome**: *author*
- **Descrição**: Nome do autor do template
- **predefinição**: :x:
- **obrigatório**: :x:

**Exemplo:**

```json
{
    "author": "Alexandre J. Santos"
}
```

##### Classifications

- **Nome**: *classifications*
- **Descrição**: Lista de Características do template pode ser usada para buscar. Será visualizada no campos tag no dotnet new
- **predefinição**: :x:
- **obrigatório**: :x:

**Exemplo:**

```json
{
    "classifications": [ "Console", "Alfa"]
}
```

**Comando:**

```shell
dotnet new -l
```

**Saída:**

```shell
Template Name                                 Short Name      Language    Tags                      
--------------------------------------------  --------------  ----------  --------------------------
Template alfa tec                             alfaconsole     [C#]        Alfa/Console
```

----

## Referência

- [Wiki dotnet templates](https://github.com/dotnet/templating/wiki)
