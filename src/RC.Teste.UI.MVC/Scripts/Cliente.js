$(document).ready(function () {

    loadData();

    $('#radioSim').prop("checked");

    $('#DataNascimento').datepicker({
        showOn: "focus",
        dateFormat: "dd/mm/yy",
        dayNames: ["Domingo", "Segunda", "Terça", "Quarte", "Quinta", "Sexta", "Sábado"],
        dayNamesMin: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro']
    });

});

function loadData() {
    $.ajax({
        url: "/Clientes/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td style="display:none;">' + item.ClienteId + '</td>';
                html += '<td>' + item.Nome + '</td>';
                html += '<td>' + item.Email + '</td>';
                html += '<td>' + item.Sexo + '</td>';
                html += '<td>' + item.Cpf + '</td>';
                html += '<td>' + retornaData(item.DataNascimento) + '</td>';
                html += '<td>' + item.Ativo + '</td>';
                html += '<td><a href="#" onclick="return ObterClienteId(\'' + item.ClienteId + '\')">Editar</a> | <a href="#" onclick="Delele(\'' + item.ClienteId + '\')">Deletar</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        ClienteId: $('#ClienteId').val(),
        Nome: $('#Nome').val(),
        Email: $('#Email').val(),
        Cpf: $('#Cpf').val(),
        Sexo: $("#Sexo option:selected").val(),
        Ativo: $("input[name='Ativo']:checked").val() == "sim" ? true : false,
        DataNascimento: $('#DataNascimento').val()
    };

    $.ajax({
        url: "/Clientes/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }

    var empObj = {
        ClienteId: $('#ClienteId').val(),
        Nome: $('#Nome').val(),
        Email: $('#Email').val(),
        Cpf: $('#Cpf').val(),
        Sexo: $("#Sexo option:selected").val(),
        Ativo: $("input[name='Ativo']:checked").val() == "sim" ? true : false,
        DataNascimento: $('#DataNascimento').val()
    };
    $.ajax({
        url: "/Clientes/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ClienteId').val("");
            $('#Nome').val("");
            $('#Email').val("");
            $('#Sexo').val("");
            $('#Cpf').val("");
            $('#Ativo').val("");
            $('#DataNascimento').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function ObterClienteId(id) {
    $('#ClienteId').css('border-color', 'lightgrey');
    $('#Nome').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Sexo').css('border-color', 'lightgrey');
    $('#Cpf').css('border-color', 'lightgrey');
    $('#Ativo').css('border-color', 'lightgrey');
    $('#DataNascimento').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Clientes/ObterClienteId/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ClienteId').val(result.ClienteId);
            $('#Nome').val(result.Nome);
            $('#Email').val(result.Email);
            $('#Sexo').val(result.Sexo);
            $('#Cpf').val(result.Cpf);
            $('#Ativo').val(result.Ativo);
            $('#DataNascimento').val(retornaData(result.DataNascimento));
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Delele(id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Clientes/DeleteClinete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#ClienteId').val("");
    $('#Nome').val("");
    $('#Email').val("");
    $('#Cpf').val("");
    $('#Sexo').val("");
    $('#Ativo').val("");
    $('#DataNascimento').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Nome').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Cpf').css('border-color', 'lightgrey');
    $('#Sexo').css('border-color', 'lightgrey');
    $('#Ativo').css('border-color', 'lightgrey');
    $('#DataNascimento').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}

function validate() {
    var isValid = true;
    if ($('#Nome').val().trim() == "") {
        $('#Nome').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Nome').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#Sexo').val().trim() == "") {
        $('#Sexo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Cpf').css('border-color', 'lightgrey');
    }
    if ($('#Cpf').val().trim() == "") {
        $('#Cpf').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Cpf').css('border-color', 'lightgrey');
    }

    //if ($("input[@name='Ativo']:checked").val().trim() == "") {
    //    $("input[@name='Ativo']").css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $("input[@name='Ativo']").css('border-color', 'lightgrey');
    //}
    if ($('#DataNascimento').val().trim() == "") {
        $('#DataNascimento').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DataNascimento').css('border-color', 'lightgrey');
    }
    return isValid;
}

function retornaData(valor) {
    var dataAdmissao = valor;
    var milisegundos = parseInt(dataAdmissao.slice(dataAdmissao.indexOf('(') + 1, dataAdmissao.indexOf(')')));
    var data = new Date(milisegundos);

    return (("0" + (data.getDate())).slice(-2) + "/" + ("0" + (data.getMonth() + 1)).slice(-2)  + "/" + data.getFullYear())
}