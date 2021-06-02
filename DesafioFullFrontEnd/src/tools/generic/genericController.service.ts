import { Injectable } from '@angular/core';
import { GenericService } from './genericService.service';

@Injectable()
export class GenericController {

    constructor(public genericService: GenericService) { };

    public async onSave(api : string, obj : any): Promise<any> {
        obj.Id = obj._Id;


        if(obj._Id == null || obj._Id == undefined || obj._Id == "")
            return await this.genericService.post(api + "/create", obj);
        
        return await this.genericService.put(api + "/update", obj);
    }

    public async onEdit(api : string,id: string): Promise<any> {
        return await this.genericService.get(api + "/findone/" + id);
    }

    public async onDelete(api : string,id: string): Promise<any> {
        return await this.genericService.delete(api + "/delete/" + id);
    }

}