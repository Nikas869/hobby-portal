import store from '../store'

import AppHome from '../pages/Home'
import AppLogin from '../pages/auth/Login'
import AppRegister from '../pages/auth/Register'
import AppProfile from '../pages/profile/Profile'
import AppMyClubs from '../pages/clubs/MyClubs'
import AppNotifications from '../pages/notifications/Notifications'

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
    path: '/profile',
    name: 'profile',
    component: AppProfile,
    meta: { title: 'Profile', needAuth: true }
  },
  {
    path: '/my-clubs',
    name: 'my-clubs',
    component: AppMyClubs,
    meta: { title: 'My clubs', needAuth: true }
  },
  {
    path: '/notifications',
    name: 'notifications',
    component: AppNotifications,
    meta: { title: 'Notifications', needAuth: true }
  },
  {
    path: '/*',
    redirect: '/'
  }
]
