const formulario = document.getElementById('formulario');
const inputs = document.querySelectorAll('#formulario input');
const boton = document.getElementById('btn');

const expresiones = {
	FristName: /^[a-zA-ZÀ-ÿ_-\s]{4,40}$/, // Letras, numeros, guion, guion_bajo y pueden llevar acentos.
	LastName: /^[a-zA-ZÀ-ÿ_-\s]{4,40}$/, // Letras, numeros, guion, guion_bajo y pueden llevar acentos.
	Username: /^[a-zA-Z0-9]{1,40}$/, // Letras y espacios, no pueden llevar acentos.
	Password: /^.{4,16}$/, // 4 a 16 digitos.
	Email: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
	Phone: /^\d{10}$/ // 10 numeros.
}

const campos = {
	FristName: false,
	LastName: false,
	Username: false,
	password: false,
	Email: false,
	Phone: false
}

const validarFormulario = (e) => {
	switch (e.target.name) {
		case "FristName":
			validarCampo(expresiones.FristName, e.target, 'FristName');
			break;
		case "LastName":
			validarCampo(expresiones.LastName, e.target, 'LastName');
			break;
		case "Username":
			validarCampo(expresiones.Username, e.target, 'Username');
			break;
		case "Password":
			validarCampo(expresiones.Password, e.target, 'Password');
			break;
		case "Email":
			validarCampo(expresiones.Email, e.target, 'Email');
			break;
		case "Phone":
			validarCampo(expresiones.Phone, e.target, 'Phone');
			break;
	}
}

const validarCampo = (expresion, input, campo) => {
	if (expresion.test(input.value)) {
		document.getElementById(`grupo__${campo}`).classList.remove('formulario__grupo-incorrecto');
		document.getElementById(`grupo__${campo}`).classList.add('formulario__grupo-correcto');
		document.querySelector(`#grupo__${campo} i`).classList.add('fa-check-circle');
		document.querySelector(`#grupo__${campo} i`).classList.remove('fa-times-circle');
		document.querySelector(`#grupo__${campo} .formulario__input-error`).classList.remove('formulario__input-error-activo');
		campos[campo] = true;
	} else {
		document.getElementById(`grupo__${campo}`).classList.add('formulario__grupo-incorrecto');
		document.getElementById(`grupo__${campo}`).classList.remove('formulario__grupo-correcto');
		document.querySelector(`#grupo__${campo} i`).classList.add('fa-times-circle');
		document.querySelector(`#grupo__${campo} i`).classList.remove('fa-check-circle');
		document.querySelector(`#grupo__${campo} .formulario__input-error`).classList.add('formulario__input-error-activo');
		campos[campo] = false;
	}
}

inputs.forEach((input) => {
	input.addEventListener('keyup', validarFormulario);
	input.addEventListener('blur', validarFormulario);
});

btn.addEventListener('click', (e) => {

	const terminos = document.getElementById('terminos');
	if (campos.FristName && campos.LastName && campos.Username && campos.Password && campos.Email && campos.Phone && terminos.checked) {

		document.getElementById('formulario__mensaje-exito').classList.add('formulario__mensaje-exito-activo');
		setTimeout(() => {
			document.getElementById('formulario__mensaje-exito').classList.remove('formulario__mensaje-exito-activo');
		}, 5000);

		document.querySelectorAll('.formulario__grupo-correcto').forEach((icono) => {
			icono.classList.remove('formulario__grupo-correcto');
		});
	} else {

		e.preventDefault()
		formulario.reset();
		document.getElementById('formulario__mensaje').classList.add('formulario__mensaje-activo');
	}
});