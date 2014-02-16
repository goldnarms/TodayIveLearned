/// <reference path="_all.ts" />
module TIL {
    "use strict";

    angular.module("TIL.controllers", [])
        .controller("addArtifactCtrl", TIL.AddArtifactController.prototype.injection());

    var app = angular.module("tilApp", ["TIL.controllers", "ngRoute"]);

    app.config([
        "$routeProvider", ($routeProvider: ng.route.IRouteProvider)=> {

            $routeProvider.when("/", {
                templateUrl: "Home/Index",
                controller: "addArtifactCtrl as ac"
            });
        }
    ]);
}