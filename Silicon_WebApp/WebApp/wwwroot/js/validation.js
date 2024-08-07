
const formErrorHandler = (e, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${e.name}"]`);
    if (!validationResult) {
        e.classList.add('input-validation-error');
        spanElement.classList.add('field-validation-error');
        spanElement.classList.remove('field-validation-valid');
        spanElement.innerHTML = e.dataset.valRequired;
    }
    else {
        spanElement.innerHTML = '';
        e.classList.remove('input-validation-error');
        spanElement.classList.remove('field-validation-error');
        spanElement.classList.add('field-validation-valid');
    }
}

const lengthValidator = (value, minLength = 2) => {
    if (value.length >= minLength) {
        return true;
    }
    return false;
}

const compareValidator = (element, compareValue) => {
    if (element.value === compareValue) {
        return true;
    }
    return false;
}

const checkedValidator = (element) => {
    if (element.checked) {
        return true;
    }
    return false;
}

const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorHandler(element, true);
    }
    else {
        formErrorHandler(element, false);
    }
}

const checkboxValidator = (e) => {
    formErrorHandler(e, checkedValidator(e));
}

const emailValidator = (element) => {
    const regEx = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    formErrorHandler(element, regEx.test(element.value));
}

const passwordValidator = (element) => {
    if (element.dataset.valEqualToOther !== undefined) {
        formErrorHandler(element, regEx.test(element.val, document.getElementsByName(element.dataset.valEqualToOther.replace('*', 'form')[0].value)));
    } else {
        const regEx = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/;
        formErrorHandler(element, regEx.test(element.value));
    }
}

let forms = document.querySelectorAll('form');
let inputs = forms[0].querySelectorAll('input');

inputs.forEach(input => {
    if (input.dataset.val === 'true') {

        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkboxValidator(e.target);
            })
        } else {

            input.addEventListener('keyup', (e) => {
                switch (e.target.type) {
                    case 'text':
                        textValidator(e.target);
                        break;
                    case 'email':
                        emailValidator(e.target);
                        break;
                    case 'password':
                        passwordValidator(e.target);
                }
            })
        }
    }
});