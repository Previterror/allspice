<script setup>
import Login from './components/Login.vue';


</script>

<template>
  <header class="container bg-dark my-3 p-2 shadow">
    <div class="row justify-content-end">
      <Login />
    </div>
    <div class="row justify-content-center">
      <div class="col-10 col-md-3 text-center text-light textshadow title">
        <h1>All-Spice</h1>
        <h5>Cherish Your Family And Their Cooking</h5>
      </div>
    </div>
  </header>
  <main class="container">
    <router-view />
  </main>
</template>

<style lang="scss">
@import "./assets/scss/main.scss";
@import url('https://fonts.googleapis.com/css2?family=PT+Serif:ital,wght@0,400;0,700;1,400;1,700&display=swap');

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

.textshadow {
  text-shadow: 2px 2px 2px black;
}

.title {
  font-family: pt-serif-regular;
}
</style>
