export class Status {    
    id: number = 0;
    name: string = "";

    constructor(public prId: number, public prName: string) {
        this.id = prId;
        this.name = prName;
    }
}