import { Component, OnInit } from "@angular/core";
import { ItemService, Item } from "./item.service";

@Component({
    selector: "my-app",
    template: `
    <h1>My First Angular 2 App</h1>
    <ul>
    <li *ngFor="let item of items">
    <strong></strong><br>
    name: {{ item.name }}<br>
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