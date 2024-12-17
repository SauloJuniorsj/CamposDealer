$(document).ready(function () {

    $(document).ready(function () {
        loadClientes();

        $('#btnSearchCliente').click(function () {
            loadClientes($('#searchCliente').val());
        });

        function loadClientes(query = "") {
            $.ajax({
                url: '/api/cliente/GetAll',
                data: { query: query },
                success: function (data) {
                    $('#clientesTable tbody').empty();
                    data.forEach(function (cliente) {
                        $('#clientesTable tbody').append(`
                            <tr>
                                <td>${cliente.nome}</td>
                                <td>
                                    <button onclick="editCliente(${cliente.id})">Editar</button>
                                    <button onclick="deleteCliente(${cliente.id})">Excluir</button>
                                </td>
                            </tr>
                        `);
                    });
                }
            });
        }

        window.editCliente = function (id) {
        };

        window.deleteCliente = function (id) {
            if (confirm('Você tem certeza que deseja excluir este cliente?')) {
                $.ajax({
                    url: `/api/cliente/${id}`,
                    type: 'DELETE',
                    success: function () {
                        loadClientes();
                    }
                });
            }
        };
    });
});