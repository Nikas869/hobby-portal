<template>
  <div id="app">
    <img :src="require('../assets/logo.png')">
    <h1>Welcome to Your Vue.js App, {{ email }}!</h1>
    <h2>Essential Links</h2>
    <ul>
      <li><a href="https://vuejs.org" target="_blank">Core Docs</a></li>
      <li><a href="https://forum.vuejs.org" target="_blank">Forum</a></li>
      <li><a href="https://chat.vuejs.org" target="_blank">Community Chat</a></li>
      <li><a href="https://twitter.com/vuejs" target="_blank">Twitter</a></li>
    </ul>
    <h2>Ecosystem</h2>
    <ul>
      <li><a href="http://router.vuejs.org/" target="_blank">vue-router</a></li>
      <li><a href="http://vuex.vuejs.org/" target="_blank">vuex</a></li>
      <li><a href="http://vue-loader.vuejs.org/" target="_blank">vue-loader</a></li>
      <li><a href="https://github.com/vuejs/awesome-vue" target="_blank">awesome-vue</a></li>
    </ul>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  name: 'app',
  computed: {
    email() {
      return this.$store.getters.userEmail
    }
  },
  created() {
    this.$http
      .get('http://localhost:60857/api/account/info', {
        headers: {
          Authorization:
            'bearer ' +
            'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhc2QxQGFzZC5hc2QiLCJqdGkiOiJkMjE0NzU3Yi1lMDFkLTRhYmItOTUyYS1lNTg4NTQ0YjUwNTMiLCJlbWFpbCI6ImFzZDFAYXNkLmFzZCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhc2QxQGFzZC5hc2QiLCJuYmYiOjE1MjU3Njg2MzMsImV4cCI6MTUyNTc3MDQzMywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo0NDM4My8iLCJhdWQiOiJhcGkifQ.MIXDAuj5ieuW8MaekQYKGWA4NeXV6QzjifE9q3NLkTI'
        }
      })
      .then(response => this.$store.dispatch('setUserEmail', response.data))
      .catch(error => console.log(error))
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

h1,
h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
