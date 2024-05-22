<!-- eslint-disable no-console -->
<script setup>
import { computed, ref } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { ingredientsService } from '../services/IngredientsService.js';

const recipe = computed(() => AppState.activeRecipe)


let ingrData = ref({
    name: '',
    quantity: '',
    recipeId: ''
})

async function addIngredient() {
    try {
        ingrData.value.recipeId = recipe.value.id
        console.log('ingrData', ingrData.value);
        await ingredientsService.addIngredient(ingrData)
    }
    catch (error) {
        Pop.error(error);
        console.error(error)
    }
}
</script>


<template>
    <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div v-if="recipe" class="modal-content">
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
                                <div class="col-10 col-md-5 shadow rounded text-center cardbody">
                                    <div class="row text-center bg-hero cardtitle title text-light p-1">
                                        <h4>Recipe Steps</h4>
                                    </div>
                                    <p class="pt-2">{{ recipe.instructions }}</p>
                                </div>
                                <div class="col-10 col-md-5 shadow rounded text-center cardbody">
                                    <div class="row bg-hero cardtitle title text-light p-1">
                                        <h4>Ingredients</h4>
                                    </div>
                                    <form @submit.prevent="addIngredient()" class="mt-1 d-flex">
                                        <div class="input-group mb-3">
                                            <input v-model="ingrData.quantity" type="text" class="form-control"
                                                placeholder="Quantity">
                                            <input v-model="ingrData.name" type="text" class="form-control"
                                                placeholder="Ingredient" aria-label="Add Ingredient"
                                                aria-describedby="basic-addon2">
                                            <div class="input-group-append">
                                                <button class="btn btn-hero appendbutton" type="submit"><i
                                                        class="mdi mdi-plus"></i></button>
                                            </div>
                                        </div>
                                    </form>
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
    background-color: rgba(93, 158, 102, 0.568);
    height: 50vh;
}

.appendbutton {
    border-radius: 0px 5px 5px 0px;
}
</style>