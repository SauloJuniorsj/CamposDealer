$(document).ready(function () {

    $('#clienteForm').submit(function (e) {
        e.preventDefault();
        const cliente = {
            id: $('#clienteId').val(),
            nome: $('#nome').val(),
        };

        $.ajax({
            url: cliente.id ? `/api/cliente/${cliente.id}` : '/api/cliente',
            type: cliente.id ? 'PUT' : 'POST',
            contentType: 'application/json',
            data: JSON.stringify(cliente),
            success: function () {
                loadClientes();
                $('#clienteForm')[0].reset();
            }
        });
    });
});