<template>
  <div class="home">
    <div v-if="isloading">
      <v-progress-circular indeterminate color="primary" class="mb-4" />
    </div>
    <div v-else>
      <StudentForm
        :cpfEditable="false"
        :emailEditable="true"
        :nameEditable="true"
        :raEditable="false"
        :method="updateStudent"
        :student="student"
      />
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import StudentForm from "@/components/StudentForm.vue";
import { updateStudent, getStudentByRa } from "@/util/services/StudentService";

export default Vue.extend({
  name: "CreateStudentView",
  mounted() {
    this.url_data = this.$route.params.ra;
    getStudentByRa(this.url_data).then(response => {
      this.student = response;
      this.isloading = false;
    });
  },
  data() {
    return {
      url_data: "",
      student: {},
      isloading: true,
    };
  },
  components: {
    StudentForm,
  },
  methods: {
    updateStudent,
  },
});
</script>
