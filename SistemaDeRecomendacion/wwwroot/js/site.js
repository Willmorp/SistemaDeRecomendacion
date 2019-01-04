/*CODIGO PRINCIPAL*/
var principal = new Principal()



$().ready(() => {
    let URLactual = window.location.pathname;
    principal.userLink(URLactual);
    $('.sidenav').sidenav();
});