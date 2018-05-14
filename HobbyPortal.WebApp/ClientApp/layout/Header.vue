<template>
    <v-toolbar app dark color="teal">
        <v-toolbar-items>
            <v-btn flat to="/">Hobby portal</v-btn>
        </v-toolbar-items>
        <v-spacer></v-spacer>
        <v-toolbar-items v-if="!isAuthenticated">
            <v-btn flat to='/register'>Register</v-btn>
            <v-btn flat to='/login'>Login</v-btn>
        </v-toolbar-items>
        <v-toolbar-items v-if="isAuthenticated">
            <v-btn flat to='/clubs/my'>
                <v-icon dark left>sentiment_satisfied_alt</v-icon>
                My clubs
            </v-btn>
            
            <v-menu offset-y>
                <v-btn flat slot="activator">
                    Hello, stranger!
                    <v-icon dark right>menu</v-icon>
                </v-btn>
                <v-list>
                    <v-list-tile to='/profile'>
                        <v-list-tile-avatar>
                            <v-icon>account_circle</v-icon>
                        </v-list-tile-avatar>
                        <v-list-tile-title>Profile</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile to='/notifications'>
                        <v-list-tile-avatar>
                            <v-icon>notifications</v-icon>
                        </v-list-tile-avatar>
                        <v-list-tile-title>Notifications</v-list-tile-title>
                    </v-list-tile>
                    <v-list-tile to='/clubs/create'>
                        <v-list-tile-avatar>
                            <v-icon>plus</v-icon>
                        </v-list-tile-avatar>
                        <v-list-tile-title>Create club</v-list-tile-title>
                    </v-list-tile>
                    <v-divider></v-divider>
                    <v-list-tile @click="logout">
                        <v-list-tile-title class="text-xs-center">Logout</v-list-tile-title>
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
