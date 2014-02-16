/// <reference path="_all.ts" />
var TIL;
(function (TIL) {
    "use strict";

    angular.module("TIL.controllers", []).controller("addArtifactCtrl", TIL.AddArtifactController.prototype.injection());

    var app = angular.module("tilApp", ["TIL.controllers", "ngRoute"]);

    app.config([
        "$routeProvider",
        function ($routeProvider) {
            $routeProvider.when("/", {
                templateUrl: "Home/Index",
                controller: "addArtifactCtrl as ac"
            });
        }
    ]);
})(TIL || (TIL = {}));
//# sourceMappingURL=app.js.map
