<template>
  <app-layout>
    <v-container fluid>
      <img :src="require('../assets/landing.png')" height="250">
      <h1>Клуби та гуртки України</h1>
      <v-btn 
        to="/clubs"
        class="mt-4"
        color="primary"
        large>
        Перейти до каталогу
      </v-btn>
      <section>
        <v-layout
          column
          wrap
          class="my-2"
          align-center
          >
          <v-flex xs12>
            <v-container grid-list-xl>
              <v-layout row wrap align-center>
                <v-flex xs12 md4>
                  <v-card class="elevation-0 transparent">
                    <v-card-text class="text-xs-center">
                      <v-icon x-large class="teal--text">color_lens</v-icon>
                    </v-card-text>
                    <v-card-title primary-title class="layout justify-center">
                      <div class="subheader text-xs-center">Якщо ви пропонуєте освітні, навчальні, спортивні, розвиваючі гуртки, активності та клуби, ми раді вітати вас у проекті та пропонуємо долучитися до веб-сервісу, зареєструвавшись та додавши свій клуб.</div>
                    </v-card-title>
                  </v-card>
                </v-flex>
                <v-flex xs12 md4>
                  <v-card class="elevation-0 transparent">
                    <v-card-text class="text-xs-center">
                      <v-icon x-large class="teal--text">flash_on</v-icon>
                    </v-card-text>
                    <v-card-title primary-title class="layout justify-center">
                      <div class="subheader">Веб-система створюється для батьків в першу чергу, щоб вони мали можливість бачити усю базу позакласної активності, вибирати по фільтрам (найближчий до дому, по віку, по напрямку діяльності) гурток для своєї дитини.</div>
                    </v-card-title>
                  </v-card>
                </v-flex>
                <v-flex xs12 md4>
                  <v-card class="elevation-0 transparent">
                    <v-card-text class="text-xs-center">
                      <v-icon x-large class="teal--text">build</v-icon>
                    </v-card-text>
                    <v-card-title primary-title class="layout justify-center">
                      <div class="subheader text-xs-center">У кожного клубу в подальшому буде можливість вести власну сторінку на порталі, наповнювати її новинами, фотографіями, змінювати і оновлювати дані про гурток, його характеристики тощо.</div>
                    </v-card-title>
                  </v-card>
                </v-flex>
              </v-layout>
            </v-container>
          </v-flex>
        </v-layout>
      </section>
    </v-container>
  </app-layout>
</template>

<script>
import AppLayout from '../layout/Layout'
import { mapActions } from 'vuex'
import { api } from '../http/api'

export default {
  name: 'app',
  components: { AppLayout }
}
</script>

<style scoped>
#app {
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
