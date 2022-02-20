<template>
<div style="width: -webkit-fill-available; margin: 20px">
    <v-form v-model="isFormValid">
      <v-text-field
        label="Nome"
        :rules="nomeRules"
        append-icon="mdi-account-circle"
        :disabled="!nameEditable"
        :value="student.nome"
        v-model="nome"
      />
      <v-text-field
        label="Email"
        :rules="emailRules"
        append-icon="mdi-email"
        :disabled="!emailEditable"
        :value="student.email"
        v-model="email"
      />
      <v-text-field
        label="CPF"
        :rules="cpfRules"
        append-icon="mdi-id-card"
        :disabled="!cpfEditable"
        :value="student.cpf"
        v-model="cpf"
      />
      <v-text-field
        label="Registro acadêmico"
        :rules="raRules"
        append-icon="mdi-account-key"
        :disabled="!raEditable"
        :value="student.ra"
        v-model="ra"
      />
    </v-form>
    <v-btn @click="$router.push(STUDENT_ROUTER())">Cancelar</v-btn>
    <v-btn @click="method({email, cpf, ra, nome}).then(r => $router.push(STUDENT_ROUTER()))" :disabled="!isFormValid" >Salvar</v-btn>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import {STUDENT_ROUTER} from "@/router/routes";

export default Vue.extend({
  name: "StudentForm",
  mounted() {
    this.email = this.student.email;
    this.cpf = this.student.cpf;
    this.ra = this.student.ra;
    this.nome = this.student.nome;
  },
  props: {
    method: Function,
    nameEditable: {
      type: Boolean,
      default: false,
    },
    emailEditable: {
      type: Boolean,
      default: false,
    },
    raEditable: {
      type: Boolean,
      default: false,
    },
    cpfEditable: {
      type: Boolean,
      default: false,
    },
    student: {
      type: Object,
      default: () => ({
        email: "",
        cpf: "",
        ra: "",
        nome: "",
      }),
    },
  },
  methods: {
    STUDENT_ROUTER
  },

  data: () => ({
    email: "",
    nome: "",
    ra: "",
    cpf: "",
    isFormValid: false,
    nomeRules: [
      (v: string) => !!v || "Este campo é obrigatório",
    ],
    emailRules: [
      (v: string) => !!v || "Este campo é obrigatório",
      //Regex: https://www.w3resource.com/javascript/form/email-validation.php
      (v: string) =>
        /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) ||
        "Este campo deve ser um email válido",
    ],
    raRules: [(v: string) => !!v || "Este campo é obrigatório"],
    cpfRules: [
      (v: string) => !!v || "Este campo é obrigatório",
      (v: string) => v.length === 11 || "Este campo deve ter 11 dígitos",
    ],
  }),
});
</script>
