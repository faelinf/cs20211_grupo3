const uri = 'http://localhost:5001/api/Banco/saldo?';
let todos = [];
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
function buscaSaldo() {
  const dados = {
  };

  var url = uri + new URLSearchParams(dados).toString();

  fetch(url, {
    method: 'GET',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    }
  })
    .then(response => response.json())
    .then(data => {
      validaSaldo(data);
    })
    .catch(error => console.error("", error));
}

function validaSaldo(data) {
  if (data == 'Dados incorretos, não foi possivel identificar o usuário') {
    saldoInvalido();
  } else if (data.match("[\\d\\.,]+")) {
    exibeSaldo(data);
  } else {
    exibeErro(data);
  }
}

function exibeSaldo(data) {
  document.getElementById('valorSaldo').innerText = data;
  document.getElementById('saldoForm').style.display = 'block';
  document.getElementById('saldoInvalido').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}

function exibeErro(data) {
  document.getElementById('erro').innerText = data;
  document.getElementById('saldoForm').style.display = 'none';
  document.getElementById('saldoInvalido').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'block';
}

function saldoInvalido() {
  document.getElementById('saldoForm').style.display = 'none';
  document.getElementById('saldoInvalido').style.display = 'block';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}

function camposVazios() {
  document.getElementById('saldoForm').style.display = 'none';
  document.getElementById('saldoInvalido').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'block';
  document.getElementById('erroDiv').style.display = 'none';
}