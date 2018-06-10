<template>
  <v-container fluid>
    <v-layout row wrap>
      <v-flex xs12 md8 offset-md2>
        <v-tabs grow>
          <v-tab ripple>
            Основна інформація
          </v-tab>
          
          <v-tab ripple>
            Напрямки
          </v-tab>
          
          <v-tab ripple>
            Календар
          </v-tab>
          
          <v-tab ripple>
            Відгуки
          </v-tab>

          <v-tab-item>
            <v-card flat>
              <v-card-text>
                <p class="headline">
                  {{ this.club.name }}
                </p>
                <p class="title">
                  {{ this.club.description }}
                </p>
                <p class="title">
                  Телефон: {{ this.club.phone }}
                </p>
                <p class="title">
                  Місто: {{ this.club.city }}
                </p>
                <p class="title">
                  Адреса: {{ this.club.address }}
                </p>
              </v-card-text>
            </v-card>
          </v-tab-item>

          <v-tab-item>
            <v-card flat>
              <v-card-title>
                {{ this.club.name }}
              </v-card-title>
              <v-card-text>
                {{ this.club.description }}
              </v-card-text>
            </v-card>
          </v-tab-item>

          <v-tab-item>
            <v-card flat>
              <v-card-title>
                {{ this.club.name }}
              </v-card-title>
              <v-card-text>
                {{ this.club.description }}
              </v-card-text>
            </v-card>
          </v-tab-item>

          <v-tab-item>
            <v-container grid-list-lg>
              <v-layout row>
                <v-flex v-for="(review, number) in this.club.reviews" v-bind:key="number">
                  <v-card>
                    <v-card-text>
                      <p>
                        {{ review.text }}
                      </p>
                      <p>
                        Оцінка: {{ review.rating }}
                      </p>
                    </v-card-text>
                  </v-card>
                </v-flex>
              </v-layout>
            </v-container>
          </v-tab-item>
        </v-tabs>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import api from '../../http/api'

export default {
  props: ['id'],
  data() {
    return {
      club: null
    }
  },
  created() {
    api
      .get('clubs/' + this.id)
      .then(response => {
        this.club = response.data
        document.title = `${this.club.name} - ${this.$route.meta.title}`
      })
      .catch(error => {
        console.log(error)
      })
  }
}
</script>
