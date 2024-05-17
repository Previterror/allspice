/* eslint-disable no-console */
import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { api } from "./AxiosService.js"

class FavoritesService{

  async createFavorite(recipeId){
    const recipeData = {recipeId: recipeId}
    const res = await api.post('api/favorites', recipeData)
    // console.log('create res', res.data)
    const newFavorite = new Favorite(res.data)
    // console.log('create map', newFavorite)
    AppState.userFavorites.push(newFavorite)
  }
  async removeFavorite(favoriteId) {      
      //  console.log('favoriteId to remove', favoriteId)
       const res = await api.delete(`api/favorites/${favoriteId}`)
      //  console.log('delete res', res.data)
       const indexToRemove = AppState.userFavorites.findIndex(favorite => favorite.id = favoriteId)
       if(indexToRemove==-1){
        console.error('Invalid favorite index')
        return 
       }
       AppState.userFavorites.splice(indexToRemove, 1)
      //  console.log('Removed', indexToRemove)
  }

  async getFavorites() {
    const res = await api.get('account/favorites')
    // console.log('res',res)
    const favorites = res.data.map(favoritesData => new Favorite(favoritesData))
    AppState.userFavorites = favorites
    // console.log(AppState.userFavorites)
  }

}

export const favoritesService = new FavoritesService