<template>
  <v-container fluid>
    <v-layout justify-center row>
      <v-flex xs3>
        <app-clubs-filter></app-clubs-filter>
      </v-flex>
      <v-flex xs7>
        <app-clubs-list :clubs="clubs"></app-clubs-list>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import AppClubsList from '../../components/club/ClubsList'
import AppClubsFilter from '../../components/club/ClubsFilter'
import api from '../../http/api'

export default {
  data() {
    return {
      clubs: []
    }
  },
  components: { AppClubsList, AppClubsFilter },
  created() {
    api
      .get('clubs')
      .then(response => {
        this.clubs = response.data
      })
      .catch(error => {
        console.log(error)
      })
  }
}
</script>