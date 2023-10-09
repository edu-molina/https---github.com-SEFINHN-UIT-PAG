var efectoDivGrupoBotones = {
        btnMostrarOcultar: function (classDivGrupo) {
        //MODO DE USO: Debe declararse un div que contenga dos botones con clases de botones: btn-primary o btn-danger o btn-success o las demas de btn
        //<div class="btn-group btn-toggle">  ===>Este es el classDivGrupo
        //   <button class="btn btn-default" data-toggle="collapse" data-target="#collapsible">Alpha</button>
        //      <button class="btn btn-primary active" data-toggle="collapse" data-target="#collapsible">Beta</button>
        //</div>
            $('.' +classDivGrupo ).click(function () {
                $(this).find('.btn').toggleClass('active');

                if ($(this).find('.btn-primary').size() > 0) {
                    $(this).find('.btn').toggleClass('btn-primary');
                }
                if ($(this).find('.btn-danger').size() > 0) {
                    $(this).find('.btn').toggleClass('btn-danger');
                }
                if ($(this).find('.btn-success').size() > 0) {
                    $(this).find('.btn').toggleClass('btn-success');
                }
                if ($(this).find('.btn-info').size() > 0) {
                    $(this).find('.btn').toggleClass('btn-info');
                }

                $(this).find('.btn').toggleClass('btn-default');

            });
        },
        divGetPartial: function (sUrl, DivDestino) {
            
            var elDiv = DivDestino;
            var laUrl = sUrl;
            $.ajax({
                type: "GET", url: laUrl,
                data: { parameter: "101" },
                success: function (response) {
                    // partial view returned //now show the partial view content in some container like a DIV
                    elDiv.html(response);
                },
            })
            
        }
}