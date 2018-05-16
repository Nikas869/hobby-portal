<template>
  <app-layout>
    <v-container fluid fill-height>
      <v-layout align-center justify-center>
        <v-flex xs12 sm8 md4>
          <v-card class="elevation-12">
            <v-toolbar dark color="primary">
              <v-toolbar-title>Форма реєстрації</v-toolbar-title>
            </v-toolbar>
            <v-card-text>
              <v-form ref="form" v-model="valid" lazy-validation>
                <v-text-field
                  v-model="firstName"
                  :rules="requiredFieldRule"
                  prepend-icon="account_circle"
                  label="Ім'я"
                  required>
                </v-text-field>
                <v-text-field
                  v-model="lastName"
                  :rules="requiredFieldRule"
                  prepend-icon="account_circle"
                  label="Прізвище"
                  required>                  
                </v-text-field>
                <v-text-field
                  v-model="phone"
                  :rules="requiredFieldRule"
                  mask="phone"
                  prepend-icon="phone"
                  label="Телефон"
                  required>
                </v-text-field>
                <v-menu
                  ref="menu"
                  :close-on-content-click="false"
                  v-model="menu"
                  :nudge-right="40"
                  lazy
                  transition="scale-transition"
                  offset-y
                  full-width
                  min-width="290px"
                >
                  <v-text-field
                    slot="activator"
                    v-model="date"
                    :rules="requiredFieldRule"
                    label="Дата народження"
                    prepend-icon="event"
                    readonly
                    required>
                  </v-text-field>
                  <v-date-picker
                    ref="picker"
                    v-model="date"
                    :max="new Date().toISOString().substr(0, 10)"
                    min="1900-01-01"
                    @change="save">
                  </v-date-picker>
                </v-menu>
                <v-text-field 
                  v-model="email"
                  :rules="emailRules"
                  prepend-icon="mail"
                  label="Електронна пошта" 
                  type="text"
                  required>
                </v-text-field>
                <v-text-field 
                  v-model="password"
                  :rules="requiredFieldRule"
                  prepend-icon="lock"
                  label="Пароль" 
                  type="password"
                  required>
                </v-text-field>
              </v-form>
              <p v-if="errors">{{ errors }}</p>
            </v-card-text>
            <v-card-actions>
              <v-btn
                @click="back"
                flat>
                Повернутися
              </v-btn>
              <v-spacer></v-spacer>
              <v-btn 
                color="primary" 
                @click="onRegister">
                Зареєструватися
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </app-layout>
</template>

<script>
import AppLayout from '../../layout/MinimalLayout'
import api from '../../http/api'

export default {
  components: {
    AppLayout
  },
  data() {
    return {
      menu: false,
      valid: true,
      errors: null,

      firstName: null,
      lastName: null,
      phone: null,
      email: null,
      password: null,
      date: null,

      requiredFieldRule: [v => !!v || "Обов'язкове поле"],
      emailRules: [
        v => !!v || "Обов'язкове поле",
        v =>
          /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) ||
          'Вкажіть правильну електронну адресу'
      ]
    }
  },
  watch: {
    menu(val) {
      val && this.$nextTick(() => (this.$refs.picker.activePicker = 'YEAR'))
    }
  },
  methods: {
    onRegister() {
      if (this.$refs.form.validate()) {
        this.$store
          .dispatch('register', {
            email: this.email,
            password: this.password,
            firstName: this.firstName,
            lastName: this.lastName,
            birthday: new Date(this.date).toISOString(),
            phone: this.phone
          })
          .then(response => {
            this.$router.push('/my-clubs')
          })
          .catch(error => {
            if (error.response.data) {
              this.errors = error.response.data
            }
          })
      }
    },
    save(date) {
      this.$refs.menu.save(date)
    },
    back() {
      this.$router.go(-1)
    }
  }
}
</script>
