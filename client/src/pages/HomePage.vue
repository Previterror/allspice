<!-- eslint-disable no-console -->
<script setup>
import { computed, onMounted, ref } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { favoritesService } from '../services/FavoritesService.js';
import App from '../App.vue';
import { Recipe } from '../models/Recipe.js';

const user = computed(() => AppState.account)

async function getRecipes() {
  try {
    await recipesService.getRecipes()
  }
  catch (error) {
    Pop.toast('Could not get recipes', 'error')
    console.error(error)
  }
}

const recipes = computed(() => {
  if (filterBy.value == 'myrecipes') { return AppState.recipes.filter(recipe => recipe.creatorId == user.value.id) }
  else if (filterBy.value == 'favorites') { return AppState.userFavorites }
  else { return AppState.recipes }
})

const filterBy = ref('home')

const filters = [
  {
    name: 'home',
  },
  {
    name: 'myrecipes'
  },
  {
    name: 'favorites'
  }
]

onMounted(
  getRecipes
)
</script>

<template>

  <div class="row justify-content-center text-center filter">
    <div class="border shadow bg-light d-block d-md-flex justify-content-around p-0 filterinterior">
      <span @click="filterBy = 'home'" class="text-capitalize col-12 col-md-4 selectable p-2 filterbuttons">home </span>
      <span @click="filterBy = 'myrecipes'" class="text-capitalize col-12 col-md-4 selectable p-2 filterbuttons">my
        recipes</span>
      <span @click="filterBy = 'favorites'"
        class="text-capitalize col-12 col-md-4 selectable p-2 filterbuttons">favorites</span>
    </div>
  </div>
  <div class="row justify-content-center justify-content-md-between">
    <div v-for="recipe in recipes" :key="recipe.id" class="col-10 col-md-3 m-3">
      <RecipeCard :recipe="recipe" />
    </div>
  </div>

  <div class="justify-content-end row">
    <button type="button" class="btn btn-primary rounded-pill fixed-bottom ms-5 mb-5 col-1" data-bs-toggle="modal"
      data-bs-target="#exampleModal">
      <i class="mdi mdi-plus-outline"></i>
    </button>
  </div>
  <CreateModal />
</template>

<style scoped lang="scss">
.filter {
  transform: translateY(-5vh);
  height: 10vh;
}

.filterinterior {
  max-width: 50%;
}

.filterbuttons {
  align-content: center;
  font-family: pt-serif-regular;
  font-size: large;
  color: green;
}
</style>
