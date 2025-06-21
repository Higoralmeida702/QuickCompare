import axios from "axios";

const NotebookApi = axios.create({
    baseURL:"http://localhost:5236/api/Notebook"
});

export default NotebookApi;