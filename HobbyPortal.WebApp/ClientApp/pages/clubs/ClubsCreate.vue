<template>
  <v-container fluid grid-list-lg tag="section">
    <v-layout row wrap>
      <v-flex xs12 md6 offset-md3>
        <v-card>
          <v-card-title>
            <h1 class="headline">Створити новий клуб</h1>
          </v-card-title>
        </v-card>
      </v-flex>

      <v-flex xs12 md6 offset-md3>
        <v-form ref="form" v-model="valid" lazy-validation>
          <v-card>
            <v-card-text>
              <div>
                <v-text-field
                  v-model="name"
                  :rules="requiredFieldRule"
                  label="Назва"
                  required>
                </v-text-field>
                <v-text-field
                  v-model="description"
                  :rules="descriptionsRules"
                  multi-line
                  label="Опис"
                  required>
                </v-text-field>
                <v-select
                  :loading="cityLoading"
                  :items="cities"
                  :rules="requiredFieldRule"
                  :search-input.sync="searchCity"
                  v-model="city"
                  item-text="name"
                  item-value="cityId"
                  label="Місто"
                  autocomplete
                  cache-items
                  required
                  prepend-icon="map">
                </v-select>
                <v-select
                  :loading="categoryLoading"
                  :items="categories"
                  :rules="requiredFieldRule"
                  :search-input.sync="searchCategory"
                  v-model="category"
                  item-text="name"
                  item-value="categoryId"
                  label="Категорія"
                  autocomplete
                  cache-items
                  required
                  prepend-icon="category">
                </v-select>
                <v-text-field
                  v-model="address"
                  :rules="requiredFieldRule"
                  label="Адреса"
                  required>
                </v-text-field>
                <v-btn
                  @click="submit"
                  dark
                  color="primary">
                  Створити
                </v-btn>
                <v-btn
                  @click="clear"
                  flat>
                  Очистити
                </v-btn>
              </div>
            </v-card-text>            
            <v-progress-linear v-if="formLoading" :indeterminate="true"></v-progress-linear>
          </v-card>
        </v-form>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import api from '../../http/auth-api'

export default {
  data() {
    return {
      name: null,
      description: null,
      descriptionsRules: [
        v => !!v || "Обов'язкове поле",
        v => (v && v.length >= 10) || 'Має бути не менше 10 симоволів'
      ],
      category: null,
      city: null,
      address: null,
      requiredFieldRule: [v => !!v || "Обов'язкове поле"],

      valid: true,
      cityLoading: false,
      categoryLoading: false,
      formLoading: false,
      searchCity: null,
      searchCategory: null,
      cities: [],
      categories: []
    }
  },
  watch: {
    searchCity(val) {
      val && this.findCity(val)
    },
    searchCategory(val) {
      val && this.findCategory(val)
    }
  },
  methods: {
    submit() {
      if (this.$refs.form.validate()) {
        this.formLoading = true
        api
          .post('/clubs', {
            name: this.name,
            description: this.description,
            cityId: this.city,
            categoryId: this.category,
            address: this.address
          })
          .then(response => {
            this.$router.push({ path: '/', params: { id: response.data } })
          })
          .catch(response => {
            console.log(response)
          })
          .then(() => (this.formLoading = false))
      }
    },
    clear() {
      this.$refs.form.reset()
    },
    findCity(filter) {
      this.cityLoading = true
      api
        .get('/data/cities', { params: { filter: filter } })
        .then(response => {
          this.cities = response.data
        })
        .catch(error => {
          console.log(error)
        })
        .then(() => {
          this.cityLoading = false
        })
    },
    findCategory(filter) {
      this.categoryLoading = true
      api
        .get('/data/categories', { params: { filter: filter } })
        .then(response => {
          this.categories = response.data
        })
        .catch(error => {
          console.log(error)
        })
        .then(() => {
          this.categoryLoading = false
        })
    }
  }
}
</script>