<template>
  <v-data-table
    :headers="headers"
    :items="students"
    :items-per-page="5"
    loading="true"
    class="elevation-1"
  >
  <template v-slot:[`item.actions`]="{ item }">
      <v-btn @click="deleteStudent(item)" :disabled="!isFormValid" >Deletar</v-btn>
      <v-btn @click="$router.push(EDIT_STUDENT_ROUTER(item.ra))">Editar</v-btn>
    </template>
  </v-data-table>
</template>

<script lang="ts">
import Vue from "vue";
import {deleteStudent} from "@/util/services/StudentService";
import {EDIT_STUDENT_ROUTER} from "@/router/routes"

export default Vue.extend({
  name: "StudentForm",
  methods: {
    deleteStudent,
    EDIT_STUDENT_ROUTER
  },
  props: {
    students: {
      type: Array,
      default: () => [
        {
          name: "cronf",
          email: "crong",
          ra: "c",
          cpf: "c",
        },
      ],
    },
  },

  data: () => ({
    headers: [
      { text: "Registro Acadêmico", value: "ra" },
      { text: "Nome", value: "name" },
      { text: "CPF", value: "cpf" },
      { text: "Ações", value: "actions" },
    ],
    email: "",
    name: "",
    ra: "",
    cpf: "",
    isFormValid: false,
  }),
});
</script>
