import axiosInstance from "./axios.js";

const authorsService = {

    // отримати всіх авторів
    getAll: async () => {
        return await axiosInstance.get('authors')
    },

    // отримати автора по id
    getById: async (id) => {
        return await axiosInstance.get(`authors/${id}`)
    },

    // створити автора
    create: async (name, deathDate) => {
        return await axiosInstance.post('authors', {
            'name': name,
            'deathDate': deathDate
        })
    },

    // оновити автора
    update: async (id, name, deathDate) => {
        return await axiosInstance.put(`authors/${id}`, {
            'name': name,
            'deathDate': deathDate
        })
    },

    // видалити автора
    delete: async (id) => {
        return await axiosInstance.delete(`authors/${id}`)
    }
}

export default authorsService;