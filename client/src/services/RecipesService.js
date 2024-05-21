/* eslint-disable no-console */
import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService {
  async createRecipe(createData) {
      const res = await api.post('api/recipes', createData)
      // console.log('create res', res.data);
      const recipe = new Recipe(res.data)
      // console.log('new recipe', recipe);
      AppState.recipes.push(recipe)
  }
  async getRecipes() {
    const res = await api.get('api/recipes')
    const recipes = res.data.map(recipeData => new Recipe(recipeData))
    AppState.recipes = recipes
    // console.log(AppState.recipes)
  }

}

export const recipesService = new RecipesService