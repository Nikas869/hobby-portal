<template>
  <v-container fluid grid-list-lg>
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
          <v-card-title
            primary-title>
            <div class="headline mb-0 ellipsis">
              {{ props.item.name }}
            </div>
            <v-spacer></v-spacer>
            <v-badge left>
              <span slot="badge">
                {{ props.item.rating }}
              </span>
              <v-icon>star</v-icon>
            </v-badge>
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
            <v-badge>
              <span slot="badge">{{ props.item.reviewsCount }}</span>
              <v-icon>comment</v-icon>
            </v-badge>
            <v-spacer></v-spacer>
            <v-btn
              :to="`/clubs/${props.item.id}`"
              color="primary" 
              flat>
              Детальніше
              <v-icon>keyboard_arrow_right</v-icon>
            </v-btn>
          </v-card-actions>
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