import { Recipe } from "./Recipe.js"

export class Favorite extends Recipe{
    constructor(data){
        super(data)
        this.favoriteid = data.favoriteId
        this.recipeId = data.id
        this.createdAt = data.createdAt
        this.updatedAt = data.updatedAt
        this.accountId = data.creatorId
    }
}