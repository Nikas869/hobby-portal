import store from '../store'

import AppHome from '../pages/Home'
import AppLogin from '../pages/auth/Login'
import AppRegister from '../pages/auth/Register'

export const routes = [
  {
    path: '',
    name: 'index',
    component: AppHome,
    meta: { title: 'Home' }
  },
  {
    path: '/login',
    name: 'login',
    component: AppLogin,
    meta: { title: 'Login' },
    beforeEnter: (to, from, next) => {
      if (store.getters.isAuthenticated) {
        next('/my-clubs')
      } else {
        next()
      }
    }
  },
  {
    path: '/register',
    name: 'register',
    component: AppRegister,
    meta: { title: 'Register' },
    beforeEnter: (to, from, next) => {
      if (store.getters.isAuthenticated) {
        next('/login')
      } else {
        next()
      }
    }
  },
  {
    path: '/my-clubs',
    name: 'my-clubs',
    component: null,
    meta: { title: 'My clubs', needAuth: true }
  },
  {
    path: '/*',
    redirect: '/'
  }
]
