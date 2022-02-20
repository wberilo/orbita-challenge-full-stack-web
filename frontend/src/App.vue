<template>
  <v-app>
    <v-app-bar
      app
      color="white"
      dark
    >
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="https://maisaedu.com.br/hubfs/site-grupo-a/logo-mais-a-educacao.svg"
          transition="scale-transition"
          width="70"
        />
      </div>
    </v-app-bar>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "App",
  methods: {
  },

  data: () => ({
    //
  }),
});
</script>
