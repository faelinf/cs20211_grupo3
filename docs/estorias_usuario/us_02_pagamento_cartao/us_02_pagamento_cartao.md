<div align=center>
  <img src="./imagens/86b143fd1ab15c437bedd634796108b0.png">
</div>


<div align="center">Banco generico Ltda.</div>

###### Nome do Sistema: Banco Ltda.
###### Estória de Usuário: 2
###### Sprint: 1
###### Nome: Operação de Pagamento com cartão

## Histórico
|**Versão**|**Data**|**Alteração no Documento**|**Autor**|
|------|----|---------|-----|
|1.0|08/08/21|Criação do documento|Felipe Silveira Schloegl|



**Como:** API de pagamento ou maquina de cartão de credito

**Eu quero:** ser capaz de fazer pagamentos usando dados do cartão

**Para:** Pagar compras



**Cenário 1:** Realizar um pagamento de uma compra utilizando o cartão de debito

**Dado:** saldo maior ou igual ao valor

**E:** a senha esteja correta

**E:** dados do cartão correto

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** verificar se a senha está correta

**E:** se o saldo atual da conta é maior que o valor

**E:** se existe alguma conta com dados do recebedor

**E:** retirar o valor da transferencia do saldo da conta

**E:** adicionar ao saldo do recebedor o valor da transferencia

**E:** Enviar notificação de sucesso;



**Cenário 2:** Realizar um pagamento de uma compra utilizando o cartão de credito

**Dado:** limite do cartão maior ou igual ao valor

**E:** a senha esteja correta

**E:** dados do cartão correto

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** verificar se a senha está correta

**E:** se o limite do cartão é maior que o valor

**E:** se existe alguma conta com dados do recebedor

**E:** adicionar o valor da transferencia como uma pendência

**E:** adicionar ao saldo do recebedor o valor da transferencia

**E:** Enviar notificação de sucesso;



**Cenário 3:** Realizar um pagamento de uma compra utilizando o cartão de debito

**Dado:** saldo menor ao valor

**E:** a senha esteja correta

**E:** dados do cartão correto

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** verificar se a senha está correta

**E:** que o saldo atual da conta é menor que o valor

**E:** Enviar notificação de falha, devido a saldo insuficiente



**Cenário 4:** Realizar um pagamento de uma compra utilizando o cartão de debito

**Dado:** saldo maior ou igual ao valor

**E:** a senha esteja incorreta

**E:** dados do cartão correto

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** verificar se a senha está correta

**E:** Enviar notificação de falha devido a senha incorreta;




**Cenário 5:** Realizar um pagamento de uma compra utilizando o cartão de debito

**Dado:** saldo maior ou igual ao valor

**E:** a senha esteja correta

**E:** dados do cartão correto

**E:** dados do recebedor incorretos

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** verificar se a senha está correta

**E:** se o saldo atual da conta é maior que o valor

**E:** se existe alguma conta com dados do recebedor

**E:** Enviar notificação de falha devido a recebedor inexistente;




**Cenário 6:** Realizar um pagamento de uma compra utilizando o cartão de debito

**Dado:** saldo maior ou igual ao valor

**E:** a senha esteja correta

**E:** dados do cartão incorreto

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** Enviar notificação de falha, devido a cartão inexistente;



**Cenário 7:** Realizar um pagamento de uma compra utilizando o cartão de crédito

**Dado:** limite menor que valor

**E:** a senha esteja correta

**E:** dados do cartão correto

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** verificar se a senha está correta

**E:** que o limite é menor que o valor

**E:** Enviar notificação de falha, devido a limite de crédito insuficiente



**Cenário 8:** Realizar um pagamento de uma compra utilizando o cartão de crédito

**Dado:** limite maior ou igual ao valor

**E:** a senha esteja incorreta

**E:** dados do cartão correto

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** verificar se a senha está correta

**E:** Enviar notificação de falha devido a senha incorreta;




**Cenário 9:** Realizar um pagamento de uma compra utilizando o cartão de crédito

**Dado:** saldo maior ou igual ao valor

**E:** a senha esteja correta

**E:** dados do cartão correto

**E:** dados do recebedor incorretos

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** verificar se a senha está correta

**E:** se o limite de crédito da conta é maior que o valor

**E:** se existe alguma conta com dados do recebedor

**E:** Enviar notificação de falha devido a recebedor inexistente;




**Cenário 10:** Realizar um pagamento de uma compra utilizando o cartão de crédito

**Dado:** limite de crédito maior ou igual ao valor

**E:** a senha esteja correta

**E:** dados do cartão incorreto

**Quando:** Passar os dados do cartão: numero, nome, data de validade, Codigo verificador e tipo do cartão

**E:** informar o valor

**E:** informar a senha

**E:** informar dados da conta do recebedor

**Então:** verificar se existe algum cartão com esses dados

**E:** Enviar notificação de falha, devido a cartão inexistente;

</DIV>
