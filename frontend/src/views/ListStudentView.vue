<template>
  <div>
    <StudentList/>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import StudentList from '@/components/StudentList.vue';
export default Vue.extend({
  name: "StudentForm",
  components: {
    StudentList,
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
        name: "",
        email: "",
        ra: "",
        cpf: "",
      }),
    },
  },
});
</script>
