import axios from 'axios'

const CelularApi = axios.create({
    baseURL: "http://localhost:5236/api/Celular"
});

export default CelularApi;