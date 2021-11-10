# Tarefa 021 - _Logging_ - 08/10/2021

1. Fazer uma pesquisa sobre o uso do conceito de _Logging_ na linguagem, plataforma, _framework_, que seu grupo está utilizando para desenvolver o projeto da API. Considere o exemplo que apresentamos em sala de aula e os arquivos disponibilizados, no caso de estarem utilizado a plataforma Java.
2. Avaliar onde, no seu projeto este conceito poderia ser implementado.
3. Elaborar um relatório informando a viabilidade ou não de se implementar, sem prejuízo tanto do escopo, quanto do prazo para a entrega do trabalho.

## Logging

### Definição

Este registro em logging é um recurso essencial nas aplicações, ele tem como principal objeitvo identificar ou investigar os possíveis problemas.
A ASP.NET Core dá suporte a uma API de Logging ou registro de atividades em log que funciona com uma variedade de provedores de logs.
No caso do APS.NET as interfaces e classes internas disponibilizadas para criação de log estão presentes e citadas abaixo,são elas:

- ILoggingFactory  
- ILoggingProvider 
- ILogger


### Uso no projeto

O conceito de logging em relação ao escopo do projeto poderia ser adicionado no projeto com o objeitvo de facilitar a identificação de possíveis problemas, saídas e também fazer o rastreamento, ou seja, correlacionado a área de segurança.
No projeto poderíamos utilizar o ILoggingFactory para criar uma instância apropriada do tipo ILogger e também para adicionar uma instância ILoggerProvider e também o ILoggerProvider para gerenciar e criar o registrador apropriado especificado pela categoria de registro.
Poderíamos utilizar o ILogger para criar um registro de log customizado você deverá estender essa interface e implementar esses métodos.  

 
**INSTRUÇÕES**
1. Criar a pasta "tarefa021", na _branch develop_, do seu repositório do projeto do grupo.
2. _Commitar_ nesta _branch_ este arquivo "tarefa021.md", atualizado com o relatório do grupo, disposto imediatamente após o item 3.
2. O prazo para entrega desta tarefa é as 23h59min do dia 08/10/2021.