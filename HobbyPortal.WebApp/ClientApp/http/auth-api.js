import axios from 'axios'
import { API_URL } from '../.env'
import store from '../store'

const api = axios.create({
  baseURL: API_URL
})

api.interceptors.request.use(request => {
  request.headers['Authorization'] = 'Bearer ' + store.getters.token
  return request
})

export default api
