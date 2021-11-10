const uri = 'http://localhost:5001/api/Banco/login?';
let todos = [];

function login() {
  const agencia = document.getElementById('agencia');
  const conta = document.getElementById('conta');
  const senha = document.getElementById('senha');
  const dados = {
    agencia: agencia.value.trim(),
    conta: conta.value.trim(),
    senha: senha.value.trim()
  };

  if (dados.agencia == '' || dados.conta == '' || dados.senha == '') {
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
        agencia.value = '';
        conta.value = '';
        senha.value = '';
        validaSaldo(data);
      })
      .catch(error => console.error("", error));
  }
}

function validaSaldo(data) {
  if (data == "sucesso"){
    sucesso();
  } else {
    exibeErro(data);
  }
}

function sucesso(data) {
  window.location.href = "http://localhost:5001/home";
}

function exibeErro(data) {
  document.getElementById('erro').innerText = data;
  document.getElementById('erroDiv').style.display = 'block';
}