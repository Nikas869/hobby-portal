<template>
  <app-layout>
    <v-container fluid fill-height>
      <v-layout align-center justify-center>
        <v-flex xs12 sm8 md4>
          <v-card class="elevation-12">
            <v-toolbar dark color="teal">
              <v-toolbar-title>Форма авторизації</v-toolbar-title>
            </v-toolbar>
            <v-card-text>
              <v-form>
                <v-text-field 
                  v-model="email" 
                  color="teal" 
                  prepend-icon="mail" 
                  name="email" 
                  label="Електронная пошта" 
                  type="text"
                  required>
                </v-text-field>
                <v-text-field 
                  v-model="password" 
                  color="teal" 
                  prepend-icon="lock" 
                  name="password" 
                  label="Пароль" 
                  type="password"
                  required>
                </v-text-field>
              </v-form>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn dark @click="onLogin" color="teal">Авторизуватися</v-btn>
            </v-card-actions>
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
      password: null
    }
  },
  methods: {
    onLogin() {
      this.$store.dispatch('login', {
        email: this.email,
        password: this.password
      })
    }
  }
}
</script>
