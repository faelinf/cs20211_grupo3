# Tarefa 020 - _Generics_ - 06/10/2021

1. Fazer uma pesquisa sobre o uso do conceito de _Generics_ na linguagem, plataforma, _framework_, que seu grupo está utilizando para desenvolver o projeto da API.
2. Avaliar onde, no seu projeto este conceito poderia ser implementado.
3. Elaborar um relatório informando a viabilidade ou não de se implementar, sem prejuízo tanto do escopo, quanto do prazo para a entrega do trabalho.

## Generics

### Definição

Generics em .NET são classes, estruturas, interfaces e métodos que possuem espaço reservado para um ou mais tipo que armazenam ou usam. Permitem que se personalize um método, classe, estrutura ou interface para um tipo exato de dados. Usado para especificar o tipo permitido para as chaves.
Uma classe de coleção genérica pode usar um parâmetro de tipo como um espaço reservado para o tipo de objetos que ela armazena; os parâmetros de tipo aparecem como os tipos de seus campos e os tipos de parâmetro de seus métodos. Um método genérico pode usar seu parâmetro de tipo como o tipo de seu valor de retorno ou como o tipo de um de seus parâmetros formais.
Sua principal utilização é permitir uma programação com segurança de tipos. Evitando a ocorrencia de erros devido a incompatibilidade de tipos.

### Uso no projeto

O coneito de genericos poderia ser implementado no instanciamento de variaveis e métodos da classe. Substituido a tipagem simples e o uso de 'var'. Substituição do uso de var traria mais segurança de que erros não ocorreriam. Mas não traria tantos beneficios perante a tipagem simples utilizada atualmente (String, integer, double, etc).
A implementação de Generics iria tomar uma quantia baixa de tempo, já que boa parte das variaveis e métodos declara qual tipo são usados. Sua implementação não conflitaria com o escopo pois seria apenas uma mudança em qual técnica seria usada para determinar o tipo das váriavies.

**INSTRUÇÕES**
1. Criar a pasta "tarefa020", na _branch develop_, do seu repositório do projeto do grupo.
2. _Commitar_ nesta _branch_ este arquivo "tarefa020.md", atualizado com o relatório do grupo, disposto imediatamente após o item 3.
2. O prazo para entrega desta tarefa é as 23h59min do dia 08/10/2021.