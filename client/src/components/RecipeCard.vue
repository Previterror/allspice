<script setup>
import { computed, ref } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { AppState } from '../AppState.js';
import { favoritesService } from '../services/FavoritesService.js';
import Pop from '../utils/Pop.js';


const prop = defineProps(
    { recipe: { type: Recipe, required: true } }
)

const favorites = computed(() => AppState.userFavorites)

const isFavorite = computed(() => AppState.userFavorites.find(favorite => favorite.recipeId == prop.recipe.id))

const bgimg = computed(() => `url(${prop.recipe.img})`)


async function toggleFavorite() {
    try {
        if (isFavorite.value) {
            await favoritesService.removeFavorite(isFavorite.value.id)
        }
        await favoritesService.createFavorite(prop.recipe.id)

    } catch (error) {
        Pop.toast('Could not add favorite.', 'error')
    }
}

</script>


<template>
    <div class="row recipecard shadow">
        <div class="col d-flex flex-column justify-content-between py-2">
            <div class="row px-2 justify-content-between">
                <span class="bgglass rounded-pill text-light col-10 col-md-5 text-capitalize text-center p-2">
                    {{ recipe.category }}
                </span>
                <span role="button" v-if="favorites" class="col-1 me-2 ">
                    <i v-if="isFavorite" @click="toggleFavorite()"
                        class="mdi mdi-heart bgglass p-1 rounded text-danger"></i>
                    <i v-else @click="toggleFavorite()" class="mdi mdi-heart-outline bgglass p-1 rounded"></i>
                </span>
            </div>
            <div class="row px-2">
                <div class="bgglass rounded text-light col-12 p-2 text-capitalize">
                    {{ recipe.title }}
                </div>
            </div>
        </div>
    </div>

</template>


<style lang="scss" scoped>
.recipecard {
    background-image: v-bind(bgimg);
    background-position: center;
    background-size: cover;
    border-radius: 5px;
    height: 25vh;
    font-weight: bold;
}

.bgglass {
    background-color: rgba(112, 109, 109, 0.7);
    backdrop-filter: blur(10px);
}
</style>