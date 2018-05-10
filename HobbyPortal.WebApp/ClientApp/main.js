import Vue from 'vue'
import Vuetify from 'vuetify'

import App from './App'
import router from './router'
import store from './store'

import 'vuetify/dist/vuetify.min.css'

Vue.use(Vuetify)

store.dispatch('restoreTokenFromStorage')

new Vue({
  el: '#app',
  template: '<App/>',
  components: { App },
  router,
  store
})
