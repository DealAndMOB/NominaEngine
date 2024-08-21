document.addEventListener("DOMContentLoaded", function() {
    // Función para cargar filas desde localStorage
    function cargarFilas() {
        var tabla = document.getElementById("nomina").getElementsByTagName('tbody')[0];
        var filas = JSON.parse(localStorage.getItem("filas")) || [];

        filas.forEach(function(fila) {
            var nuevaFila = tabla.insertRow();
            fila.forEach(function(celdaTexto, indice) {
                var nuevaCelda = nuevaFila.insertCell(indice);
                if (indice === 0) {
                    var select = document.createElement('select');
                    select.className = "option";
                    ["Opción 1", "Opción 2", "Opción 3"].forEach(function(optionText) {
                        var option = document.createElement('option');
                        option.value = optionText.toLowerCase().replace(' ', '');
                        option.text = optionText;
                        if (optionText === celdaTexto) {
                            option.selected = true;
                        }
                        select.appendChild(option);
                    });
                    nuevaCelda.appendChild(select);
                } else if (indice === 2) {
                    var input = document.createElement('input');
                    input.type = "number";
                    input.className = "form-input";
                    input.value = celdaTexto;
                    nuevaCelda.appendChild(input);
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
        var tabla = document.getElementById("nomina").getElementsByTagName('tbody')[0];
        var filas = [];

        for (var i = 0; i < tabla.rows.length; i++) {
            var celdas = tabla.rows[i].cells;
            var fila = [];
            for (var j = 0; j < celdas.length - 1; j++) {
                if (j === 0) {
                    fila.push(celdas[j].children[0].selectedOptions[0].text);
                } else if (j === 2) {
                    fila.push(celdas[j].children[0].value);
                } else {
                    fila.push(celdas[j].textContent);
                }
            }
            filas.push(fila);
        }

        localStorage.setItem("filas", JSON.stringify(filas));
    }

    // Función para añadir una nueva fila
    function agregarFila() {
        // Obtener la referencia de la tabla
        var tabla = document.getElementById("nomina").getElementsByTagName('tbody')[0];

        // Crear una nueva fila
        var nuevaFila = tabla.insertRow();

        // Crear y agregar nuevas celdas a la fila
        var nuevaCelda1 = nuevaFila.insertCell(0);
        var nuevaCelda2 = nuevaFila.insertCell(1);
        var nuevaCelda3 = nuevaFila.insertCell(2);
        var nuevaCelda4 = nuevaFila.insertCell(3);
        var nuevaCelda5 = nuevaFila.insertCell(4);
        var nuevaCelda6 = nuevaFila.insertCell(5);
        var nuevaCelda7 = nuevaFila.insertCell(6);
        var nuevaCelda8 = nuevaFila.insertCell(7);
        var nuevaCelda9 = nuevaFila.insertCell(8);
        var nuevaCelda10 = nuevaFila.insertCell(9);

        // Crear el elemento select y añadir opciones
        var select = document.createElement('select');
        select.className = "option";
        ["Opción 1", "Opción 2", "Opción 3"].forEach(function(optionText) {
            var option = document.createElement('option');
            option.value = optionText.toLowerCase().replace(' ', '');
            option.text = optionText;
            select.appendChild(option);
        });

        // Añadir el select a la nueva celda
        nuevaCelda1.appendChild(select);

        // Añadir contenido a las otras celdas
        nuevaCelda2.textContent = "Descripción";
        var input = document.createElement('input');
        input.type = "number";
        input.className = "form-input";
        nuevaCelda3.appendChild(input);
        nuevaCelda4.textContent = "Descripción";
        nuevaCelda5.textContent = "Descripción";
        nuevaCelda6.textContent = "Descripción";
        nuevaCelda7.textContent = "Descripción";
        nuevaCelda8.textContent = "Descripción";
        nuevaCelda9.textContent = "Descripción";

        // Crear y añadir el botón de eliminar
        var botonEliminar = document.createElement('button');
        botonEliminar.className = 'btn-eliminar';
        botonEliminar.textContent = 'Eliminar';
        nuevaCelda10.appendChild(botonEliminar);

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

    // Evento al hacer clic en el botón "Agregar Empleado"
    document.getElementById("newEmpleado").addEventListener("click", function() {
        agregarFila(); // Llamar a la función para agregar una nueva fila
    });

    // Evento al hacer clic en la tabla para eliminar una fila
    document.getElementById("nomina").addEventListener("click", function(event) {
        eliminarFila(event); // Llamar a la función para eliminar una fila
    });

    // Cargar filas al cargar la página
    cargarFilas();
});
