am4core.ready(function () {

    // Themes begin
    am4core.useTheme(am4themes_animated);
    // Themes end

    // Create map instance
    var chart = am4core.create("chartdiv", am4maps.MapChart);

    // Set map definition
    chart.geodata = am4geodata_worldLow;

    // Set projection
    chart.projection = new am4maps.projections.Miller();

    // Create map polygon series
    var polygonSeries = chart.series.push(new am4maps.MapPolygonSeries());

    // Exclude Antartica
    polygonSeries.exclude = ["AQ"];

    // Make map load polygon (like country names) data from GeoJSON
    polygonSeries.useGeodata = true;

    // Configure series
    var polygonTemplate = polygonSeries.mapPolygons.template;
    polygonTemplate.tooltipText = "{name}";
    polygonTemplate.polygon.fillOpacity = 0.6;


    // Create hover state and set alternative fill color
    var hs = polygonTemplate.states.create("hover");
    hs.properties.fill = chart.colors.getIndex(0);

    // Add image series
    var imageSeries = chart.series.push(new am4maps.MapImageSeries());
    imageSeries.mapImages.template.propertyFields.longitude = "longitude";
    imageSeries.mapImages.template.propertyFields.latitude = "latitude";
    imageSeries.mapImages.template.tooltipText = "{title}";
    imageSeries.mapImages.template.propertyFields.url = "url";

    var circle = imageSeries.mapImages.template.createChild(am4core.Circle);
    circle.radius = 3;
    circle.propertyFields.fill = "color";

    var circle2 = imageSeries.mapImages.template.createChild(am4core.Circle);
    circle2.radius = 3;
    circle2.propertyFields.fill = "color";


    circle2.events.on("inited", function (event) {
        animateBullet(event.target);
    })


    function animateBullet(circle) {
        var animation = circle.animate([{ property: "scale", from: 1, to: 5 }, { property: "opacity", from: 1, to: 0 }], 1000, am4core.ease.circleOut);
        animation.events.on("animationended", function (event) {
            animateBullet(event.target.object);
        })
    }

    let colorSet = new am4core.ColorSet();

    fetch("https://localhost:44313/api/v1/c19api")
        .then(response => response.json())
        .then(countries => {

            const MAX = 20;

            let chartData = [];

            let tableData = "<table>";
            tableData += "<thead>";
            tableData += "<tr>";
            tableData += "<th>Country</th>";
            tableData += "<th>Infected</th>";
            tableData += "</tr>";
            tableData += "</thead>";

            countries.sort((a, b) => parseFloat(b.infected) - parseFloat(a.infected));

            countries.forEach(function (item, index) {

                if (index >= MAX)
                    return;

                let color = "darkred";
                if (index < 5)
                    color = "darkred";
                if (index >= 5 && index < 10)
                    color = "red";
                if (index >= 10 && index < 15)
                    color = "darkorange";
                if (index >= 15)
                    color = "orange";

                let i = index / countries.length;

                let datum = {
                    title: item.country,
                    latitude: item.location.latitude,
                    longitude: item.location.longitude,
                    color: am4core.color(color)
                }

                tableData += "<tbody>";
                tableData += "<tr>";
                tableData += "<td>" + item.country + "</td>";
                tableData += "<td>" + item.infected + "</td>";
                tableData += "<tr>";
                tableData += "</tbody>";

                chartData.push(datum);
            });

            tableData += "</table>";

            document.getElementById("tablediv").innerHTML = tableData;

            imageSeries.data = chartData;
        })
        .catch(function (error) {
            console.log("error", error);
        });

}); // end am4core.ready()