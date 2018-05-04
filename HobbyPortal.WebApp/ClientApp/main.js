import Vue from 'vue'
import Vuetify from 'vuetify'
import AppLayout from './layout/Layout'

import 'vuetify/dist/vuetify.min.css'

Vue.use(Vuetify)

new Vue({
  el: '#app',
  template: '<AppLayout/>',
  components: { AppLayout }
})
