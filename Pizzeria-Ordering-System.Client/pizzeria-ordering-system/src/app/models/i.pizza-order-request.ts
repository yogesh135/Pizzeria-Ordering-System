export interface IPizzaOrderRequest {
    name: string,
    size: number,
    numberOfPizza: number,
    isAddCheese: boolean,
    isAddExtraCheese: boolean,
    ingredients: number[]
}