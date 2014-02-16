module TIL {
    "use strict";

    export interface IAddArtifactController {
        addArtifact(artifact: server.Artifact): void;
        setSource(source: server.Source): void;
        artifact: server.Artifact;
        sources: server.Source[];
        source: server.Source;
        topics: server.Topic[];
    }

    export class AddArtifactController implements IAddArtifactController {

        public injection(): any[] {
            return ["$scope", "$parse", "$http", "$log", AddArtifactController];
        }

        static $inject = ["$scope", "$parse", "$http", "$log"];

        public artifact: server.Artifact;
        public sources: server.Source[];
        public source: server.Source;
        public topics: server.Topic[];
        private ac: IAddArtifactController;
        constructor(private $scope: ng.IScope, private $parse: ng.IParseService, private $http: ng.IHttpService, private $log: ng.ILogService) {
            this.ac = this;
            this.init();
            this.setupWatches();
        }

        public addArtifact(artifact: server.Artifact): void {
            this.$http.post("Api/Artifact", artifact)
                .success(() => this.handleSuccess())
                .catch((error)=> this.handleError(error));
        }

        public setSource(source: server.Source): void {
            this.source = source;
        }

        private handleSuccess(): void {
            this.$log.info("Artifact saved");
        }

        private init() {
            this.$http.get("api/Source")
            .success((data: server.Source[]) => {
                this.sources = data;
            })
            .catch((error) => {
                this.handleError(error);
            });
        }

        private handleError(error: string) {
            this.$log.error(error);
        }

        private setupWatches(): void {
            this.$scope.$watch(() => this.ac.artifact, (value) => {
                if (value && value.length > 2) {
                    this.$http.get("api/Topic/Triggers",  value)
                        .success((data: server.Topic[])=> {
                            this.topics = data;
                        })
                        .catch((error)=> { this.handleError(error); });
                }
            });
        }

    }

}