<template>
  <app-layout>
    <v-container fluid fill-height>
      <v-layout align-center justify-center>
        <v-flex xs12 sm8 md4>
          <v-card class="elevation-12">
            <v-toolbar dark color="primary">
              <v-toolbar-title>Форма авторизації</v-toolbar-title>
            </v-toolbar>
            <v-card-text>
              <v-form ref="form" v-model="valid" lazy-validation>
                <v-text-field
                  v-model="email"
                  :rules="emailRules"
                  @input="clearErrors"
                  prepend-icon="mail" 
                  name="email" 
                  label="Електронная пошта" 
                  type="text"
                  required>
                </v-text-field>
                <v-text-field 
                  v-model="password"
                  :rules="requiredFieldRule"
                  @input="clearErrors"
                  prepend-icon="lock" 
                  name="password" 
                  label="Пароль" 
                  type="password"
                  required>
                </v-text-field>
              </v-form>
              <p v-if="errors">{{ errors }}</p>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn 
                @click="onLogin"
                color="primary">
                Авторизуватися
              </v-btn>
            </v-card-actions>
            <v-progress-linear v-if="loading" :indeterminate="true"></v-progress-linear>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </app-layout>
</template>

<script>
import AppLayout from '../../layout/MinimalLayout'

export default {
  components: {
    AppLayout
  },
  data() {
    return {
      email: null,
      emailRules: [
        v => !!v || "Обов'язкове поле",
        v =>
          /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) ||
          'Вкажіть правильну електронну адресу'
      ],
      password: null,
      requiredFieldRule: [v => !!v || "Обов'язкове поле"],
      errors: null,
      valid: true,
      loading: false
    }
  },
  methods: {
    onLogin() {
      if (this.$refs.form.validate()) {
        this.loading = true
        this.$store
          .dispatch('login', {
            email: this.email,
            password: this.password
          })
          .then(response => this.$router.push('/my-clubs'))
          .catch(error => {
            if (error.response.status === 401) {
              this.errors = 'Неправильна адреса чи пароль'
            } else {
              this.errors = 'Виникла помилка, спробуйте пізніше'
            }
          })
          .then(() => (this.loading = false))
      }
    },
    clearErrors() {
      this.errors = null
    }
  }
}
</script>
