export class Favorite{
    constructor(data){
        this.id = data.favoriteId
        this.recipeId = data.id
        this.createdAt = data.createdAt
        this.updatedAt = data.updatedAt
        this.accountId = data.creatorId
    }
}