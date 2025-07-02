import axios from 'axios'

const axiosInstance = axios.create({
  baseURL: import.meta.env.VITE_API_BASE || 'https://localhost:7196',
  headers: {
    'Content-Type': 'application/json'
  },
  timeout: 10000 
})


axiosInstance.interceptors.response.use(
  response => response,
  error => {
    console.error('API Error:', error)
    return Promise.reject(error)
  }
)

export default axiosInstance
