const uri = 'http://localhost:5001/api/Banco/extrato?';
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
    dadosInvalido();
  } else if (data == 'Trazações não encontradas') {
    transacaoesNaoEncontradas();
  } else if (data.match('erros: ')) {
    exibeErro(data);
  } else {
    exibTransacoes(data);
  }
}

function exibTransacoes(data) {
  document.getElementById('transacoes').innerText = data;
  document.getElementById('transacoesForm').style.display = 'block';
  document.getElementById('dadosInvalido').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('transacaoesNaoEncontradas').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}

function exibeErro(data) {
  document.getElementById('erro').innerText = data;
  document.getElementById('transacoesForm').style.display = 'none';
  document.getElementById('dadosInvalido').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('transacaoesNaoEncontradas').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'block';
}

function dadosInvalido() {
  document.getElementById('transacoesForm').style.display = 'none';
  document.getElementById('dadosInvalido').style.display = 'block';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('transacaoesNaoEncontradas').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}

function transacaoesNaoEncontradas() {
  document.getElementById('transacoesForm').style.display = 'none';
  document.getElementById('dadosInvalido').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'none';
  document.getElementById('transacaoesNaoEncontradas').style.display = 'block';
  document.getElementById('erroDiv').style.display = 'none';
}

function camposVazios() {
  document.getElementById('transacoesForm').style.display = 'none';
  document.getElementById('saldoInvalido').style.display = 'none';
  document.getElementById('camposVazios').style.display = 'block';
  document.getElementById('transacaoesNaoEncontradas').style.display = 'none';
  document.getElementById('erroDiv').style.display = 'none';
}