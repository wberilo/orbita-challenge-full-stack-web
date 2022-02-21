import Vue from 'vue';
import axios from 'axios';

axios.interceptors.response.use(
  (response) => {
    if(response.status === 201){
      Vue.$toast.success("Criado com sucesso", {timeout: 2000, position:"bottom-right"});
      return response;
    }
    return response;
  },
  (error) => {Vue.$toast.error(error.response.data.join(', '), {timeout: 10000, position:"bottom-right"});}
);

export default axios;