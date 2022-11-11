function obtenerDatos() {

    let url = `http://api.mediastack.com/v1/news?access_key=1412641af1071a5acb9369aadbbbba3c&languages=es&countries=co&keywords=desaparecido`;

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
                let imagen = (image) ? `
                 <div class="card-image">
                 <img src="${image}" alt=${title}>
                 <span class="card-title">${source}</span>
                 
                 </div>`: null;

                listadoNoticiasHTML +=
                    `<div class="contenedor">
                        <div class="contenedor-noticia">
                        <div class="card">
                            <img src="${image}">
                                <div class="textos">
                                <h2>${title}</h2>
                                <p>${description}</p>
                                <a href="${url}" class="btn">Ver Noticia Completa</a>
                                
                                </div>
                            </div>
                        </div>
                        </div>
                        `;
            });
            let divListadoNoticias = document.querySelector("#divListadoNoticias");
            divListadoNoticias.innerHTML = `<div style="text-align:center">
                                                        <img src="https://acegif.com/wp-content/uploads/loading-79.gif" width=300 height=300>
                                                        </div>`;
            setTimeout(() => {
                divListadoNoticias.innerHTML = listadoNoticiasHTML;

            }, 3000);
        }

    }
}