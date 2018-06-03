<template>
  <v-container fluid grid-list-lg>
    <v-layout row wrap>
      <v-data-iterator
        :items="clubs"
        :rows-per-page-items="rowsPerPageItems">
        <v-flex
          slot="item"
          slot-scope="props"
          xs12>
          <v-card>
            <v-card-title primary-title>
              <div class="headline mb-0 ellipsis">
                {{ props.item.name }}
              </div>
            </v-card-title>

            <v-divider></v-divider>

            <v-container>
              <div>{{ props.item.description }}</div>
              <v-list dense>
                <v-list-tile>
                  <v-list-tile-content>Мiсто:</v-list-tile-content>
                  <v-list-tile-content class="align-end">{{ props.item.city }}</v-list-tile-content>
                </v-list-tile>
                <v-list-tile>
                  <v-list-tile-content>Адреса:</v-list-tile-content>
                  <v-list-tile-content class="align-end">{{ props.item.address }}</v-list-tile-content>
                </v-list-tile>
              </v-list>
            </v-container>

            <v-card-actions>
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
      </v-data-iterator>
    </v-layout>
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