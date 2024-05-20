<script setup>
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';

async function createRecipe() {
    try {
        await recipesService.createRecipe(createData)
    }
    catch (error) {
        Pop.error(error);
    }
}

const createData = ref({
    title: '',
    instructions: '',
    img: '',
    category: '',
})
</script>


<template>
    <div class="modal fade" id="createModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-hero text-light title">
                    <h1 class="modal-title fs-3 text-capitalize" id="exampleModalLabel">new recipe</h1>
                    <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal"
                        aria-label="Close"></button>
                </div>
                <div class="modal-body container">
                    <form @submit.prevent="createRecipe()" class="row">
                        <div class="col-6">
                            <label for="title" class="text-capitalize form-label">title</label>
                            <input v-model="createData.title" type="text" id="title" class="form-control" required
                                minlength="3" maxlength="50" placeholder="Title">
                        </div>
                        <div class="col-5">
                            <label for="category" class="form-label">Category</label>
                            <select v-model="createData.category" name="category" id="category" class="form-control">
                                <option value="breakfast" class="text-capitalize">Breakfast</option>
                                <option value="lunch" class="text-capitalize">Lunch</option>
                                <option value="dinner" class="text-capitalize">Dinner</option>
                                <option value="snack" class="text-capitalize">Snack</option>
                                <option value="dessert" class="text-capitalize">Dessert</option>
                                <option value="" disabled selected>Choose a Category</option>
                            </select>
                        </div>
                        <div class="col-12">
                            <label for="img" class="form-label">Image Link</label>
                            <input v-model="createData.img" type="url" class="form-control" placeholder="http://...">
                        </div>
                        <div class="col-12">
                            <label for="instructions" class="form-label">Instructions</label>
                            <textarea v-model="createData.instructions" name="instructions" id="instructions" cols="30"
                                rows="10" class="form-control" minlength="5" maxlength="5000"></textarea>
                        </div>

                        <div class="d-flex justify-content-end mt-2">
                            <span role="button" type="submit"
                                class="bg-hero text-center text-light text-capitalize col-3">submit</span>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped>
.modal-content {
    border-radius: 0px;
}

.modal-header {
    border-radius: 0px;
}
</style>