<template>
  <div>
    <v-form v-model="isFormValid">
      <v-text-field
        label="Nome"
        :rules="nomeRules"
        append-icon="mdi-account-circle"
        :disabled="!nameEditable"
        :value="student.name"
        v-model="name"
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
    <v-btn>Cancelar</v-btn>
    <v-btn @click="method({email, cpf, ra, name})" :disabled="!isFormValid" >Salvar</v-btn>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "StudentForm",
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
        name: "",
        email: "",
        ra: "",
        cpf: "",
      }),
    },
  },

  data: () => ({
    email: "",
    name: "",
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
