<template>
    <v-toolbar app dark color="primary">
        <v-toolbar-items>
            <v-btn flat to="/">Головна</v-btn>
            <v-btn flat to="/clubs" exact>Каталог</v-btn>
        </v-toolbar-items>
        <v-spacer></v-spacer>
        <v-toolbar-items v-if="!isAuthenticated">
            <v-btn flat to='/register'>Реєстрація</v-btn>
            <v-btn flat to='/login'>Авторизація</v-btn>
        </v-toolbar-items>
        <v-toolbar-items v-if="isAuthenticated">
            <v-btn flat to='/clubs/my' exact>
                <v-icon dark left>sentiment_satisfied_alt</v-icon>
                Мої клуби
            </v-btn>
            
            <v-menu offset-y>
                <v-btn flat slot="activator">
                    Здравствуйте, {{ this.$store.getters.user.firstName }} {{ this.$store.getters.user.lastName }}!
                    <v-icon dark right>menu</v-icon>
                </v-btn>
                <v-list>
                    <v-list-tile to='/profile'>
                        <v-list-tile-avatar>
                            <v-icon>account_circle</v-icon>
                        </v-list-tile-avatar>
                        <v-list-tile-title>Мій профіль</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile to='/notifications'>
                        <v-list-tile-avatar>
                            <v-icon>notifications</v-icon>
                        </v-list-tile-avatar>
                        <v-list-tile-title>Сповіщення</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile to='/clubs/create'>
                        <v-list-tile-avatar>
                            <v-icon>add</v-icon>
                        </v-list-tile-avatar>
                        <v-list-tile-title>Створити клуб</v-list-tile-title>
                    </v-list-tile>
                    <v-divider></v-divider>
                    <v-list-tile @click="logout">
                        <v-list-tile-avatar>
                            <v-icon>exit_to_app</v-icon>
                        </v-list-tile-avatar>
                        <v-list-tile-title>Вихід</v-list-tile-title>
                    </v-list-tile>
                </v-list>
            </v-menu>
        </v-toolbar-items>
    </v-toolbar>
</template>

<script>
export default {
  computed: {
    isAuthenticated() {
      return this.$store.getters.isAuthenticated
    }
  },
  methods: {
    logout() {
      this.$store.dispatch('logout')
    }
  }
}
</script>
