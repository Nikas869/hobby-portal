import Vue from 'vue'
import Router from 'vue-router'

import { routes } from './routes'
import { TITLE } from '../.env'
import store from '../store'

Vue.use(Router)

const router = new Router({
  linkActiveClass: 'is-active',
  mode: 'history',
  routes
})

router.beforeEach((to, from, next) => {
  if (to.meta.needAuth && !store.getters.isAuthenticated) {
    next('/login')
  } else {
    next()
  }
})

router.beforeResolve((to, from, next) => {
  document.title = `${to.meta.title} - ${TITLE}`
  next()
})

export default router
