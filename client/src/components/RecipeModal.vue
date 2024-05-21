<script setup>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

const recipe = computed(() => AppState.activeRecipe)
</script>


<template>
    <div v-if="recipe" class="modal fade modal-lg" id="recipeModal" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body p-0">
                    <div class="row">
                        <div class="col-4 d-none d-md-block">
                            <img :src="recipe.img" :alt="recipe.title" class="img-fluid">
                        </div>
                        <div class="col p-3">
                            <div class="row">
                                <h2 class="title m-md-0 p-md-0">{{ recipe.title }}</h2>
                                <p
                                    class="bgglass rounded-pill text-light col-6 col-lg-2 ms-3 ms-md-0 mb-0 me-3 text-capitalize text-center">
                                    {{
                                        recipe.category
                                    }}</p>
                            </div>
                            <div class="row justify-content-center gap-4 mt-5">
                                <div class="col-5 shadow rounded text-center cardbody">
                                    <div class="row text-center bg-hero cardtitle title text-light p-1">
                                        <h4>Recipe Steps</h4>
                                    </div>
                                    <p>{{ recipe.instructions }}</p>
                                </div>
                                <div class="col-5 shadow rounded text-center cardbody">
                                    <div class="row bg-hero cardtitle title text-light p-1">
                                        <h4>Ingredients</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
img {
    object-fit: cover;
    object-position: center;
    height: 80vh;
    border-radius: 5px 0px 0px 5px;
}

.cardtitle {
    border-radius: 5px 5px 0px 0px;
}

.cardbody {
    background-color: rgba(40, 133, 52, 0.568);
}
</style>