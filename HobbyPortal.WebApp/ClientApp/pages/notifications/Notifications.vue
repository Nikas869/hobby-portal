<template>
  <app-layout>
    <v-container grid-list-md
      text-xs-center>
      <v-layout row wrap>
        <v-flex xs12 md6 offset-md3 mt-5>
          <p class="title">
            Налаштування сповіщень
          </p>
          <p class="subheading">
            На цій сторінці ви можете налаштувати методи, якими вам будуть надходити сповіщення від адміністрації ваших клубів
          </p>
        </v-flex>

        <v-flex xs12 md8 offset-md2 lg6 offset-lg3>
          <v-expansion-panel popout>
            <v-expansion-panel-content>
              <div slot="header">
                Telegram
              </div>
              <v-card>
                <v-card-text>
                  <p>
                    Для налаштування сповіщень через Telegram потрібно:
                  </p>
                  <p>
                    1. Почати діалог з Telegram ботом натиснувши кнопку "Написати боту"
                  </p>
                  <p>
                    2. Відправити боту повідомлення з текстом <code>{{ this.$store.getters.user.id }}</code>
                  </p>
                  <p>
                    3. Натиснути кнопку "Перевірити налаштування"
                  </p>
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn @click="openTelegramBot">
                    Написати боту
                  </v-btn>
                  <v-btn color="primary">
                    Перевірити налаштування
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-flex>
        
        <v-flex xs12 md8 offset-md2 lg6 offset-lg3>
          <v-expansion-panel popout>
            <v-expansion-panel-content>
              <div slot="header">
                Facebook
              </div>
              <v-card>
                <v-card-text>
                  asd
                </v-card-text>
              </v-card>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-flex>

        <v-flex xs12 md8 offset-md2 lg6 offset-lg3>
          <v-expansion-panel popout>
            <v-expansion-panel-content>
              <div slot="header">
                Email
              </div>
              <v-card>
                <v-card-text>
                  asd
                </v-card-text>
              </v-card>
            </v-expansion-panel-content>
          </v-expansion-panel>
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
    openTelegramBot() {
      window.open('https://telegram.me/clubs_and_societies_bot')
    }
  }
}
</script>