<script setup>
import Login from './components/Login.vue';


</script>

<template>
  <header class="d-flex justify-content-end bg-dark mx-5 my-3 p-2">
    <Login />
  </header>
  <main>
    <router-view />
  </main>
</template>

<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
