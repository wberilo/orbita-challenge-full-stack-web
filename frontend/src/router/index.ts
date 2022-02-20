import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import CreateStudentView from '../views/CreateStudentView.vue'
import { EDIT_STUDENT_ROUTE, REGISTER_STUDENT_ROUTE, STUDENT_ROUTE } from './routes'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: CreateStudentView
  },
  {
    path: STUDENT_ROUTE,
    name: 'listar',
    component: () => import('../views/ListStudentView.vue')
  },
  {
    path: REGISTER_STUDENT_ROUTE,
    name: 'cadastrar',
    component: () => import('../views/CreateStudentView.vue')
  },
  {
    path: EDIT_STUDENT_ROUTE,
    name: 'editar',
    component: () => import('../views/EditStudentView.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
