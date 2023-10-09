
var layoutGeneratorFunctions = function () {

    // =========================================================================
    // SETTINGS APP
    // =========================================================================

    return {

        // =========================================================================
        // CONSTRUCTOR APP
        // =========================================================================

        // =========================================================================
        // CREATE MENU
        // =========================================================================
        CrearMenu: function (menuDatos) {
            //se costruye el menu
            {
                var builddata = function () {
                    var sourceMenu = [];
                    var items = [];
                    // construye la jerarquia
                    for (var i = 0; i < menuDatos.length; i++) {
                        var item = menuDatos[i];
                        var label = item["DESC_MENU"];
                        var parentid = item["ID_MENU_PADRE"];
                        var id = item["ID_MENU"];
                        var url = item["METODO"];
                        var icon = item["ICO_MENU"];

                        if (items[parentid]) {
                            var item = { parentid: parentid, label: label, item: item, id: id, url: url, icon: icon };
                            if (!items[parentid].items) {
                                items[parentid].items = [];
                            }
                            items[parentid].items[items[parentid].items.length] = item;
                            items[id] = item;
                        }
                        else {
                            if (parentid != 0) {
                                items[id] = { parentid: parentid, label: label, item: item, id: id, url: url, icon: icon };
                                sourceMenu[id] = items[id];
                            } else {
                                items[0] = { parentid: parentid, label: label, item: item, id: 0, url: url, icon: icon };
                                sourceMenu[0] = items[0];
                            }

                        }
                    }
                    return sourceMenu;
                }
                var sourceMenu = builddata();

                //recursividad
                var buildUL = function (parent, items) {
                    $.each(items, function () {
                        var self = this;
                        if (typeof self.label != 'undefined') {

                            // crea el LI y lo agrega al elemento padre
                            if (this.parentid != 0 && !(this.items && this.items.length > 0)) { //El id 0 significa que es el titulo del menu
                                //var URLactual =  ;
                                var li = $("<li><a href='" + (this.url != "" ? this.url : "#")
                                    + "'>" + this.label + "</a></li>");
                                li.appendTo(parent);
                            }

                            if (this.parentid == 0) {
                                $("<li class='sidebar-category'><span>" + this.label.substring(0, 23) + "</span><span class='pull-right'><i class='fa fa-tasks'></i></span></li>").appendTo(sideBar);
                            }

                            // si hay sub-items, llama a la funcion buildUL.
                            if (this.items && this.items.length > 0) {
                                var ul = $("<ul></ul>");
                                var lin = $("<li class='submenu'><a href='javascript:void(0);'><span class='icon'><i class='fa fa-list'></i></span><span class='text'>"
                                    + this.label + "</span><span class='arrow'></span></a></li>").appendTo(sideBar);
                                ul.appendTo(lin);
                                buildUL(ul, this.items);
                            }
                        }
                    });
                }
                var ul = $("<ul class='sidebar-menu'></ul>");
                ul.insertBefore(".sidebar-footer");
                var sideBar = document.getElementById("sidebar-left").getElementsByClassName("sidebar-menu")[0];
                buildUL(ul, sourceMenu);
            }
        },

        // =========================================================================
        // CREATE BREADCRUM
        // =========================================================================
        bredcrumbLocation: function () {
            //var url = location.pathname.substring(location.pathname.lastIndexOf("/") + 1);

            //var menu = $(".sidebar-menu")[0];

            //var currentItem = $(menu).find("[href$='" + url + "']");

            ($("<li><i class='fa fa-home'></i><a href='"
                + window.location.origin
                + "'>Inicio</a><i class='fa fa-angle-right'></i></li>")).appendTo($(".breadcrumb"));

            if (window.location.pathname != "/") {

                var itemList = location.pathname.split('/').slice(1);
                var len = itemList.length;

                itemList.forEach(function (element, index) {
                    if (index == len - 1) {
                        $("<li class='active'></li>").append(element).appendTo($(".breadcrumb"));
                    }
                    else {
                        $("<li><a href='#'> "
                            + element
                            + "</a><i class='fa fa-angle-right'></i></li>").appendTo($(".breadcrumb"));
                    }
                });

                //-----VER 1 ------------------------------------------------------------------------------------------------
                //var len = $(currentItem.parents("li").get().reverse()).length;

                //$(currentItem.parents("li").get().reverse()).each(function (index, element) {
                //    if (index == len - 1) {
                //        $("<li class='active'></li>").append($(this).children("a")[0].innerText).appendTo($(".breadcrumb"));
                //    }
                //    else {
                //        $("<li><a href='#'> "
                //            + $(this).children("a")[0].innerText
                //            + "</a><i class='fa fa-angle-right'></i></li>").appendTo($(".breadcrumb"));
                //    }
                //});

            }
        },

        // =========================================================================
        // CREATE HEADER
        // =========================================================================
        headersGenerator: function () {
            if (document.querySelectorAll(".panel-body")[0].querySelector("h2").innerHTML != "") {
                var windowsHeader = document.querySelectorAll(".panel-body")[0].querySelector("h2").innerHTML;
                document.querySelectorAll(".panel-heading")[0].querySelector("h3").innerHTML = windowsHeader;
                document.querySelectorAll(".panel-body")[0].querySelector("h2").remove();
            } else {
                document.querySelectorAll(".panel-heading")[0].querySelector("h3").innerHTML = "";
            }
            
            //document.querySelector(".header-content").querySelector("h2").querySelector("span").innerText = location.pathname.split('/')[1];
        },

        //=========================================================================
        //ALERTS
        //=========================================================================
        conteoNotificaciones: function () {

            if ($("#notifSession").val()) {
                if (window.sessionStorage) {

                    var nombre = JSON.parse(sessionStorage.getItem("Listamsgs"));

                    var session = sessionStorage.getItem("idSessionSis");

                    if (session != null) {
                        var valSession = $("#notifSession").val();
                        if (valSession == session) {

                            if (nombre != null) {


                                function logArrayElements(element, index, array) {
                                    $(".media-list.small").append("<a href='#' class='media'><div class='media-object pull-left'><i class='fa fa-exclamation-circle fg-success'></i></div><div class='media-body'><span class='media-text'>"
                                        + element.msg + "</span><!-- Start meta icon --><span class='media-meta'>" + element.time + "</span><!--/ End meta icon --></div><!-- /.media-body --></a>");
                                    //console.log("a[" + index + "] = " + element.msg);
                                }

                                nombre.forEach(logArrayElements);
                                var count = nombre.length;
                                //console.log(count);
                                var p = document.getElementById('notificationCount');
                                var q = document.getElementById('notificationCountDrop');

                                p.textContent = count;
                                q.textContent = "(" + count + ")";
                            }
                        } else {
                            sessionStorage.removeItem("Listamsgs");
                            sessionStorage.setItem("idSessionSis", valSession);
                        }
                    }


                } else {
                    throw new Error('Tu Browser no soporta SessionStorage!');
                }


            }

        }

    };

}();