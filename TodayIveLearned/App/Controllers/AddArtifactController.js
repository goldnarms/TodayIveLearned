var TIL;
(function (TIL) {
    "use strict";

    var AddArtifactController = (function () {
        function AddArtifactController($scope, $parse, $http, $log) {
            this.$scope = $scope;
            this.$parse = $parse;
            this.$http = $http;
            this.$log = $log;
            this.ac = this;
            this.init();
            this.setupWatches();
        }
        AddArtifactController.prototype.injection = function () {
            return ["$scope", "$parse", "$http", "$log", AddArtifactController];
        };

        AddArtifactController.prototype.addArtifact = function (artifact) {
            var _this = this;
            this.$http.post("Api/Artifact", artifact).success(function () {
                return _this.handleSuccess();
            }).catch(function (error) {
                return _this.handleError(error);
            });
        };

        AddArtifactController.prototype.setSource = function (source) {
            this.source = source;
        };

        AddArtifactController.prototype.handleSuccess = function () {
            this.$log.info("Artifact saved");
        };

        AddArtifactController.prototype.init = function () {
            var _this = this;
            this.$http.get("api/Source").success(function (data) {
                _this.sources = data;
            }).catch(function (error) {
                _this.handleError(error);
            });
        };

        AddArtifactController.prototype.handleError = function (error) {
            this.$log.error(error);
        };

        AddArtifactController.prototype.setupWatches = function () {
            var _this = this;
            this.$scope.$watch(function () {
                return _this.ac.artifact;
            }, function (value) {
                if (value && value.length > 2) {
                    _this.$http.get("api/Topic/Triggers", value).success(function (data) {
                        _this.topics = data;
                    }).catch(function (error) {
                        _this.handleError(error);
                    });
                }
            });
        };
        AddArtifactController.$inject = ["$scope", "$parse", "$http", "$log"];
        return AddArtifactController;
    })();
    TIL.AddArtifactController = AddArtifactController;
})(TIL || (TIL = {}));
//# sourceMappingURL=AddArtifactController.js.map
