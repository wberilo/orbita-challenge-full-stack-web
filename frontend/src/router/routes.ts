import { Student } from "@/util/SharedTypes/StudentType"

export const STUDENT_ROUTE = "/"
export const STUDENT_ROUTER = () => `${STUDENT_ROUTE}`

export const REGISTER_STUDENT_ROUTE = `${STUDENT_ROUTE}/cadastrar`
export const REGISTER_STUDENT_ROUTER = () => `${REGISTER_STUDENT_ROUTE}`

export const EDIT_STUDENT_ROUTE = `${STUDENT_ROUTE}/editar/:ra`
export const EDIT_STUDENT_ROUTER = (ra:string) => `${EDIT_STUDENT_ROUTE.replace(':ra',ra)}`