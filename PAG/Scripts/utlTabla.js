//Es necesario incluir: dataTables.bootstrap.min.js y jquery.dataTable.min.js
var Tabla = {
    DataTableEspanol: function (objeto) {
        objeto.DataTable({
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "_START_ al _END_ . Total _TOTAL_ ",
                "sInfoEmpty": "Del 0 al 0 Total 0",
                "sInfoFiltered": "(Filtrado de _MAX_ )",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }

            }
        });

    }
    , DataTableEspanolFilaSeleccionable: function (objeto) {
        objeto.DataTable({
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "_START_ al _END_ . Total _TOTAL_ ",
                "sInfoEmpty": "Del 0 al 0 Total 0",
                "sInfoFiltered": "(Filtrado de _MAX_ )",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }

            }
            , select: {
                style: 'single'
            }
        });

    },
    DataTableEspanolAngular: function (objeto) {
        if (!$.fn.DataTable.isDataTable("#" + objeto)) {


            $("#" + objeto).DataTable({
                "language": {
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                    "sInfo": "_START_ al _END_ . Total _TOTAL_ ",
                    "sInfoEmpty": "Del 0 al 0 Total 0",
                    "sInfoFiltered": "(Filtrado de _MAX_ )",
                    "sInfoPostFix": "",
                    "sSearch": "Filtrar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                },
                "columnDefs": [
                                { "orderable": false, "targets": 0 }
                ],
                "order": []
            });
        }

    },
    DataTableDestroy: function (objeto) {
        if ($.fn.DataTable.isDataTable("#" + objeto)) {
            $("#" + objeto).DataTable().destroy();
        }
    }

}