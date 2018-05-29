<template>
  <v-container fluid>
    <v-data-iterator
      :items="clubs"
      :rows-per-page-items="rowsPerPageItems"
      content-tag="v-layout"
      row
      wrap>
      <v-flex
        slot="item"
        slot-scope="props"
        xs12>
        <v-card>
          <v-card-title><h4>{{ props.item.name }}</h4></v-card-title>
          <v-divider></v-divider>
          <v-list dense>
            <v-list-tile>
              <v-list-tile-content>Опис:</v-list-tile-content>
              <v-list-tile-content class="align-end">{{ props.item.description }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
              <v-list-tile-content>Мiсто:</v-list-tile-content>
              <v-list-tile-content class="align-end">{{ props.item.city }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
              <v-list-tile-content>Адреса:</v-list-tile-content>
              <v-list-tile-content class="align-end">{{ props.item.address }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
              <v-list-tile-content>Категорiя:</v-list-tile-content>
              <v-list-tile-content class="align-end">{{ props.item.category }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
              <v-list-tile-content>Групи:</v-list-tile-content>
              <v-list-tile-content class="align-end">{{ props.item.groups }}</v-list-tile-content>
            </v-list-tile>
          </v-list>
        </v-card>
      </v-flex>
    </v-data-iterator>
  </v-container>
</template>

<script>
export default {
  props: { clubs: Array },
  data() {
    return {
      rowsPerPageItems: [4, 8, 12]
    }
  }
}
</script>