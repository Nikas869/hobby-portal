<template>
    <v-app>
    <app-header></app-header>
    <v-content>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-content>
    <app-footer></app-footer>
  </v-app>
</template>

<script>
import AppHeader from './layout/Header'
import AppFooter from './layout/Footer'

export default {
  name: 'App',
  components: {
    AppHeader,
    AppFooter
  },
  created() {
    this.$store.dispatch('restoreTokenFromStorage')
  }
}
</script>