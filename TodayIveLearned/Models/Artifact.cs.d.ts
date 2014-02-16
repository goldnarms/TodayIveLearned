declare module server {
	interface Artifact {
		Id: number;
		Title: string;
		Description: string;
		Topic: server.Topic;
	}
}
