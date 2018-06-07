import api from '../../http/auth-api'

const state = {
  user: {
    id: null,
    firstName: null,
    lastName: null
  }
}

const getters = {
  user(state) {
    return state.user
  }
}

const mutations = {
  setUser(state, payload) {
    state.user = payload
  }
}

const actions = {
  setUser({ commit }, payload) {
    return new Promise((resolve, reject) => {
      api
        .get('/account/me')
        .then(response => {
          commit('setUser', response.data)
          resolve()
        })
        .catch(error => reject(error))
    })
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
