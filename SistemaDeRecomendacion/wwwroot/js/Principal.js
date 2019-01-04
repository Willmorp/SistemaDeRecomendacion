
class Principal {
    constructor() {

    }
    userLink(URLactual) {
        switch (URLactual) {
            case "/Principal" || "/principal/":
                document.getElementById("enlace1").classList.add('active');
                break;
            case "/Usuarios" || "/Usuarios/" :
                document.getElementById("enlace2").classList.add('active');
                break;
            case "/Usuarios/Registrar/Registrar" || "/Usuarios/Registrar/Registrar/" :
                document.getElementById("enlace2").classList.add('active');
                break;
        }
    }
}