<div align=center>
  <img src="./imagens/logo.png">
</div>


<div align="center">Banco generico Ltda.</div>

###### Nome do Sistema: Banco Ltda.
###### Estória de Usuário: 3
###### Sprint: 1
###### Nome: Saque

## Histórico
|**Versão**|**Data**|**Alteração no Documento**|**Autor**|
|------|----|---------|-----|
|1.0|08/08/21|Criação do documento|Felipe Silveira Schloegl|



**Como:** usuário do banco

**Eu quero:** ser capaz de sacar dinheiro da minha conta

**Para:** ter dinheiro físico



**Cenário 1:** Sacar o dinheiro da conta

**Dado:** que eu tenha um saldo maior ou igual ao que quero sacar

**Quando:** eu enviar um pedido de saque

**E:** informar o valor que quero sacar

**E:** informar a senha da minha conta

**Então:** o sistema deve verificar meu saldo e a senha

**E:** ver que tenho saldo e a senha foi digitada corretamente

**E:** me entregar o valor que foi solicitado

**E:** retirar aquele valor sacado da conta

**E:** enviar notificação de sucesso


**Cenário 2:** Sacar o dinheiro da conta

**Dado:** que eu tenha um saldo menor ao que quero sacar

**Quando:** eu enviar um pedido de saque

**E:** informar o valor que quero sacar

**E:** informar a senha da minha conta

**Então:** o sistema deve verificar o meu saldo e a senha

**E:** ver que não tenho saldo suficiente para a operação

**E:** enviar notificação de falha devido a falta de dinheiro na conta


**Cenário 3:** Sacar o dinheiro da conta

**Dado:** que eu tenha digitado a senha errada

**Quando:** eu enviar um pedido de saque

**E:** informar o valor que quero sacar

**E:** informar a senha da minha conta

**Então:** o sistema deve verificar o meu saldo e a senha

**E:** ver que digitei a senha errada

**E:** enviar notificação de falha devido a senha incorreta

</DIV>