document.addEventListener("DOMContentLoaded", function () {
    const getElement = id => document.getElementById(id);
    const getElements = className => document.getElementsByClassName(className);

    const newElement = getElement("newEmployee");
    const closeEmployee = getElement("closeEmployee");

    const plus = getElement("plus");

    if (newElement) {
        const oEmployee = () => {
            getElement("shadow").style.display = 'block';
            getElement("formEmployee").classList.add('active');
        };
        newElement.onclick = oEmployee;

        const cEmployee = () => {
            getElement("shadow").style.display = 'none';
            getElement("formEmployee").classList.remove('active');
        };
        closeEmployee.onclick = cEmployee;
    }
});
