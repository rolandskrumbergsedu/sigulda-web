$(document).ready(function () {

    $.get("api/avengers/amurs", function (amuri, status) {

        // Izveidot katram objektam jaunu tabulas ierakstu

        amuri.forEach(function (amurs) {

            var id = "<td>" + amurs.Amura_ID + "</td>";
            var kataGarums = "<td>" + amurs.kata_garums + "</td>";
            var galvasIzmers = "<td>" + amurs.galvas_izmers + "</td>";
            var ipasasIezimes = "<td>" + amurs.ipasas_iezimes + "</td>";
            var bojats = "<td>" + amurs.Bojats + "</td>";
            var panema = "<td>" + amurs.Panema + "</td>";
            var amuruRinda = "<tr>" + id + kataGarums + galvasIzmers + ipasasIezimes + bojats + panema + "</tr>";

            $("#amuru_tabula").append(amuruRinda);
            
            $("#amuru_saraksts").append(getOption(amurs.Amura_ID, amurs.Panema));

        });

    });

    var getOption = function (value, text) {
        return "<option value=" + "\"" + value + "\"" + ">" + text + "</option>";
    };

    $("#amura_poga").click(function () {

        // Atrod ievades lauka ar ID "kata_garums" vertibu
        var amuraIdKaVirkne = $("#amura_id").val();
        var kataGarumsKaVirkne = $("#kata_garums").val();
        var galvasIzmersKaVirkne = $("#galvas_izmers").val();
        var ipasasIezimesKaVirkne = $("#ipasas_iezimes").val();
        var bojatsKaVirkne = $("#bojats").val();
        var panemaKaVirkne = $("#panema").val();

        // Konvertē no virknes uz ciparu
        var amuraIdKaCipars = Number(amuraIdKaVirkne);
        var kataGarumsKaCipars = Number(kataGarumsKaVirkne);
        var galvasIzmersKaCipars = Number(galvasIzmersKaVirkne);

        var bojatsKaRezultats = false;
        if (bojatsKaVirkne === "Ja") {
            bojatsKaRezultats = true;
        }

        // Objekts, ko nosūta servisam
        var amurs = {
            "Amura_ID": amuraIdKaCipars,
            "kata_garums": kataGarumsKaCipars,
            "galvas_izmers": galvasIzmersKaCipars,
            "ipasas_iezimes": ipasasIezimesKaVirkne,
            "Bojats": bojatsKaRezultats,
            "Panema": panemaKaVirkne
        };

        $.post("api/avengers/amurs",
            amurs,
            function (data, status) {
                // Izdzēš ievadīto vērtību laukam ar ID "kata_garums"
                //$("#kata_garums").val(null);
                //alert("Data: " + JSON.stringify(data) + "\nStatus: " + status);

                // Refresh
                window.location.href = window.location.href;
            });
    }); 
});


