<template>
  <div>
    <header>
      <nav>
        <router-link to="/google">Google</router-link> |
        <router-link to="/bing">Bing</router-link>
      </nav>
    </header>
    <main>
      <router-view />
    </main>
  </div>
</template>

<script setup lang="ts">
  // No logic needed here yet
</script>

<style scoped>
  header {
    background-color: #f5f5f5;
    padding: 1rem;
    margin-bottom: 2rem;
  }

  nav a {
    margin: 0 10px;
    text-decoration: none;
    color: #333;
  }

    nav a.router-link-active {
      font-weight: bold;
      color: #007acc;
    }
</style>
