function obtenerDatos() {

    let url = `http://api.mediastack.com/v1/news?access_key=a44de6eab9b2496618061722e2fbf4f9&languages=en&country=co&keywords=missing%20person`;

    const api = new XMLHttpRequest();
    api.open('GET', url, true);
    api.send();

    api.onreadystatechange = function () {
        if (this.status == 200 && this.readyState == 4) {

            let datos = JSON.parse(this.responseText);
            console.log(datos);
            let noticias = datos.data;
            let listadoNoticiasHTML = ``;
            noticias?.map(noticia => {
                const { image, url, title, description, source } = noticia;
                let imagenhd = (image) ? `<div class="card-image">
                                            <img src="${image}" alt=${title}>
                                            <span class="card-title">${source}</span>
                                            </div>`: "";

                listadoNoticiasHTML += `

        <div class="col s12 m6 14">
            <div class="card">
                ${imagenhd}
                <div class="card-content">
                    <h3>${title}</h3>
                    <p>${description}</p>
                    <br>
                    <div class="contenedor-botones">
                    <a href="${url}">
                    <button class="boton cuatro"><span>${'View News'}</span></button></a>
                    </div>
                </div>
            </div>
        </div> `;
            });
            let divListadoNoticias = document.querySelector("#divListadoNoticias");
            divListadoNoticias.innerHTML = `<div style="text-align:center">
                                                        <img src="https://acegif.com/wp-content/uploads/loading-23.gif" width=500 height=300>
                                                        </div>`;
            setTimeout(() => {
                divListadoNoticias.innerHTML = listadoNoticiasHTML;

            }, 3000);
        }

    }
}