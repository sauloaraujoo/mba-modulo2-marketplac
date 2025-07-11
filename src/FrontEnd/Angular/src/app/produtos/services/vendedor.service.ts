import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http"
import { Vendedor } from "../models/vendedor"

import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { BaseService } from 'src/app/services/base.service';

@Injectable()
export class VendedorService extends BaseService {

    constructor(private http: HttpClient) { super(); }

    obter(vendedorId: string) : Observable<Vendedor>{

        let url = this.UrlServiceV1 + `api/vendedor/${vendedorId}`;

        return this.http.get<any>(url)
                        .pipe(map(response => response.data));
    }
}