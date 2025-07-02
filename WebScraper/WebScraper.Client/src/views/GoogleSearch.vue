<template>
  <div class="google-search">
    <h2>Google Search</h2>

    <div>
      <label>Search Query:</label>
      <input v-model="keywords" placeholder="Enter search keywords" />
    </div>

    <div>
      <label>Target URL:</label>
      <input v-model="targetUrl" placeholder="Enter target URL" />
    </div>

    <div>
      <button @click="search" :disabled="loading">Search</button>
    </div>

    <div v-if="loading">Searching...</div>
    <div v-if="error" style="color: red">{{ error }}</div>
    <div v-if="positions.length > 0">
      <p>URL found at positions: {{ positions.join(', ') }}</p>
    </div>

    <div v-if="previousSearches.length > 0" class="history">
      <h3>Previous Searches</h3>
      <table>
        <thead>
          <tr>
            <th>Date</th>
            <th>Positions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(history, index) in previousSearches" :key="index">
            <td>{{ new Date(history.searchedAt).toLocaleString() }}</td>
            <td>{{ history.positions.join(', ') }}</td>
          </tr>
        </tbody>
      </table>
    </div>

  </div>
</template>

<script lang="ts">
  import { defineComponent, ref } from 'vue'
  import axios from '@/api/axiosInstance' 

  export default defineComponent({
    name: 'GoogleSearch',
    setup() {
      const keywords = ref('')
      const targetUrl = ref('')
      const loading = ref(false)
      const positions = ref<number[]>([])
      const error = ref('')
      const previousSearches = ref<any[]>([])

      const search = async () => {
        error.value = ''
        positions.value = []
        previousSearches.value = []
        loading.value = true

        try {
          const response = await axios.post('/api/seo/search', {
            keywords: keywords.value,
            targetUrl: targetUrl.value,
            numberOfResults: 100,
            engine: 'Google'
          })

          if (response.data.isSuccess) {
            positions.value = response.data.positions
            previousSearches.value = response.data.previousSearches || []
          } else {
            error.value = response.data.errorMessage || 'Something went wrong.'
          }
        } catch (err: any) {
          if (err.response && err.response.data?.errorMessage) {
            error.value = err.response.data.errorMessage
          } else {
            error.value = 'Network error or server is unreachable.'
          }
        } finally {
          loading.value = false
        }
      }

      return { keywords, targetUrl,loading, positions, previousSearches,error, search }
    }
  })
</script>

<style scoped>
  .google-search {
    max-width: 500px;
    margin: auto;
    padding: 1rem;
  }

    .google-search input {
      display: block;
      margin-bottom: 0.5rem;
      width: 100%;
      padding: 0.5rem;
    }

    .google-search button {
      padding: 0.5rem 1rem;
    }
</style>
