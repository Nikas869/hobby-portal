<template>
  <v-container fluid grid-list-xl>
    <v-layout row wrap>
      <v-flex xs12>
        <v-text-field
          id="testing"
          name="input-1"
          label="Пошук за назвою"
          clearable
          solo>
        </v-text-field>
      </v-flex>

      <v-flex xs12>
        <v-card>
          <v-card-title class="subheading">
            Фільтр за характеристиками
          </v-card-title>
          <v-card-text>

            <v-select
              :loading="cityLoading"
              :items="cities"
              :search-input.sync="searchCity"
              v-model="city"
              item-text="name"
              item-value="cityId"
              label="Місто"
              autocomplete
              cache-items
              prepend-icon="map">
            </v-select>

            <v-select
              :loading="categoryLoading"
              :items="categories"
              :search-input.sync="searchCategory"
              v-model="category"
              item-text="name"
              item-value="categoryId"
              label="Категорія"
              autocomplete
              cache-items
              prepend-icon="category">
            </v-select>

            <p class="subheading">
              Вік: {{ age | asAge }}
            </p>
            <v-slider
              v-model="age"
              min="0"
              max="60"
              thumb-label
              persistent-hint>
            </v-slider>

            <p>
              Час проведення:
            </p>
            <v-checkbox
              label="Протягом всього дня"
              input-value="true"
              value
              hide-details>
            </v-checkbox>
            <v-checkbox
              label="Перша половина дня"
              hide-details>
            </v-checkbox>
            <v-checkbox
              label="Друга половина дня"
              hide-details>
            </v-checkbox>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      age: 0
    }
  },
  filters: {
    asAge(value) {
      if (value == 60) {
        return '60+'
      }
      return value > 0 ? value : 'Не має значення'
    }
  }
}
</script>
