### Construção de Software - 2021/1 (ES)
### Tarefa 005
### 1 - Membros do grupo:
Felipe Silveira Schloegl 202000301
Samir Monteiro Ibrahim 201910909
Rafael Campos 201611907
### 2 - Tema:
Banco. O aplicativo será desenvolvido para representar o sistema de um banco, que
receberá informações de caixas automáticos ou máquinas de cartão para realizar
operações de pagamento, depósito ou retorno de extrato. A partir disso deve verificar se a
partir dos dados é possível realizar a operação, retornando mensagens de erro caso não
possa e realizando as operações caso seja possível.
### 3 - Requisitos
#### 1 - Permitir operações de:
1. Saque
2. Pagamentos
3. Deposito
4. Transferência
5. Retorno de extrato
6. Consultar saldo
#### 2 - Manter em banco:
1. lista das operações realizadas por cada usuário
2. Cartões de cada cliente
3. dados da conta (senha cartão, saldo, nome, etc.)
#### 3 - Retornar para o “cliente”:
Caso de sucesso:

1. retornar que a operação foi bem sucedida
2. em casos de saldo retornar o valor do saldo
3. em casos de extrato retornar o extrato bancário
Em caso de falha:

1. Retornar o erro (senha errada, dados errados, saldo insuficiente)
#### 4 - Operações de requisições devem passar:
1. dados do usuário

2. senha

3. tipo de operação

4. valor (em casos necessários)

5. destinatário (em casos necessários)

#### 5 - Bloquear o cartão quando 3 operações de pagamento resultarem em erro de senha para
a mesma máquina e pagamento.
### 4 - Mecanismo de persistência
Banco de dados SQL
### 5 - Local de deploy
O deploy será local, caso necessário deploy em servidores, será usado o Amazon AWS.