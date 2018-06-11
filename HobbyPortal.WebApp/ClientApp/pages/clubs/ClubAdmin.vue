<template>
  <v-container fluid grid-list-lg>
    <v-layout
      row
      wrap>
      <v-flex xs8 offset-xs2>
        <v-card>
          <v-card-title
            primary-title>
            <div class="headline mb-0 ellipsis">
              Дитяча школа робототехніки "Ботеон"
            </div>
          </v-card-title>

          <v-divider></v-divider>

          <v-container>
            <div>Детская школа робототехники "БОТЕОН" объявляет набор на курсы робототехники для детей от 7 лет. Курс "Основы робототехники. Умный дом. Internet of things" -Схемотехника и мехатроника; -Программирование в S4A, Ardublock, Arduino IDE (C++); -Технологии "Умный дом"; -Мобильные роботы и роботы на дистанционном управлении; -Соревнование роботов и многое другое. Записаться на курсы можно по телефону : 097-741-60-35 063-505-23-41 или посетив нашу школу в субботу, воскресенье с 10.00 до 16.00</div>
            <v-list dense>
              <v-list-tile>
                <v-list-tile-content>Мiсто:</v-list-tile-content>
                <v-list-tile-content class="align-end">Харків</v-list-tile-content>
              </v-list-tile>
              <v-list-tile>
                <v-list-tile-content>Адреса:</v-list-tile-content>
                <v-list-tile-content class="align-end">вул. Київська, б. 81, оф. 301</v-list-tile-content>
              </v-list-tile>
            </v-list>
          </v-container>

          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="primary">
              Редагувати
              <v-icon>keyboard_arrow_right</v-icon>
            </v-btn>
          </v-card-actions>

          <v-container grid-list-lg>
            <v-layout row wrap>
              <v-flex xs12>
                <v-card>
                  <v-card-title>
                    <div class="headline">
                      Молодша група
                    </div>
                  </v-card-title>
                  <v-card-text>
                    <p>
                      Категорія: Наука
                    </p>
                    <p>
                      Вік: 5 - 12
                    </p>
                    <p>
                      Місце: Основний зал
                    </p>
                    <p>
                      Інструктор: Цалко Альбін Вячеславович
                    </p>
                    <p>
                      Контакти: (0412)24-19-17
                    </p>
                  </v-card-text>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="primary" @click.native.stop="dialog = true">
                      Оповістити
                    </v-btn>
                    <v-dialog v-model="dialog" max-width="290">
                      <v-card>
                        <v-card-title class="headline">Введіть сповіщення:</v-card-title>
                        <v-card-text>
                          <v-text-field label="Текст" required multi-line="true" v-model="message"></v-text-field>
                        </v-card-text>
                        <v-card-actions>
                          <v-spacer></v-spacer>
                          <v-btn color="green darken-1" flat="flat" @click.native="close">Оповістити</v-btn>
                        </v-card-actions>
                      </v-card>
                    </v-dialog>
                    <v-btn color="primary">
                      Редагувати
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-flex>

              <v-flex xs12>
                <v-card>
                  <v-card-title>
                    <div class="headline">
                      Старша група
                    </div>
                  </v-card-title>
                  <v-card-text>
                    <p>
                      Категорія: Наука
                    </p>
                    <p>
                      Вік: 12 - 18
                    </p>
                    <p>
                      Місце: каб. 412
                    </p>
                    <p>
                      Інструктор: Шевчук Л.М.
                    </p>
                    <p>
                      Контакти: (0412) 55-14-89
                    </p>
                  </v-card-text>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="primary">
                      Оповістити
                    </v-btn>
                    <v-btn color="primary">
                      Редагувати
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-flex>

              <v-flex xs12>
                <v-btn block color="primary">
                  Додати
                </v-btn>
              </v-flex>
            </v-layout>
          </v-container>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import api from '../../http/auth-api'

export default {
  data() {
    return {
      dialog: false,
      message: null
    }
  },
  methods: {
    close() {
      this.dialog = false
      api.get('/notification/' + this.message)
    }
  }
}
</script>