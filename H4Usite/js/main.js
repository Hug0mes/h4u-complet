

function register() {

	var Nome = document.getElementById("Nome").value;
	var Email = document.getElementById("Email").value;
	var Password = document.getElementById("Password").value;
	var Rpassword = document.getElementById("Rpassword").value;
	var Dtn = document.getElementById("Dtn").value; //formato ano-mes-dia
	var Genero = document.getElementById("Genero").value;
	var Regiao = document.getElementById("Regiao").value;
	var Morada = document.getElementById("Morada").value;
	var Estado = document.getElementById("Morada").value;

var Estado = "inativo" ;    


    if (Password == Rpassword) {
        fetch('http://127.0.0.1:8000/api/register', {
            method: 'post',
            headers: {
                'Accept': 'application/json, text/plain, /',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Nome: Nome,
                Email: Email,
                Password: Password,
                Dtn: Dtn,
                Genero: Genero,
                Regiao: Regiao,
                Morada: Morada,
                Estado:Estado

            })
        }).then(res => res.json())
            .then(res => checkRegister(res));
    }

}

function checkRegister(res) {
    console.log(res);
    if (res.message == "CREATED") {
        alert("Conta criada com sucesso! Pode regressar á aplicação");
        location.replace("../index.html");
    } else {
        alert("Falha no registro! verifique os seus dados novamente");
    }
}
