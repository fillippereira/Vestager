$(document).ready(function () {

    function LimparFormulario() {

        $("#Endereco").val("");
        $("#Bairro").val("");
        $("#Cidade").val("");
        $("#Estado").val("");
    }

    $("#CEP").blur(function () {

        var cep = $(this).val().replace(/\D/g, '');
        if (cep != "") {

            var validacep = /^[0-9]{8}$/;

            if (validacep.test(cep)) {

                $("#Endereco").val("...");
                $("#Bairro").val("...");
                $("#Cidade").val("...");
                $("#Estado").val("...");

                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#Endereco").val(dados.logradouro);
                        $("#Bairro").val(dados.bairro);
                        $("#Cidade").val(dados.localidade);
                        $("#Estado").val(dados.uf);
                    }
                    else {
                        LimparFormulario();
                        alert("CEP não encontrado.");
                    }
                });
            }
            else {
                LimparFormulario();
                alert("Formato de CEP inválido.");
            }
        }
        else {
            LimparFormulario();
        }
    });
});