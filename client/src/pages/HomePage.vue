<!-- eslint-disable no-console -->
<script setup>
import { computed, onMounted } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { favoritesService } from '../services/FavoritesService.js';

const recipes = computed(() => AppState.recipes)
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

onMounted(
  getRecipes
)
</script>

<template>
  <div v-if="user" class="row justify-content-center justify-content-md-between">
    <div v-for="recipe in recipes" :key="recipe.id" class="col-10 col-md-3 m-3">
      <RecipeCard :recipe="recipe" />
    </div>
  </div>
</template>

<style scoped lang="scss"></style>
