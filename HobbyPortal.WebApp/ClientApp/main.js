import Vue from 'vue'
import Vuetify from 'vuetify'

import App from './App'
import router from './router'
import store from './store'

import 'vuetify/dist/vuetify.min.css'
import colors from 'vuetify/es5/util/colors'

Vue.use(Vuetify, {
  theme: {
    primary: colors.teal.base,
    secondary: colors.grey.base,
    accent: colors.teal.base
  }
})

store.dispatch('restoreTokenFromStorage')

new Vue({
  el: '#app',
  template: '<App/>',
  components: { App },
  router,
  store
})
