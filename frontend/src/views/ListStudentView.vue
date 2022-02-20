<template>
  <div>
    <StudentList :loaded="loaded" :students="students" :updatePropsMethod="updateStudents"/>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import StudentList from '@/components/StudentList.vue';
import { getAllStudents } from "@/util/services/StudentService";
export default Vue.extend({
  name: "StudentForm",
  components: {
    StudentList,
  },
  methods: {
    updateStudents: async function updateStudents() {
      this.students = await getAllStudents()
      this.loaded = true;
    },
  },
  async mounted() {
    this.updateStudents();
	},
  data: () => ({
    students: [{}],
    loaded: false,
  }),
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
        nome: "",
        email: "",
        ra: "",
        cpf: "",
      }),
    },
  },
});
</script>
