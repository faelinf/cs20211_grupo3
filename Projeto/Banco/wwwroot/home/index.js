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