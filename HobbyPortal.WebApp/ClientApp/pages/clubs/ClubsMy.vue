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
            <v-spacer></v-spacer>
            <v-badge left>
              <span slot="badge">
                9.5
              </span>
              <v-icon>star</v-icon>
            </v-badge>
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
            <v-badge>
              <span slot="badge">2</span>
              <v-icon>comment</v-icon>
            </v-badge>
            <v-spacer></v-spacer>
            <v-btn
              color="primary" 
              flat>
              Детальніше
              <v-icon>keyboard_arrow_right</v-icon>
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {}
</script>