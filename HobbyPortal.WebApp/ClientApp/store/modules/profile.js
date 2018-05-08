const state = {
  user: {
    email: ''
  }
}

const getters = {
  userEmail(state) {
    return state.user.email
  }
}

const mutations = {
  setUserEmail(state, payload) {
    state.user.email = payload
  }
}

const actions = {
  setUserEmail({ commit }, payload) {
    commit('setUserEmail', payload)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
