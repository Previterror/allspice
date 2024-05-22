import { api } from "./AxiosService.js";

/* eslint-disable no-console */
class IngredientsService{
    async addIngredient(ingrData) {
        const res = await api.post('api/ingredients', ingrData)
        console.log('add ing res', res.data);
    }

}

export const ingredientsService = new IngredientsService