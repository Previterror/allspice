/* eslint-disable no-console */
import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService {
  async getRecipes() {
    const res = await api.get('api/recipes')
    const recipes = res.data.map(recipeData => new Recipe(recipeData))
    AppState.recipes = recipes
    // console.log(AppState.recipes)
  }

}

export const recipesService = new RecipesService