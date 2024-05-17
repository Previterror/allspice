<script setup>

</script>


<template>
    <div class="row recipecard shadow">
        <div class="col d-flex flex-column justify-content-between py-2">
            <div class="row px-2 justify-content-between">
                <span
                    class="bgglass rounded-pill text-light col-10 col-md-5 text-capitalize text-center p-2">breakfast</span>
                <span class="col-1 me-2 text-danger "><i class="mdi mdi-heart bgglass p-1 rounded"></i></span>
            </div>
            <div class="row px-2">
                <div class="bgglass rounded text-light col-12 p-2 text-capitalize">
                    pumpkin
                    soup</div>
            </div>
        </div>
    </div>

</template>


<style lang="scss" scoped>
.recipecard {
    background-image: url(https://images.unsplash.com/photo-1476718406336-bb5a9690ee2a?q=80&w=2000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
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