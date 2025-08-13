export class Gift
{
    id:number=0;
    name?: string;
    cost!:number
    category?: Category;
    donorId!: number;
    img?:string;
    amount?:number=1
}
export enum Category{ 
    ""=0,
    "jewelry"=1,
    "cosmetics"=2,
    "books"=3,
    "kourses"=4,
    "variance"=5,
    "homeStyling"=6,
    "Specials"=7
         
     }