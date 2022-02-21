import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './util/store'
import vuetify from './util/plugins/vuetify'
import VueAxios from 'vue-axios'
import axios from './util/plugins/axios'
import Toast from 'vue-toastification';
import "vue-toastification/dist/index.css";

Vue.config.productionTip = false
Vue.use(VueAxios, axios);
Vue.use(Toast);

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
