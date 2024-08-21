document.addEventListener('DOMContentLoaded', function () {
    function verificarTamanoPantalla(config) {
        const { idTabla, clasePaginacion, claseMax, claseMin, idSelect, filasPorPaginaDesktop, filasPorPaginaMobile } = config;
        let anchoPantalla = window.innerWidth;
        let tabla = document.getElementById(idTabla);
        if (!tabla) {
            return;
        }

        let filasPorPagina;
        var max = document.querySelectorAll(claseMax);
        var min = document.querySelectorAll(claseMin);

        if (anchoPantalla <= 1280) {
            filasPorPagina = filasPorPaginaMobile;
            max.forEach(function (elemento) {
                elemento.classList.add('d-none');
            });
            min.forEach(function (elemento) {
                elemento.classList.remove('d-none');
            });
        } else {
            filasPorPagina = filasPorPaginaDesktop;
            max.forEach(function (elemento) {
                elemento.classList.remove('d-none');
            });
            min.forEach(function (elemento) {
                elemento.classList.add('d-none');
            });
        }

        function actualizarPaginacion() {
            let filasDatos = tabla.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
            let totalFilas = filasDatos.length;
            if (totalFilas === 0) {
                return;
            }

            let totalPaginas = Math.ceil(totalFilas / filasPorPagina);

            var paginacion = document.querySelector(clasePaginacion);
            paginacion.innerHTML = '';

            for (var i = 1; i <= totalPaginas; i++) {
                var enlace = document.createElement('a');
                enlace.href = '#';
                enlace.textContent = i;
                enlace.onclick = (function (pagina) {
                    return function () {
                        mostrarPagina(pagina);
                    };
                })(i);
                paginacion.appendChild(enlace);
            }

            mostrarPagina(1);
        }

        function mostrarPagina(numeroPagina) {
            let filasDatos = tabla.getElementsByTagName('tbody')[0].getElementsByTagName('tr');


            for (var i = 0; i < filasDatos.length; i++) {
                filasDatos[i].style.display = 'none';
            }

            var inicio = (numeroPagina - 1) * filasPorPagina;
            var fin = inicio + filasPorPagina;
            for (var i = inicio; i < fin && i < filasDatos.length; i++) {
                filasDatos[i].style.display = 'table-row';
            }

            var enlacesPaginacion = document.querySelectorAll(clasePaginacion + ' a');
            enlacesPaginacion.forEach(function (enlace) {
                enlace.classList.remove('active');
            });
            enlacesPaginacion[numeroPagina - 1].classList.add('active');
        }

        function cambiarFilasPorPagina() {
            var select = document.getElementById(idSelect);
            filasPorPagina = parseInt(select.value);
            actualizarPaginacion();
        }

        var select = document.getElementById(idSelect);
        if (select) {
            select.onchange = cambiarFilasPorPagina;
        }

        actualizarPaginacion();
    }

    const configTabla1 = {
        idTabla: 'table',
        clasePaginacion: '.pagination',
        claseMax: '.max',
        claseMin: '.min',
        idSelect: 'rowsPerPage',
        filasPorPaginaDesktop: 10,
        filasPorPaginaMobile: 4
    };

    const configTabla2 = {
        idTabla: 'empleos',
        clasePaginacion: '.pagination',
        claseMax: '.max',
        claseMin: '.min',
        idSelect: 'rowsPerPage',
        filasPorPaginaDesktop: 8,
        filasPorPaginaMobile: 4
    };

    const configTabla3 = {
        idTabla: 'empleados',
        clasePaginacion: '.pagination',
        claseMax: '.max',
        claseMin: '.min',
        idSelect: 'rowsPerPage',
        filasPorPaginaDesktop: 8,
        filasPorPaginaMobile: 4
    };

    verificarTamanoPantalla(configTabla1);
    if (configTabla2 || configTabla3) {
        verificarTamanoPantalla(configTabla2);
        verificarTamanoPantalla(configTabla3);
    }

    window.addEventListener('resize', function () {
        verificarTamanoPantalla(configTabla1);
        if (configTabla2 || configTabla3) {
            verificarTamanoPantalla(configTabla2);
            verificarTamanoPantalla(configTabla3);
        }
    });




    function cargarFilas() {
        var tabla = document.getElementById("miTabla").getElementsByTagName('tbody')[0];
        var filas = JSON.parse(localStorage.getItem("filas")) || [];

        filas.forEach(function (fila) {
            var nuevaFila = tabla.insertRow();
            fila.forEach(function (celdaTexto, indice) {
                var nuevaCelda = nuevaFila.insertCell(indice);
                if (indice === 0) {
                    var select = document.createElement('select');
                    ["Opción 1", "Opción 2", "Opción 3"].forEach(function (optionText) {
                        var option = document.createElement('option');
                        option.value = optionText.toLowerCase().replace(' ', '');
                        option.text = optionText;
                        if (optionText === celdaTexto) {
                            option.selected = true;
                        }
                        select.appendChild(option);
                    });
                    nuevaCelda.appendChild(select);
                } else {
                    nuevaCelda.textContent = celdaTexto;
                }
            });
        });
    }

    // Función para guardar filas en localStorage
    
});