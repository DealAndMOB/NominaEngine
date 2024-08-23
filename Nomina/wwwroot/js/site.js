const getElement = id => document.getElementById(id);

function toggleClasses(elements, addClasses, removeClasses) {
    if (elements && elements.length > 0) {
        elements.forEach(element => {
            if (element) {  // Verifica que el elemento exista
                addClasses.forEach(cls => element.classList.add(cls));
                removeClasses.forEach(cls => element.classList.remove(cls));
            }
        });
    }
}

function handleResize() {
    const cardStart = getElement("card-start");
    const cardEnd = getElement("card-end");
    const accessItems = document.querySelectorAll(".access-item");

    if (window.matchMedia("(max-width: 767px)").matches) {
        toggleClasses([cardStart], [], ["me-3"]);
        toggleClasses([cardEnd], [], ["ms-3"]);
        toggleClasses(accessItems, [], ["w-95"]);
    } else {
        toggleClasses(accessItems, ["w-95"], []);
        toggleClasses([cardStart], ["me-3"], []);
        toggleClasses([cardEnd], ["ms-3"], []);
    }
}

window.addEventListener('resize', handleResize);
handleResize();

document.getElementById('submit')?.addEventListener('click', function () {
    const weekInput = document.getElementById('week')?.value;
    const selectedWeek = document.getElementById('selected-week');

    if (weekInput && selectedWeek) {
        const [year, week] = weekInput.split('-W');
        if (year && week) {
            const date = getDateOfISOWeek(week, year);
            const formattedWeek = formatWeek(date);
            selectedWeek.textContent = `Semana seleccionada: ${formattedWeek}`;
        } else {
            selectedWeek.textContent = 'Formato de semana inválido.';
        }
    } else if (selectedWeek) {
        selectedWeek.textContent = 'Por favor, seleccione una semana.';
    }
});

function getDateOfISOWeek(w, y) {
    const simple = new Date(y, 0, 1 + (w - 1) * 7);
    const dow = simple.getDay();
    const ISOweekStart = simple;
    if (dow <= 4) {
        ISOweekStart.setDate(simple.getDate() - simple.getDay() + 1);
    } else {
        ISOweekStart.setDate(simple.getDate() + 8 - simple.getDay());
    }
    return ISOweekStart;
}

function formatWeek(date) {
    const options = { year: 'numeric', month: 'long', day: 'numeric' };
    const startDate = new Intl.DateTimeFormat('es-ES', options).format(date);
    const endDate = new Intl.DateTimeFormat('es-ES', options).format(
        new Date(date.setDate(date.getDate() + 6))
    );
    return `del ${startDate} al ${endDate}`;
}
