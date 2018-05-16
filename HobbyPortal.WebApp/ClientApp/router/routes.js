import store from '../store'

import AppHome from '../pages/Home'
import AppLogin from '../pages/auth/Login'
import AppRegister from '../pages/auth/Register'
import AppProfile from '../pages/profile/Profile'
import AppClubs from '../pages/clubs/Clubs'
import AppClubsList from '../pages/clubs/ClubsList'
import AppMyClubs from '../pages/clubs/ClubsMy'
import AppCreateClub from '../pages/clubs/ClubsCreate'
import AppNotifications from '../pages/notifications/Notifications'

export const routes = [
  {
    path: '',
    name: 'index',
    component: AppHome,
    meta: { title: 'Головна' }
  },
  {
    path: '/login',
    name: 'login',
    component: AppLogin,
    meta: { title: 'Авторизація' },
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
    meta: { title: 'Реєстрація' },
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
    path: '/clubs',
    component: AppClubs,
    meta: { needAuth: true },
    children: [
      {
        path: '',
        component: AppClubsList,
        meta: { title: 'Усі клуби' }
      },
      {
        path: 'my',
        component: AppMyClubs,
        meta: { title: 'Мої клуби' }
      },
      {
        path: 'create',
        component: AppCreateClub,
        meta: { title: 'Новий клуб' }
      }
    ]
  },
  {
    path: '/notifications',
    name: 'notifications',
    component: AppNotifications,
    meta: { title: 'Сповіщення', needAuth: true }
  },
  {
    path: '/*',
    redirect: '/'
  }
]
