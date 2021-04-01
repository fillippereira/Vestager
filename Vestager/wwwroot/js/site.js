// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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
});