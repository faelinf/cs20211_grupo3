<div align=center>
  <img src="./imagens/banco.png">
</div>


<div align="center">Banco generico Ltda.</div>


###### Nome do Sistema: Banco Ltda.
###### Estória de Usuário: 6
###### Sprint: 1
###### Nome: Retorno de Extrato

## Histórico
|**Versão**|**Data**|**Alteração no Documento**|**Autor**|
|------|----|---------|-----|
|1.0|09/08/2021|Criação do documento| Rafael |



**Como:** usuário do banco

**Eu quero:** consultar o extrato da minha conta corrente.

**Para:** consultar os lançamentos realizados e meu saldo.



**Cenário 1:** Visualizar Extrato

**Dado:** que eu tenha uma conta cadastrada no banco

**E:** tenha o login e senha da conta do banco;

**Quando:** eu acessar o sistema bancários com login e senha;

**E:** selecionar a opção extrato;

**Então:** o sistema deve me mostrar o extrato nos últimos 30 dias;


**Cenário 2:** Visualizar lançamentos anteriores

**Dado:** que eu tenha uma conta cadastrada no banco

**E:** tenha o login e senha da conta do banco;

**Quando:** eu acessar o sistema bancários com login e senha;

**E:** selecionar a opção extrato;

**E:** defina no filtro qual mês deseja visualizar o extrato;

**E:** selecionar a botão confirmar;

**Então:** o sistema deve me mostrar o extrato do mês selecionado;



</DIV>
