<div align=center>
  <img src="./imagens/86b143fd1ab15c437bedd634796108b0.png">
</div>


<div align="center">Banco generico Ltda.</div>

###### Nome do Sistema: Banco Ltda.
###### Estória de Usuário: 1
###### Sprint: 1
###### Nome: Operação de Transferência

## Histórico
|**Versão**|**Data**|**Alteração no Documento**|**Autor**|
|------|----|---------|-----|
|1.0|08/08/21|Criação do documento|Felipe Silveira Schloegl|



**Como:** Usuário do banco

**Eu quero:** ser capaz de fazer transferencias monetarias para outras pessoas

**Para:** Pagar quem eu devo



**Cenário 1:** Fazer uma transferencia para um terceiro

**Dado:** que eu tenha um saldo maior ou igual ao valor transferido

**E:** os dados do recebedor estejam corretos

**Quando:** eu enviar um pedido de transferencia, contendo a agencia, conta, cpf e banco do recebedor

**E:** informar o valor enviado

**Então:** verificar que tenho saldo na conta

**E:** o sistema deve verificar se os dados estão corretos

**E:** Enviar o dinheiro para o terceiro

**E:** Retirar o valor do meu saldo

**E:** Enviar notificação de sucesso


**Cenário 2:** Fazer uma transferencia para um terceiro

**Dado:** que eu tenha um saldo maior ou igual ao valor transferido

**E:** os dados do recebedor estejam incorretos

**Quando:** eu enviar um pedido de transferencia, contendo a agencia, conta, cpf e banco do recebedor

**E:** informar o valor enviado

**E:** clicar sobre o botão confirmar;

**Então:** verificar que tenho saldo na conta

**E:** o sistema deve verificar que os dados estão incorretos

**E:** Enviar notificação de falha devido a dados incorretos


**Cenário 3:** Fazer uma transferencia para um terceiro

**Dado:** que eu tenha um saldo menor que o valor transferido

**E:** os dados do recebedor estejam corretos

**Quando:** eu enviar um pedido de transferencia, contendo a agencia, conta, cpf e banco do recebedor

**E:** informar o valor enviado

**E:** clicar sobre o botão confirmar;

**Então:** verificar que não tenho saldo na conta

**E:** o sistema deve verificar se os dados estão corretos

**E:** Enviar notificação de falha devido a saldo indisponivel

</DIV>
