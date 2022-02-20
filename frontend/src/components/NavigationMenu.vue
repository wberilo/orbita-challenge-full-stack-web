<template>
  <v-card
   height="400px"
  >
    <v-navigation-drawer
      color="#ff203b"
      dark
      permanent
    >
      <v-list nav dense>
      <v-list-item link @click="$router.push(STUDENT_ROUTER())">
        <v-list-item-icon>
          <v-icon>mdi-account-multiple</v-icon>
        </v-list-item-icon>
        <v-list-item-title>Alunos</v-list-item-title>
      </v-list-item>
      <v-list-item link @click="$router.push(REGISTER_STUDENT_ROUTER())">
        <v-list-item-icon>
          <v-icon>mdi-account-multiple</v-icon>
        </v-list-item-icon>
        <v-list-item-title>Cadastrar Aluno</v-list-item-title>
      </v-list-item>
    </v-list>
    </v-navigation-drawer>
  </v-card>
</template>

<script lang="ts">
import Vue from "vue";
import { STUDENT_ROUTER, REGISTER_STUDENT_ROUTER } from "@/router/routes";

export default Vue.extend({
  name: "NavigationMenu",
  methods: {
    STUDENT_ROUTER,
    REGISTER_STUDENT_ROUTER,
  },

  data: () => ({
    //
  }),
});
</script>
