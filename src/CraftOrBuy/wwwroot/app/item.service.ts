import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/toPromise";

@Injectable()
export class ItemService {
    constructor(private _http: Http) { }

    loadData(): Promise<Item[]> {
        return this._http.get("/api/items")
            .toPromise()
            .then(response => this.extractArray(response))
            .catch(this.handleErrorPromise);
    }

    protected extractArray(res: Response, showprogress: boolean = true) {
        let data = res.json();
        console.log(data);
        return data || [];
    }

    protected handleErrorPromise(error: any): Promise<void> {
        try {
            error = JSON.parse(error._body);
        } catch (e) {
            console.log(e);
        }

        let errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? `${error.status} - ${error.statusText}`
                        : "unknown server error";

        console.error(errMsg);
        return Promise.reject(errMsg);
    }
}
export interface Item {
    name: string;
    description: string;
}
