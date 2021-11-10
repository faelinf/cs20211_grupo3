# Repositório cs20211_g3: Sistema Bancário

Repositório definido para a manutenção do controle de versão dos artefaos gerados na construção de uma _API Rest_, sobre um hipotético **Sistema Bancário**.

### Alunos:
Os artefatos deste projeto serão gerados pelos alunos:
|Matrícula|Nome|github user|
|--|--|--|
|202000301|FELIPE SILVEIRA SCHLOEGL|[schloegl10](https://github.com/schloegl10)|
|201611907|RAFAEL CAMPOS DE SOUZA REIS|[faelinf](https://github.com/faelinf)|
|201910909|SAMIR MONTEIRO IBRAHIM|[samirmont0](https://github.com/samirmont0)|

### _Branchs_
Este repositório conterá as seguintes branchs:
|Nome|Responsável|
|--|--|
|master|[gilmarioArantes](https://github.com/gilmarioArantes)|
|develop|[gilmarioArantes](https://github.com/gilmarioArantes)|
|felipe|[schloegl10](https://github.com/schloegl10)|
|rafael|[faelinf](https://github.com/faelinf)|
|samir|[samirmont0](https://github.com/samirmont0)|
|professor|[gilmarioArantes](https://github.com/gilmarioArantes)|

A respeito destas branchs, é importante observar:
1. Cada aluno deverá fazer operações de atualizações somente na sua _branch_;
2. De acordo com a necessidade e me conformidade com o andamento do projeto, a consolidação dos códigos produzidos pelos integrantes do grupo, poderá ser feito na branch _develop_, através da operação de _merge_ (_pull request_.
3. a atualização das demais (_master_ e _professor_) será feita através de operações de _pull request_. A atualização destas _branchs_ é prerrogatia excluiva do professor.

### _Backlog do Produto_

1. Permitir operações de:
   - Saque
   - Pagamentos
   - Deposito
   - Transferência
   - Retorno de extrato
   - Consultar saldo
2. Manter em banco:
   - lista das operações realizadas por cada usuário
   - Cartões de cada cliente
   - dados da conta (senha cartão, saldo, nome, etc.)
3. Retornar para o “cliente”:
   - Caso de sucesso:
     - retornar que a operação foi bem sucedida
     - em casos de saldo retornar o valor do saldo
     - em casos de extrato retornar o extrato bancário
   - Em caso de falha:
     - Retornar o erro (senha errada, dados errados, saldo insuficiente)
4. Operações de requisições devem passar:
   - dados do usuário
   - senha
   - tipo de operação
   - valor (em casos necessários)
   - destinatário (em casos necessários)
5. Bloquear o cartão quando 3 operações de pagamento resultarem em erro de senha para a mesma máquina e pagamento.

### Linguagem/Plataforma de programação:

### Mecanismo de Persistência:

Banco de Dados PostgreSQL

### Local do Deploy:
O deploy será local, caso necessário deploy em servidores, será usado o Amazon AWS.

### Planejamento do Desenvolvimento:

O planejamento do desenvolvimento deste projeto está descrito no seguinte [documento](**not found yet.**).
