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


header {
  background-image: url(https://images.unsplash.com/photo-1452251889946-8ff5ea7b27ab?q=80&w=2524&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  background-position: center 57%;
  background-size: cover;
  height: 30vh;
  border-radius: .25em;
}
</style>
