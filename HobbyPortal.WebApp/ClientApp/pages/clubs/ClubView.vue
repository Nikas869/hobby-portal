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
                  Телефон: 097-741-60-35
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
            <v-container grid-list-lg>
              <v-layout row wrap>
                <v-flex v-for="(group, number) in this.club.groups" v-bind:key="number" xs12>
                  <v-card>
                    <v-card-title>
                      <div class="headline">
                        {{ group.name }}
                      </div>
                    </v-card-title>
                    <v-card-text>
                      <p>
                        Категорія: {{ group.category }}
                      </p>
                      <p>
                        Вік: {{ group.minAge }} - {{ group.maxAge }}
                      </p>
                      <p>
                        Місце: {{ group.place }}
                      </p>
                      <p>
                        Інструктор: {{ group.instructor }}
                      </p>
                      <p>
                        Контакти: {{ group.contacts }}
                      </p>
                    </v-card-text>
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn v-if="$store.getters.user.groups.indexOf(group.id) === -1"
                        @click="join(group.id)"
                        color="primary">
                        Вступити
                      </v-btn>
                    </v-card-actions>
                  </v-card>
                </v-flex>
              </v-layout>
            </v-container>
          </v-tab-item>

          <v-tab-item>
            <v-card flat>
              <v-card-text>
                <calendar-view
                  :events="events"
                  displayPeriodUom="week"
                  :showEventTimes="true"
                  :startingDayOfWeek="1"
                  style="height: 67vh;"></calendar-view>
              </v-card-text>
            </v-card>
          </v-tab-item>

          <v-tab-item>
            <v-container grid-list-lg>
              <v-layout row wrap>
                <v-flex v-for="(review, number) in this.club.reviews" v-bind:key="number" xs12>
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
                <v-flex xs5>
                  <v-btn color="primary">
                    Додати відгук
                  </v-btn>
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
import CalendarView from 'vue-simple-calendar'
require('vue-simple-calendar/dist/static/css/default.css')

export default {
  props: ['id'],
  components: {
    CalendarView
  },
  data() {
    return {
      club: null,
      events: [
        {
          id: 'e1',
          title: 'Молодша група',
          startDate: this.thisMonth(11, 18, 30),
          endDate: this.thisMonth(11, 19, 30),
          classes: 'orange'
        },
        {
          id: 'e2',
          title: 'Старша група',
          startDate: this.thisMonth(11, 19, 30),
          endDate: this.thisMonth(11, 20, 30),
          classes: 'green'
        },
        {
          id: 'e1',
          title: 'Молодша група',
          startDate: this.thisMonth(12, 18, 30),
          endDate: this.thisMonth(11, 19, 30),
          classes: 'orange'
        },
        {
          id: 'e2',
          title: 'Старша група',
          startDate: this.thisMonth(12, 19, 30),
          endDate: this.thisMonth(11, 20, 30)
        },
        {
          id: 'e1',
          title: 'Молодша група',
          startDate: this.thisMonth(13, 18, 30),
          endDate: this.thisMonth(11, 19, 30)
        },
        {
          id: 'e2',
          title: 'Старша група',
          startDate: this.thisMonth(14, 19, 30),
          endDate: this.thisMonth(11, 20, 30)
        },
        {
          id: 'e1',
          title: 'Молодша група',
          startDate: this.thisMonth(15, 18, 30),
          endDate: this.thisMonth(11, 19, 30),
          classes: 'orange'
        },
        {
          id: 'e2',
          title: 'Старша група',
          startDate: this.thisMonth(15, 19, 30),
          endDate: this.thisMonth(11, 20, 30)
        }
      ]
    }
  },
  methods: {
    join(id) {
      this.$store.getters.user.groups.push(id)
    },
    thisMonth(d, h, m) {
      const t = new Date()
      return new Date(t.getFullYear(), t.getMonth(), d, h || 0, m || 0)
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
