# IPCLocal - Biblioteca de Comunicação entre Aplicativos Console

A biblioteca IPCLocal fornece uma estrutura para comunicação entre aplicativos console em C#. Ela permite que os aplicativos enviem mensagens padronizadas uns aos outros, informando o nome do aplicativo que emitiu a mensagem e o status da execução (bem-sucedido ou com falha).

## Funcionalidades

-   Comunicação bidirecional entre aplicativos console em um ambiente local.
-   Padronização das mensagens usando um formato JSON.
-   Suporte a mensagens com informações de aplicativo, status e mensagens adicionais.

## Instalação das Dependências

Para utilizar a biblioteca IPCLocal em seu projeto, siga estas etapas:

1. Clone ou faça o download deste repositório.

2. Certifique-se de que você tenha o NuGet Package Manager instalado no Visual Studio ou use o .NET CLI para adicionar a dependência do pacote `Newtonsoft.Json`:

    ```shell
    dotnet add package Newtonsoft.Json
    ```
