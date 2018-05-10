<template>
  <div id="app">
    <router-view></router-view>
  </div>
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