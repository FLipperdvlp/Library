import axios from "axios";

// екземпляр axios котрий ми будемо використовувати для відправки запитів
const axiosInstance = axios.create({
    baseURL: 'http://localhost:5000/',
    headers: {
        'Content-Type': 'application/json'
    }
})

export default axiosInstance;

