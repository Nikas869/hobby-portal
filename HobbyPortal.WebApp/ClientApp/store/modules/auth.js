import api from '../../http/api'
import router from '../../router'

const state = {
  token: null,
  expiration: null
}

const getters = {
  token(state) {
    return state.token
  },
  isAuthenticated(state) {
    return state.token !== null
  }
}

const mutations = {
  setToken(state, payload) {
    localStorage.setItem('token', payload)
    state.token = payload
  },
  clearToken(state, payload) {
    localStorage.removeItem('token')
    state.token = null
  },
  setExpiration(state, payload) {
    localStorage.setItem('expiration', payload)
    state.expiration = payload
  }
}

const actions = {
  register({ commit, dispatch }, payload) {
    return new Promise((resolve, reject) => {
      api
        .post('/auth/register', payload)
        .then(response => {
          commit('setToken', response.data.token)
          dispatch('setExpirationTime', response.data.expiration)
          resolve(response)
        })
        .catch(error => reject(error))
    })
  },
  login({ commit, dispatch }, payload) {
    return new Promise((resolve, reject) => {
      api
        .post('/auth/login', payload)
        .then(response => {
          commit('setToken', response.data.token)
          dispatch('setExpirationTime', response.data.expiration)
          resolve(response)
        })
        .catch(error => {
          reject(error)
        })
    })
  },
  logout({ commit }) {
    commit('clearToken')
    router.push('/')
  },
  setExpirationTime({ commit, dispatch }, payload) {
    dispatch('setUser')
    let now = new Date()
    let expirationDate = new Date(payload)
    let expirationTime = expirationDate.getTime() - now.getTime()
    commit('setExpiration', expirationDate)
    setTimeout(() => {
      dispatch('logout')
    }, expirationTime)
  },
  restoreTokenFromStorage({ commit, dispatch }) {
    let token = localStorage.getItem('token')
    let expiration = localStorage.getItem('expiration')
    if (token && expiration) {
      commit('setToken', token)
      dispatch('setExpirationTime', new Date(expiration))
    }
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
