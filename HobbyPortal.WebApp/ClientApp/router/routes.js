import AppHome from '../pages/Home'
import AppLogin from '../pages/auth/Login'

export const routes = [
  {
    path: '/',
    name: 'index',
    component: AppHome,
    meta: { title: 'Home' }
  },
  {
    path: '/login',
    name: 'login',
    component: AppLogin,
    meta: { title: 'Login' }
  }
]
