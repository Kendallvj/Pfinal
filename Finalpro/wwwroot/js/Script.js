// scripts.js

function validarInicioSesion() {
    var usuario = document.getElementById('usuario').value;
    var password = document.getElementById('password').value;

    if (usuario === '' || password === '') {
        alert('Por favor ingresa usuario y contraseña.');
        return false;
    }

    // Más validaciones si las necesitas...

    return true;
}
