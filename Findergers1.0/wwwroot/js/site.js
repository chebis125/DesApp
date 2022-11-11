mapboxgl.accessToken = 'pk.eyJ1Ijoic2N1ZXJ2b3EiLCJhIjoiY2wzZDV3NjBiMDVkYjNjbnltOW9mdDB5bCJ9.YUcI8Zt7WH2upC8I9PpBtA';
const mapa = new mapboxgl.Map({
	container: 'mapa',
	style: 'mapbox://styles/mapbox/streets-v11',
	center: [-74.35841594878353, 4.818581857638713],
	zoom: 14
});

var customData = {
	'features': [

	],
	'type': 'FeatureCollection'
};

function forwardGeocoder(query) {
	var matchingFeatures = [];
	for (var i = 0; i < customData.features.length; i++) {
		var feature = customData.features[i];

		if (
			feature.properties.title
				.toLowerCase()
				.search(query.toLowerCase()) !== -1
		) {

			feature['place_name'] = '🩺' + feature.properties.title;
			feature['center'] = feature.geometry.coordinates;
			feature['place_type'] = ['eps'];
			matchingFeatures.push(feature);
		}
	}
	return matchingFeatures;
}

// Add the control to the map.
mapa.addControl(
	new MapboxGeocoder({
		accessToken: mapboxgl.accessToken,
		localGeocoder: forwardGeocoder,
		zoom: 14,
		placeholder: 'Ubicacion',
		mapboxgl: mapboxgl
	})
);

