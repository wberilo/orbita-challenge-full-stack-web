<template>
  <div class="home">
    <StudentForm :cpfEditable="true" :emailEditable="true" :nameEditable="true" :raEditable="true" :method="createStudent" />
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import StudentForm from '@/components/StudentForm.vue';
import {createStudent} from '@/util/services/StudentService';

export default Vue.extend({
  name: 'CreateStudentView',
  
  components: {
    StudentForm,
  },
  methods: {
    createStudent,
  },
});
</script>
