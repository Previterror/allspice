<!-- eslint-disable no-console -->
<script setup>
import { onMounted } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';


async function getRecipes() {
  try {
    await recipesService.getRecipes()
  }
  catch (error) {
    Pop.toast('Could not get recipes', 'error')
    console.log(error)
  }
}

onMounted(
  getRecipes
)
</script>

<template>
  <div class="row justify-content-between">
    <div class="col-3 mx-3">
      <RecipeCard />
    </div>
    <div class="col-3 mx-3">
      <RecipeCard />
    </div>
    <div class="col-3 mx-3">
      <RecipeCard />
    </div>
  </div>
</template>

<style scoped lang="scss"></style>
