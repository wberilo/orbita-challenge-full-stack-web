import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './util/store'
import vuetify from './util/plugins/vuetify'

Vue.config.productionTip = false

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
