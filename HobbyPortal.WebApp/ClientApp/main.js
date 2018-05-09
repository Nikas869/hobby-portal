import Vue from 'vue'
import Vuetify from 'vuetify'
import axios from 'axios'
import VueAxios from 'vue-axios'

import App from './App'
import router from './router'
import store from './store'

import 'vuetify/dist/vuetify.min.css'

Vue.use(VueAxios, axios)
Vue.use(Vuetify)

new Vue({
  el: '#app',
  template: '<App/>',
  components: { App },
  router,
  store
})
