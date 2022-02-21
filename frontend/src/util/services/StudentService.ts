import { Student } from '@/util/SharedTypes/StudentType'
import axios from 'axios'
const baseUrl = process.env.ORBITA_API_URL || 'https://localhost:5001'
const STUDENT_ROUTE = `${baseUrl}/students`

export const getAllStudents = async ():Promise<[Student]> => {
  const response = await axios.get(STUDENT_ROUTE)
  return response.data.items.map((student: { cpf: string }) => ({...student, cpf:student.cpf.replace(/(.{3})(.{3})(.{3})(.{2})/, '$1.$2.$3-$4')}))
}

export const getStudentByRa = async (ra:string):Promise<Student> => {
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

export const deleteStudent = async (ra: string) => {
  const response = await axios.delete(`${STUDENT_ROUTE}/${ra}`)
  return response.data
}