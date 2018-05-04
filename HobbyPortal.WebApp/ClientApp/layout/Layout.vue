<template>
  <v-app>
    <v-navigation-drawer app></v-navigation-drawer>
    <app-header></app-header>
    <v-content>
      <v-container fluid>
        <app-main></app-main>
      </v-container>
    </v-content>
    <app-footer></app-footer>
  </v-app>
</template>

<script>
import AppHeader from './Header'
import AppFooter from './Footer'
import AppMain from '../App'

export default {
  name: 'AppLayout',
  components: {
    AppHeader,
    AppFooter,
    AppMain
  }
}
</script>

<style>

</style>
