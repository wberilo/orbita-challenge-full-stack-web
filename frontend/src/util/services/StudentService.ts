import { Student } from '@/util/SharedTypes/StudentType'
import axios from 'axios'

const STUDENT_ROUTE = `${process.env.ORBITA_API_URL}/students`

type getAllStudentsParams = {
  search?: string
}
export const getAllStudents = async (params: getAllStudentsParams):Promise<[Student]> => {
  const response = await axios.get(STUDENT_ROUTE, {
    params: {
      search: params.search
    }
  })
  return response.data
}

export const getStudentByRa = async (ra:number):Promise<Student> => {
  const response = await axios.get(`${STUDENT_ROUTE}/${ra}`)
  return response.data
}

export const createStudent = async (student: Student) => {
  const response = await axios.post(STUDENT_ROUTE, student)
  return response.data
}

export const updateStudent = async (student: Student) => {
  const response = await axios.put(`${STUDENT_ROUTE}/${student.ra}`, student)
  return response.data
}

export const deleteStudent = async (student: Student) => {
  const response = await axios.delete(`${STUDENT_ROUTE}/${student.ra}`)
  return response.data
}