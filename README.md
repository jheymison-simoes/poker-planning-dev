# Yugoh Poker Planning

Este é um projeto de Poker Planning inspirado no anime Yugoh, desenvolvido usando .NET Blazor Server. O Poker Planning é uma técnica utilizada para estimar o tempo ou esforço necessário para concluir uma tarefa em desenvolvimento de software.

DEMO https://poker-planning-dev.up.railway.app/

## Funcionalidades

- **Criação de Salas:** Os usuários podem criar salas para realizar sessões de Poker Planning.
- **Estimativas:** Os participantes da sala podem fornecer estimativas para as tarefas usando cartas de poker virtuais, representando a complexidade da tarefa.
- **Fechamento Automático:** As salas são automaticamente fechadas após 3 horas de sua criação para evitar que fiquem abertas indefinidamente.
- **Hangfire:** A biblioteca Hangfire é usada para gerenciar tarefas em segundo plano, incluindo o fechamento automático das salas.

## Tecnologias Utilizadas

- **.NET Blazor Server:** Blazor Server é uma estrutura para criar aplicativos Web interativos usando C# e .NET.
- **C#:** C# é a linguagem de programação principal usada para implementar toda a lógica de negócios do projeto.
- **HTML e CSS:** Foram utilizados para criar as páginas e estilizar a interface do usuário.
- **Hangfire:** É uma biblioteca para trabalhar com tarefas em segundo plano no .NET.

## Como Usar

1. **Clone o Repositório:** `git clone https://github.com/seu-usuario/yugoh-poker-planning.git`
2. **Instale as Dependências:** Navegue até o diretório do projeto e execute `dotnet restore` para instalar as dependências do .NET.
3. **Execute o Projeto:** Execute `dotnet run` para iniciar o servidor Blazor.
4. **Acesse no Navegador:** Abra seu navegador e acesse `http://localhost:5000` para usar o aplicativo.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas (issues) e enviar pull requests para melhorar o projeto.

## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

---

**Nota:** Este projeto é uma criação inspirada por fãs e não está afiliado de nenhuma forma ao anime Yugoh ou aos criadores originais. É uma iniciativa de desenvolvedores que amam tanto poker planning quanto Yugoh!
