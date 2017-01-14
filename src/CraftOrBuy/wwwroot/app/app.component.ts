import { Component, OnInit } from "@angular/core";
import { ItemService, Item } from "./item.service";

@Component({
    selector: "my-app",
    template: `
    <h1>My First Angulaaaar 2 App</h1>
    <ul>
    <li *ngFor="let item of items">
    <strong>name: {{ item.name }}</strong><br>
    id: {{ item.id }}<br>
    desc: {{ item.description }}
    </li>
    </ul>
    `,
    providers: [
        ItemService
    ]
})
export class AppComponent extends OnInit {

    constructor(private _service: ItemService) {
        super();
    }

    ngOnInit() {
        this._service.loadData().then(data => {
            this.items = data;
        });
    }

    items: Item[] = [];
}