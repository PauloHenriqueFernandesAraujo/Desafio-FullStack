import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { hostSystem } from 'src/config/configuration.config';

@Injectable()
export class GenericService {

    constructor(public client: HttpClient) { }

    public post<T>(url: string, obj : T): Promise<T> {
        return new Promise((resolve) => {
            this.client.post(hostSystem + url, obj).subscribe(response => resolve(response as T),error => resolve(error));
        });
    }

    public put<T>(url: string, obj : T): Promise<T> {
        return new Promise((resolve) => {
            this.client.put(hostSystem + url, obj).subscribe(response => resolve(response as T),error => resolve(error));
        });
    }

    public get<T>(url: string): Promise<T> {
        return new Promise<T>((resolve) => { 
            this.client.get(hostSystem + url).subscribe(response => resolve(response as any),error => resolve(error));
        });
    }

    public delete<T>(url: string): Promise<T> {
        return new Promise<T>((resolve) => {
            this.client.delete(hostSystem + url).subscribe(response => resolve(response as T),error => resolve(error));
        });
    }

}