<template>
  <v-container fluid>
    <v-layout 
      justify-center
      row>
      <v-flex xs2>
        filters
      </v-flex>
      <v-flex xs7>
        <app-clubs-list :clubs="clubs"></app-clubs-list>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import AppClubsList from '../../components/club/ClubsList'
import api from '../../http/api'

export default {
  data() {
    return {
      clubs: []
    }
  },
  components: { AppClubsList },
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