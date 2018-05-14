<template>
    <v-container fluid grid-list-lg tag="section">
        <v-layout row wrap>
            <v-flex sm6 offset-sm3>
                <v-card>
                    <v-card-title>
                        <h1 class="headline">Create new club</h1>
                    </v-card-title>
                </v-card>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex sm6 offset-sm3>
                <v-form ref="form" v-model="valid" lazy-validation>
                    <v-card>
                        <v-card-text>
                            <div>
                                <v-text-field 
                                    v-model="title"
                                    :rules="titleRules"
                                    label="Title">
                                </v-text-field>
                                <v-text-field 
                                    v-model="description"
                                    :rules="descriptionsRules"
                                    multi-line
                                    label="Description">
                                </v-text-field>
                                <v-text-field 
                                    v-model="town"
                                    :rules="townRules"
                                    label="Town">
                                </v-text-field>
                                <v-text-field
                                    v-model="address"
                                    :rules="addressRules"
                                    label="Address">
                                </v-text-field>
                                <v-btn
                                    @click="submit"
                                    dark
                                    color="teal">
                                    Submit
                                </v-btn>
                                <v-btn
                                    @click="clear" 
                                    flat>
                                    Clear
                                </v-btn>
                            </div>
                        </v-card-text>
                        <v-card-actions>
                        </v-card-actions>
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
      valid: true,
      title: '',
      titleRules: [v => !!v || 'Title is required'],
      description: '',
      descriptionsRules: [
        v => !!v || 'Description is required',
        v =>
          (v && v.length >= 10) || 'Description must be at least 10 characters'
      ],
      town: '',
      townRules: [v => !!v || 'Town is required'],
      address: '',
      addressRules: [v => !!v || 'Address is required']
    }
  },
  methods: {
    submit() {
      if (this.$refs.form.validate()) {
        api
          .post('/clubs', {
            title: this.title,
            description: this.description,
            town: this.town,
            address: this.address
          })
          .then(response => {
            alert(response.data.id)
          })
          .catch(response => {
            alert(response)
          })
      }
    },
    clear() {
      this.$refs.form.reset()
    }
  }
}
</script>