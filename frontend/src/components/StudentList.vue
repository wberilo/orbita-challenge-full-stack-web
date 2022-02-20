<template>
<div style="width: -webkit-fill-available; margin: 20px">
  <v-data-table
    :headers="headers"
    :items="students"
    :items-per-page="5"
    :loading="!loaded"
    class="elevation-1"
  >
  <template v-slot:[`item.actions`]="{ item }">
      <v-btn @click="()=>{deleteStudent(item.ra).then(r => updatePropsMethod())}" >Deletar</v-btn>
      <v-btn @click="$router.push(EDIT_STUDENT_ROUTER(item.ra))">Editar</v-btn>
    </template>
  </v-data-table>
</div>
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
  }),
});
</script>
