export class Supplier{
  constructor(
    public name:string,
    public ssn:string,
    public verifecationState:boolean,
    public totalSales:number,
    public accountNumber?:string){
  }

}
