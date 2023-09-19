export interface Pager
{
    page:number,
    size:number,
    orderBy?:string,
    orderDirection?:string,
    search?:string
}