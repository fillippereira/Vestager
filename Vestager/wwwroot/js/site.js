// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


$(document).ready(function () {
    $('.table').DataTable({
        "language": {
            "search": "Pesquisar:",
            "zeroRecords": "Nenhum resultado encontrado",
            "lengthMenu": "Mostrar _MENU_ resultados",
            "loadingRecords": "Carregando...",
            "processing": "Processando...",
            "emptyTable": "Nenhum dado disponível na tabela",
            "info": "Exibindo _START_ a _END_ de _TOTAL_ resultados",
            "infoEmpty": "Exibindo 0 a 0 de 0 resultados",
            "infoFiltered": "(filtrado de _MAX_ entradas)",
            "paginate": {
                "previous": "Anterior",
                "next": "Próximo"
            }
        }
    });

    function readURL(input) {
        var url = input.value;
        var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
        if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#previewImagem').attr('src', e.target.result);
                $('#lblImagemVestido').html(url.split('\\')[2]);
                $('#UrlVestido').val(url.split('\\')[2]);
            }

            reader.readAsDataURL(input.files[0]);
        } else {
            $('#previewImagem').attr('src', '~/images/nenhuma_imagem.jpg');
        }
    }

    $("#imagemVestido").change(function () {
        readURL(this);
    });
});


