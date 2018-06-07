<template>
  <app-layout>
    <v-container fluid
      text-xs-center>
      <v-layout column justify-center>
        <v-flex>
          <img :src="require('../../assets/profile.png')">
        </v-flex>
        <v-flex>
          <h1>
            Ласкаво просимо, {{ this.$store.getters.user.firstName }} {{ this.$store.getters.user.lastName }}!
          </h1>
        </v-flex>
        <v-flex>
          <v-btn to="/clubs/my">
            Мої клуби
          </v-btn>
        </v-flex>
        <v-flex>
          <v-btn @click="logout">
            Вихід
          </v-btn>
        </v-flex>
      </v-layout>
    </v-container>
  </app-layout>
</template>

<script>
import AppLayout from '../../layout/Layout'

export default {
  components: { AppLayout },
  methods: {
    logout() {
      this.$store.dispatch('logout')
    }
  }
}
</script>