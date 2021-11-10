const uri = 'http://localhost:5001/api/Banco/saque?';
let todos = [];

function operacao() {
  const valor = document.getElementById('valor');
  const dados = {
    valor: valor.value.trim()
  };

  if (dados.valor == '') {
    camposVazios();
  } else {

    var url = uri + new URLSearchParams(dados).toString();

    fetch(url, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
    })
      .then(response => response.json())
      .then(data => {
        valida(data, valor.value);
        valor.value = '';
      })
      .catch(error => console.error("", error));
  }
}

function valida(data, valor) {
  if (data == 'saldo insuficiente') {
    saldoInsuficiente();
  } else if (data == 'Dados incorretos, não foi possivel identificar o usuário') {
    dadosIncorretos();
  } else if (data == 'Erro ao realizar operacao') {
    falha();
  } else if (data == 'Operação realizada com sucesso') {
    exibeSaldo(valor);
  } else {
    exibeErro(data);
  }
}

function exibeSaldo(valor) {
  document.getElementById('valorSaque').innerText = valor;
  document.getElementById('sucesso').style.display = 'block';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}

function falha() {
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'block';
  document.getElementById('erroDiv').style.display = 'none';
}

function saldoInsuficiente() {
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'block';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}

function exibeErro(valor) {
  document.getElementById('erro').innerText = valor;
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'block';
}

function dadosIncorretos() {
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'block';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}

function camposVazios() {
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'block';
  document.getElementById('falha').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}