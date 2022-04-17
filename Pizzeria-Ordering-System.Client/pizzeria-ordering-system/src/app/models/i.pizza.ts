import { IConstituents } from './i.constituents';

export interface IPizza
{
    id: number,
    name: string,
    price: number,
    description: string,
    imageUrl: string,
    constituents: IConstituents[]
}