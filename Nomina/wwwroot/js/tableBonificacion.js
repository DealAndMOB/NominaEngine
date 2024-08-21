document.addEventListener("DOMContentLoaded", function () {
    // Función para cargar filas desde localStorage
    function cargarFilas() {
        var tabla = document.getElementById("bonificacion").getElementsByTagName('tbody')[0];
        var filas = JSON.parse(localStorage.getItem("bonificaciones")) || [];

        filas.forEach(function (fila) {
            var nuevaFila = tabla.insertRow();
            fila.forEach(function (celdaTexto, indice) {
                var nuevaCelda = nuevaFila.insertCell(indice);
                if (indice === 0) {
                    var select = document.createElement('select');
                    select.className = "option";
                    ["Empleado 1", "Empleado 2", "Empleado 3"].forEach(function (optionText) {
                        var option = document.createElement('option');
                        option.value = optionText.toLowerCase().replace(' ', '');
                        option.text = optionText;
                        if (optionText === celdaTexto) {
                            option.selected = true;
                        }
                        select.appendChild(option);
                    });
                    nuevaCelda.appendChild(select);
                } else if (indice === 1) {
                    var input = document.createElement('input');
                    input.type = "text";
                    input.className = "form-input";
                    input.value = celdaTexto;
                    nuevaCelda.appendChild(input);
                } else if (indice === 2) {
                    var textarea = document.createElement('textarea');
                    textarea.className = "form-textarea";
                    textarea.value = celdaTexto;
                    nuevaCelda.appendChild(textarea);
                } else if (indice === 3) {
                    var inputDate = document.createElement('input');
                    inputDate.type = "date";
                    inputDate.className = "form-input";
                    inputDate.value = celdaTexto;
                    nuevaCelda.appendChild(inputDate);
                } else {
                    nuevaCelda.textContent = celdaTexto;
                }
            });
            var celdaAccion = nuevaFila.insertCell(-1);
            var botonEliminar = document.createElement('button');
            botonEliminar.className = 'btn-eliminar';
            botonEliminar.textContent = 'Eliminar';
            celdaAccion.appendChild(botonEliminar);
        });
    }

    // Función para guardar filas en localStorage
    function guardarFilas() {
        var tabla = document.getElementById("bonificacion").getElementsByTagName('tbody')[0];
        var filas = [];

        for (var i = 0; i < tabla.rows.length; i++) {
            var celdas = tabla.rows[i].cells;
            var fila = [];
            for (var j = 0; j < celdas.length - 1; j++) {
                if (j === 0) {
                    fila.push(celdas[j].children[0].selectedOptions[0].text);
                } else if (j === 1) {
                    fila.push(celdas[j].children[0].value);
                } else if (j === 2) {
                    fila.push(celdas[j].children[0].value);
                } else if (j === 3) {
                    fila.push(celdas[j].children[0].value);
                } else {
                    fila.push(celdas[j].textContent);
                }
            }
            filas.push(fila);
        }

        localStorage.setItem("bonificaciones", JSON.stringify(filas));
    }

    // Función para añadir una nueva fila
    function agregarFila() {
        // Obtener la referencia de la tabla
        var tabla = document.getElementById("bonificacion").getElementsByTagName('tbody')[0];

        // Crear una nueva fila
        var nuevaFila = tabla.insertRow();

        // Crear y agregar nuevas celdas a la fila
        var nuevaCelda1 = nuevaFila.insertCell(0);
        var nuevaCelda2 = nuevaFila.insertCell(1);
        var nuevaCelda3 = nuevaFila.insertCell(2);
        var nuevaCelda4 = nuevaFila.insertCell(3);
        //var nuevaCelda5 = nuevaFila.insertCell(4);

        // Crear el elemento select y añadir opciones
        var select = document.createElement('select');
        select.className = "option";
        ["Empleado 1", "Empleado 2", "Empleado 3"].forEach(function (optionText) {
            var option = document.createElement('option');
            option.value = optionText.toLowerCase().replace(' ', '');
            option.text = optionText;
            select.appendChild(option);
        });

        // Añadir el select a la nueva celda
        nuevaCelda1.appendChild(select);

        // Añadir contenido inicial a las otras celdas
        var inputMoonto = document.createElement('input');
        inputMoonto.type = "text";
        inputMoonto.className = "form-input";
        nuevaCelda2.appendChild(inputMoonto);
        var textareaConcepto = document.createElement('textarea');
        textareaConcepto.className = "form-textarea";
        nuevaCelda3.appendChild(textareaConcepto);
        var inputFecha = document.createElement('input');
        inputFecha.type = "date";
        inputFecha.className = "form-input";
        nuevaCelda4.appendChild(inputFecha);

        // Crear y añadir el botón de eliminar
        var celdaAccion = nuevaFila.insertCell(-1);
        var botonEliminar = document.createElement('button');
        botonEliminar.className = 'btn-eliminar';
        botonEliminar.textContent = 'Eliminar';
        celdaAccion.appendChild(botonEliminar);

        // Guardar filas en localStorage después de agregar la fila
        guardarFilas();
    }

    // Función para eliminar una fila
    function eliminarFila(event) {
        if (event.target.classList.contains('btn-eliminar')) {
            var fila = event.target.parentNode.parentNode;
            fila.parentNode.removeChild(fila);
            guardarFilas(); // Guardar filas en localStorage después de eliminar la fila
        }
    }

    // Evento al hacer clic en el botón "Agregar nueva bonificación"
    document.getElementById("newBonificacion").addEventListener("click", function () {
        agregarFila(); // Llamar a la función para agregar una nueva fila
    });

    // Evento al hacer clic en la tabla para eliminar una fila
    document.getElementById("bonificacion").addEventListener("click", function (event) {
        eliminarFila(event); // Llamar a la función para eliminar una fila
    });

    // Cargar filas al cargar la página
    cargarFilas();
});
