<template>
  <v-data-table
    :headers="headers"
    :items="students"
    :items-per-page="5"
    :loading="!loaded"
    class="elevation-1"
  >
  <template v-slot:[`item.actions`]="{ item }">
      <v-btn @click="()=>{updatePropsMethod(item.ra).then(r => method())}" >Deletar</v-btn>
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
      default: () => [],
    },
    updatePropsMethod: Function,
    loaded : {
      type: Boolean,
      default: false,
    },
  },

  data: () => ({
    headers: [
      { text: "Registro Acadêmico", value: "ra" },
      { text: "Nome", value: "nome" },
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
