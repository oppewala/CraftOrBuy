"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require("rxjs/add/operator/toPromise");
var ItemService = (function () {
    function ItemService(_http) {
        this._http = _http;
    }
    ItemService.prototype.loadData = function () {
        var _this = this;
        return this._http.get("/api/items")
            .toPromise()
            .then(function (response) { return _this.extractArray(response); })
            .catch(this.handleErrorPromise);
    };
    ItemService.prototype.extractArray = function (res, showprogress) {
        if (showprogress === void 0) { showprogress = true; }
        var data = res.json();
        return data || [];
    };
    ItemService.prototype.handleErrorPromise = function (error) {
        try {
            error = JSON.parse(error._body);
        }
        catch (e) {
            console.log(e);
        }
        var errMsg = error.errorMessage
            ? error.errorMessage
            : error.message
                ? error.message
                : error._body
                    ? error._body
                    : error.status
                        ? error.status + " - " + error.statusText
                        : "unknown server error";
        console.error(errMsg);
        return Promise.reject(errMsg);
    };
    ItemService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], ItemService);
    return ItemService;
}());
exports.ItemService = ItemService;
//# sourceMappingURL=item.service.js.map