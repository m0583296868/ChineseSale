export class Users
{
    id!:number;
    name?: string;
    password!:string
    userName!: string;
    mail?: string;
    role?:string;
    phone?:string;
}

export enum Role{
  Admin=1,
  User=2
       
   }