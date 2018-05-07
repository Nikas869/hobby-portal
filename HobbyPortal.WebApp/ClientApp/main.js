import Vue from 'vue'
import Vuetify from 'vuetify'

import AppLayout from './layout/Layout'
import router from './router'

import 'vuetify/dist/vuetify.min.css'

Vue.use(Vuetify)

new Vue({
  el: '#app',
  template: '<AppLayout/>',
  components: { AppLayout },
  router
})
