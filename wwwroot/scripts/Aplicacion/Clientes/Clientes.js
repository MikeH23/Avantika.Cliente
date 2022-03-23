var urlss;
var tableCliente = $('#dtCliente').DataTable();
var _datos;
//-----------------------------------------------------------
var jClientes = (function () {
    var init = function (urls) {
        urlss = urls;
        fnObtenerClientes();
    };
    return {
        init: init,
    };

})();
//-----------------------------------------------------------
$(document).ready(function () {

    $('#btnAgregar').click(function () {
        $('#modalCliente').modal('show');
    });

    $('#btnGuardar').click(function () {
        var validar = validarFormulario();
        if (validar === true) {
            fnGuardarCliente();
        } else {
            Swal.fire({
                position: 'top-center',
                icon: 'warning',
                title: 'Favor de llenar todos los campos requeridos...',
                showConfirmButton: true,
                //timer: 2000
            });
        }
    });

    $('#btnCerrar').click(function () {
        document.getElementById('txtNumero').value = "";
        document.getElementById('txtNumero').placeholder = 'Teclee un número';
        document.getElementById('txtNombre').value = "";
        document.getElementById('txtNombre').placeholder = 'Teclee un nombre';
        document.getElementById('txtApellido').value = "";
        document.getElementById('txtApellido').placeholder = 'Teclee un apellido';
        document.getElementById('txtEdad').value = "";
        document.getElementById('txtEdad').placeholder = 'Teclee la edad';
    });

});
//-----------------------------------------------------------
$('#dtCliente').on('click', 'td.editor-delete', function () {
    var currow = $(this).closest('tr');
    var idTipo = currow.find('td:eq(0)').text();
    fnMostrarModalEliminar(idTipo);    
});
//-----------------------------------------------------------
$('#dtCliente').on('click', 'td.editor-edit', function () {
    var currow = $(this).closest('tr');
    var idTipo = currow.find('td:eq(0)').text();
    var tipoClase = currow.find('td:eq(1)').text();
    fnMostrarModalActualizar(idTipo, tipoClase);
});
//-----------------------------------------------------------
function fnObtenerClientes() {
    console.log("urlss", urlss.catClientes);

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        url: urlss.catClientes,
        async: true,
        success: function (result) {
            //var _result = JSON.stringify(result);
            //console.log("result", _result);
            CreaDataTableCientes(result);            
        },
        error: function () {
        }
    });
}
//-----------------------------------------------------------
function CreaDataTableClientes(_datos) {
    tableClases = $('#dtCliente').DataTable({  
        language: {
            emptyTable: "No hay información",
            info: "Mostrando _START_ a _END_ de _TOTAL_ Registros",
            infoEmpty: "Mostrando 0 to 0 of 0 Registros",
            infoFiltered: "(Filtrado de _MAX_ total entradas)",
            lengthMenu: "Mostrar _MENU_ Registros",
            loadingRecords: "Cargando...",
            processing: "Procesando...",
            zeroRecords: "Sin resultados encontrados",
            paginate: {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        data: _datos,
        destroy: true,
        //columnDefs: [
        //    {
        //        "visible": false,
        //        "targets": [0]
        //    }
        //],
        columns: [
            { data: "IdCliente", name: "IdCliente" },
            { data: "Nombre", name: "Nombre" },
            { data: "Apellidos", name: "Apellido" },
            { data: "Edad", name: "Edad" },
            {
                data: null, className: "editor-delete", 'width': "5%",
                defaultContent: '<a class="btn btn-outline-danger btn-sm btn-icon waves-effect waves-themed" href="javascript:void(0);"><i class="fal fa-times"></i></a>',
            },
            {
                data: null, className: "dt-center editor-edit", 'width': "5%",
                defaultContent: '<a class="btn btn-outline-warning btn-sm btn-icon waves-effect waves-themed" href="javascript:void(0);"><i class="fal fa-pencil"></i></a>',
            }
        ],        
    });
}
//-----------------------------------------------------------
function fnGuardarTipoClases() {
    console.log("urlss", urlss.saveClases);

    var strTiposClase = $("#txtClase").val();
    var urlGuardar = urlss.saveClases + "?strTiposClase=" + strTiposClase;
    $("#modalClase").disabled;

    $(".k-overlay").show();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: urlGuardar,
        async: true,
        success: function (data) {
            $(".k-overlay").hide();
            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: 'Registro guardado con éxito...',
                showConfirmButton: false,
                timer: 2000
            }),
            $("#txtClase").val("");
            $('#modalClase').modal('hide');
            CreaDataTableClases(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(".k-overlay").hide();
            Swal.fire({
                position: 'top-center',
                icon: 'error',
                title: xhr.responseText.substring(0,xhr.responseText.indexOf("?")),
                showConfirmButton: false,
                timer: 4000
            }),
            $("#txtClase").val("");
            $('#modalClase').modal('hide');
            console.log("xhr", xhr);
            console.log("ajaxOptions", ajaxOptions);
            console.log("thrownError", thrownError);
        },
    });
}
//-----------------------------------------------------------
function fnMostrarModalEliminar(idTipo) {
    $('#modalEliminar').modal('show');
    $('#btnEliminar').click(function () {
        fnEliminarClase(idTipo);
    });
}
//-----------------------------------------------------------
function fnMostrarModalActualizar(idTipoClase, tipoClase) {
    $('#modalActualizar').modal('show');
    $("#txtActualizaClase").val(tipoClase);
    $('#btnActualizar').click(function () {
        var strTipoClase = $("#txtActualizaClase").val();
        fnActualizarClase(idTipoClase, strTipoClase);
    });
}
//-----------------------------------------------------------
function fnEliminarClase(idTipoClase) {
    console.log("urlss", urlss.eliminarClases);

    $(".k-overlay").show();

    var urlEliminar = urlss.eliminarClases + "?idTipoClase=" + idTipoClase;

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: urlEliminar,
        async: true,
        success: function (data) {
            $(".k-overlay").hide();

            $('#modalEliminar').modal('hide');
            CreaDataTableClases(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(".k-overlay").hide();

            console.log("xhr", xhr);
            console.log("ajaxOptions", ajaxOptions);
            console.log("thrownError", thrownError);
        },
    });
}
//-----------------------------------------------------------
function fnActualizarClase(idTipoClase, tipoClase) {
    console.log("urlss", urlss.actualizarClases);

    $(".k-overlay").show();

    var strTiposClase = tipoClase;
    var urlActualiza = urlss.actualizarClases + "?idTipoClase=" + idTipoClase + "&" + "strActualizaTiposClase=" + strTiposClase;    

    $.ajax({
        type: "POST",
        url: urlActualiza,
        contentType: "application/json; charset=utf-8",
        dataType: "json",        
        async: true,
        success: function (data) {
            $(".k-overlay").hide();

            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: 'Registro actualizado con éxito...',
                showConfirmButton: false,
                timer: 2000
            }),
            $("#txtActualizaClase").val("");
            $('#modalActualizar').modal('hide');
            CreaDataTableClases(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $(".k-overlay").hide();

            Swal.fire({
                position: 'top-center',
                icon: 'error',
                title: 'El registro no se actualizo...',
                showConfirmButton: false,
                timer: 2000
            }),
            console.log("xhr", xhr);
            console.log("ajaxOptions", ajaxOptions);
            console.log("thrownError", thrownError);
        },
    });
}
//-----------------------------------------------------------
function validarFormulario() {
    var todo_correcto = true;

    if (document.getElementById("txtNumero").value.length === 0) {
        todo_correcto = false;
    }

    if (document.getElementById("txtNombre").value.length === 0) {
        todo_correcto = false;
    }

    if (document.getElementById("txtApellido").value.length === 0) {
        todo_correcto = false;
    }

    if (document.getElementById("txtEdad").value.length === 0) {
        todo_correcto = false;
    }

    return todo_correcto;
}
//-----------------------------------------------------------