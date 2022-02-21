<template>
  <div style="width: -webkit-fill-available; margin: 20px">
    <v-btn
      style="margin-bottom: 20px"
      color="primary"
      dark
      @click="$router.push(REGISTER_STUDENT_ROUTER())"
    >
      Criar novo aluno
    </v-btn>
    <v-data-table
      :headers="headers"
      :items="students"
      :items-per-page="5"
      :loading="!loaded"
      class="elevation-1"
      :search="search"
      :custom-filter="filterText"
    >
      <template v-slot:top>
        <v-text-field
          v-model="search"
          label="Pesquisar"
          class="mx-4"
        ></v-text-field>
      </template>
      <template v-slot:[`item.actions`]="{ item }">
        <v-btn
          @click="
            () => {
              studentToDelete = item.ra;
              deleteStudentDialog = true;
            }
          "
          >Deletar</v-btn
        >
        <v-btn @click="$router.push(EDIT_STUDENT_ROUTER(item.ra))"
          >Editar</v-btn
        >
      </template>
    </v-data-table>
    <v-dialog v-model="deleteStudentDialog" max-width="290">
      <v-card>
        <v-card-title class="text-h6"> Deseja excluir o aluno? </v-card-title>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="green darken-1"
            text
            @click="
              () => {
                deleteStudent(studentToDelete).then((r) =>
                  updatePropsMethod().then((r) => (deleteStudentDialog = false))
                );
              }
            "
          >
            Sim
          </v-btn>

          <v-btn
            color="green darken-1"
            text
            @click="deleteStudentDialog = false"
          >
            Não
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { deleteStudent } from "../util/services/StudentService";
import { EDIT_STUDENT_ROUTER, REGISTER_STUDENT_ROUTER } from "../router/routes";

export default Vue.extend({
  name: "StudentForm",
  methods: {
    deleteStudent,
    EDIT_STUDENT_ROUTER,
    REGISTER_STUDENT_ROUTER,
    filterText(value: string, search: string) {
      return (
        value != null &&
        search != null &&
        value.toString().toLocaleUpperCase().indexOf(search.toLocaleUpperCase()) !== -1
      );
    },
  },
  props: {
    students: {
      type: Array,
    },
    updatePropsMethod: Function,
    loaded: {
      type: Boolean,
      default: false,
    },
  },

  data: () => ({
    search: "",
    deleteStudentDialog: false,
    studentToDelete: null,
    headers: [
      { text: "Registro Acadêmico", value: "ra" },
      { text: "Nome", value: "nome" },
      { text: "CPF", value: "cpf" },
      { text: "Ações", value: "actions" },
    ],
  }),
});
</script>
