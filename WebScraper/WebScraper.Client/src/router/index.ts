import { createRouter, createWebHistory } from 'vue-router'
import GoogleSearch from '../views/GoogleSearch.vue'
import BingSearch from '../views/BingSearch.vue'

const routes = [
  { path: '/', redirect: '/google' }, // Default route
  { path: '/google', name: 'GoogleSearch', component: GoogleSearch },
  { path: '/bing', name: 'BingSearch', component: BingSearch }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
