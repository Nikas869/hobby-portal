import { api } from '../../http/api'

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
    state.token = payload
  },
  clearToken(state, payload) {
    state.token = null
  },
  setExpiration(state, payload) {
    state.expiration = payload
  }
}

const actions = {
  register({ commit, dispatch }, payload) {
    api.post('/auth/register', payload).then(response => {
      commit('setToken', response.data.token)
      dispatch('setExpirationTime', response.data.expiration)
    })
  },
  login({ commit, dispatch }, payload) {
    api.post('/auth/login', payload).then(response => {
      commit('setToken', response.data.token)
      dispatch('setExpirationTime', response.data.expiration)
    })
  },
  setExpirationTime({ commit, dispatch }, payload) {
    let now = new Date()
    let expirationDate = new Date(payload)
    let expirationTime = expirationDate.getTime() - now.getTime()
    commit('setExpiration', expirationDate)
    setTimeout(() => {
      dispatch('logout')
    }, expirationTime)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
