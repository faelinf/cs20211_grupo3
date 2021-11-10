<div align=center>
  <img src="./imagens/banco.png">
</div>



<div align="center">Banco generico Ltda.</div>


###### Nome do Sistema: Banco Ltda.
###### Estória de Usuário: 5
###### Sprint: 1
###### Nome: Depósito

## Histórico
|**Versão**|**Data**|**Alteração no Documento**|**Autor**|
|------|----|---------|-----|
|1.0|09/08/2021|Criação do documento| Rafael |





**Como:** Usuário do sistema bancário

**Eu quero:** ser capaz de realizar um depósito.

**Para:** alimentar o saldo da minha conta.



**Cenário 1:** Relizar depósito na minha conta;

**Dado:** que eu tenha o dinheiro em mãos para depositar;

**E:** tenha os dados da minha conta;

**Quando:** eu estiver com o envelope de depósito, e meus dados bancários;

**E:** informar o valor desejado para depósito;

**E:** inserir o envelope no caixa eletrônico;

**Então:** após a validação, o valor deve cair na minha conta;

**E:** E receber o dinheiro em conta.

**E:** E receber notificação de sucesso na operação de depósito.

**Cenário 2:** Relizar depósito na minha conta;

**Dado:** que eu tenha o dinheiro em mãos para depositar;

**E:** os dados da minha conta estejam incorretos;

**Quando:** eu estiver com o envelope de depósito, e meus dados bancários;

**E:** informar o valor desejado para depósito;

**E:** inserir o envelope no caixa eletrônico;

**Então:** sistema analisa;

**E:** E sistema mostra que os dados estão incorretos.

**E:** E sistema notifica que não foi possível realizar a operação por conta dos dados incorretos.

**Cenário 3:** realizar depósito para conta de terceiros

**Dado:** que eu tenha o dinheiro em mãos para depositar;

**E:** os dados da conta do remetente estejam corretos;

**Quando:** eu estiver com o envelope de depósito, e meus dados bancários;

**E:** informar o valor desejado para depósito;

**E:** inserir as informações de conta do remetente;

**Então:** sistema valida os dados inseridos;

**E:** E sistema mostra que os dados estão corretos.

**E:** E sistema notifica que o valor foi enviado para a conta do remetente.

**Cenário 4:** realizar depósito para conta de terceiros

**Dado:** que eu tenha o dinheiro em mãos para depositar;

**E:** os dados da conta do remetente estejam incorretos;

**Quando:** eu estiver com o envelope de depósito, e meus dados bancários do remetente;

**E:** informar o valor desejado para depósito;

**E:** inserir as informações de conta do remetente;

**Então:** sistema valida no banco que os dados inseridos estão incorretos;

**E:** E sistema mostra que os dados estão incorretos.

**E:** E sistema notifica que o valor não foi enviado por conta dos dados inseridos estarem incorretos.








</DIV>
