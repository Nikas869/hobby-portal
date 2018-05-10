import AppHome from '../pages/Home'
import AppLogin from '../pages/auth/Login'
import AppRegister from '../pages/auth/Register'

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
  },
  {
    path: '/register',
    name: 'register',
    component: AppRegister,
    meta: { title: 'Register' }
  }
]
