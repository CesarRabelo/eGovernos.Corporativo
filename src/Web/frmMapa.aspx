<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMapa.aspx.cs" Inherits="Titanium.Web.frmMapa" %>

<!DOCTYPE html>
<html>
    <head>
        <meta name="viewport" content="initial-scale=1.0, user-scalable=no"/>
        <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
        <title>Google Maps JavaScript API v3 Example: Reverse Geocoding</title>
        <link href="http://code.google.com/apis/maps/documentation/javascript/examples/default.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
        <script type="text/javascript">

            var geocoder;
            var map;
            var infowindow = new google.maps.InfoWindow();
            var marker;

            function QueryString(variavel) {
                var variaveis = location.search.replace(/\x3F/, "").replace(/\x2B/g, " ").split("&");
                var nvar;
                if (variaveis != "") {
                    var qs = [];
                    for (var i = 0; i < variaveis.length; i++) {
                        nvar = variaveis[i].split("=");
                        qs[nvar[0]] = unescape(nvar[1]);
                    }
                    return qs[variavel];
                }
                return null;
            }

            var logradouro = QueryString("logradouro");
            var coordenadas = QueryString("coordenadas");

            function initialize() {
                geocoder = new google.maps.Geocoder();

                if (logradouro) {
                    codeAddress(logradouro);
                }

                else if (coordenadas) {
                    codeLatLng(coordenadas);

                } else {
                    var latlng = new google.maps.LatLng(-3.730653, -38.526993);
                    var myOptions = {
                        zoom: 4,
                        disableDefaultUI: true,
                        center: latlng,
                        mapTypeId: 'roadmap'
                    }

                    map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

                }
            }

            function codeAddress(address) {
                var myOptions = {
                    disableDefaultUI: true,
                    mapTypeId: 'roadmap'
                }
                var end;

                map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
                geocoder.geocode({ 'address': address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        map.setCenter(results[0].geometry.location);
                        map.setZoom(17);
                        var marker = new google.maps.Marker({
                            map: map,
                            position: results[0].geometry.location
                        });
                        marker.setDraggable(true);                 
                        document.getElementById("address").innerHTML = results[0].formatted_address;
                        infowindow.open(map, marker);
                    } else {
                        alert("Geocode was not successful for the following reason: " + status);
                    }
                });
            }

            function codeLatLng(coord) {

                var myOptions = {
                    disableDefaultUI: true,
                    mapTypeId: 'roadmap'
                }
                map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

                var input = coord;
                var latlngStr = input.split(",", 2);
                var lat = parseFloat(latlngStr[0]);
                var lng = parseFloat(latlngStr[1]);
                var latlng = new google.maps.LatLng(lat, lng);
                geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[1]) {
                            map.setCenter(latlng);
                            map.setZoom(17);
                            marker = new google.maps.Marker({                                 
                                position: latlng,
                                map: map
                            });
                            marker.setDraggable(true);
                            document.getElementById("address").innerHTML = results[1].formatted_address;
                            infowindow.open(map, marker);
                        } else {
                            alert("No results found");
                        }
                    } else {
                        alert("Geocoder failed due to: " + status);
                    }
                });
            }
        </script>
    </head>
    <body onload="initialize()">
        
        <div>
            <p id="address"/>
        </div>
        <div id="map_canvas" style="height: 85%; top:58px; border: 1px solid black;"></div>
        
    </body>
</html>
