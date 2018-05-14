<template>
    <v-container fluid>
        <v-layout>
            <v-flex sm6 offset-sm3>
                <form>
                    <v-card>
                        <v-card-title primary-title>
                            <div>
                                <h3 class="headline mb-0">Create new club</h3>
                            </div>
                        </v-card-title>
                        <v-card-text>
                            <div>
                                <v-text-field v-model="name"></v-text-field>
                            </div>
                        </v-card-text>
                        <v-card-actions>
                        </v-card-actions>
                    </v-card>
                </form>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
export default {
  data() {
    return {
      name: '',
      desription: '',
      town: '',
      address: ''
    }
  }
}
</script>