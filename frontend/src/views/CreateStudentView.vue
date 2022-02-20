<template>
  <div class="home">
    <StudentForm :cpfEditable="true" :emailEditable="true" :nameEditable="true" :raEditable="true" :method="createStudent" />
    <StudentList/>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import StudentForm from '@/components/StudentForm.vue';
import StudentList from '@/components/StudentList.vue';
import {Student} from '@/util/SharedTypes/StudentType';

const createStudent = (student: Student) => {
  console.log(student)
}

export default Vue.extend({
  name: 'CreateStudentView',
  components: {
    StudentForm,
    StudentList,
  },
  methods: {
    createStudent,
  },
});
</script>
