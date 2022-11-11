const formulario = document.getElementById('formulario');
const inputs = document.querySelectorAll('#formulario input');
const boton = document.getElementById('btn');

const expresiones = {
	Username: /^[a-zA-Z0-9]{1,40}$/, // Letras y espacios, no pueden llevar acentos.
	Password: /^.{4,16}$/ // 4 a 16 digitos.
}

const campos = {
	Username: false,
	Password: false
}

const validarFormulario = (e) => {
	switch (e.target.name) {
		case "Username":
			validarCampo(expresiones.Username, e.target, 'Username');
			break;
		case "Password":
			validarCampo(expresiones.Password, e.target, 'Password');
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

	if (campos.Username && campos.Password) {

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


