const uri = 'http://localhost:5001/api/Banco/transferencia?';
const uriLogin = 'http://localhost:5001/api/Banco/validacao?';
var myFunc = function () {
  const dados = {
  };
  var url = uriLogin + new URLSearchParams(dados).toString();

  fetch(url, {
    method: 'GET',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    }
  })
    .then(response => response.json())
    .then(data => {
      validaLogin(data);
    })
    .catch(error => console.error("", error));
}();

function validaLogin(data) {
  if (data != "sucesso") {
    falhaLogin();
  }
}

function falhaLogin() {
  window.location.href = "http://localhost:5001/index.html";
}
function operacao() {
  const valor = document.getElementById('valor');
  const agenciaDestino = document.getElementById('agenciaDestino');
  const contaDestino = document.getElementById('contaDestino');
  const CPFDestinatario = document.getElementById('CPFDestinatario');
  const dados = {
    valor: valor.value.trim(),
    agenciaDestino: agenciaDestino.value.trim(),
    contaDestino: contaDestino.value.trim(),
    CPFDestinatario: CPFDestinatario.value.trim()
  };

  if (dados.valor == ''|| dados.agenciaDestino == '' || dados.contaDestino == '' || dados.CPFDestinatario == '') {
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
        agenciaDestino.value = '';
        contaDestino.value = '';
        CPFDestinatario.value = '';
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
  } else if (data == 'Operação realizada com sucesso') {
    exibeSaldo(valor);
  } else {
    falha(data);
  }
}

function exibeSaldo(valor) {
  document.getElementById('valorTransferencia').innerText = valor;
  document.getElementById('sucesso').style.display = 'block';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'none';
}

function falha(data) {
  document.getElementById('erro').innerText = data;
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'block';
}

function saldoInsuficiente() {
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'block';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'none';
}

function dadosIncorretos() {
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'block';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('falha').style.display = 'none';
}

function camposVazios() {
  document.getElementById('sucesso').style.display = 'none';
  document.getElementById('saldoInsuficiente').style.display = 'none';
  document.getElementById('dadosErrados').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'block';
  document.getElementById('falha').style.display = 'none';
}