declare module server {
	interface Topic {
		Id: number;
		Name: string;
		Description: string;
		Category: server.Category;
		Triggers: server.Trigger[];
	}
}
